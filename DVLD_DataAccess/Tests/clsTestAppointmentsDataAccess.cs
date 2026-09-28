using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsTestAppointmentsDataAccess
    {
        public static bool GetTestAppointmentData(int TestAppointmentID, ref int TestTypeID, ref int LocalDrivingLicenseApplicationID, 
                            ref DateTime AppointmentDate, ref decimal PaidFees, ref int CreatedByUserID, ref bool IsLocked)
        {
            bool result = false;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *FROM TestAppointments
                              where TestAppointmentID = @TestAppointmentID;";

            SqlCommand cmd = new SqlCommand(query, _connection);

            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                _connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.Read())
                {
                    TestTypeID = Convert.ToInt16(Reader["TestTypeID"]);
                    LocalDrivingLicenseApplicationID = Convert.ToInt16(Reader["LocalDrivingLicenseApplicationID"]);
                    AppointmentDate = Convert.ToDateTime(Reader["AppointmentDate"]);
                    PaidFees = Convert.ToDecimal(Reader["PaidFees"]);
                    CreatedByUserID = Convert.ToInt16(Reader["CreatedByUserID"]);
                    IsLocked = Convert.ToBoolean(Reader["IsLocked"]);
                    

                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                _connection.Close();
                return result;
            }
            finally
            {
                _connection.Close();
            }

            return result;
        }
        
        public static int AddNewTestAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID, 
                            DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked)
        {
            int TestAppointmentID = -1;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Insert into TestAppointments (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked)
                             VALUES(@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate, @PaidFees, @CreatedByUserID, @IsLocked);

                             SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, _connection);

            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            cmd.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@IsLocked", IsLocked);

            try
            {
                _connection.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    TestAppointmentID = id;
                }
                else
                {
                    TestAppointmentID = -1;
                }
            }
            catch (Exception ex)
            {
                _connection.Close();
                return -1;
            }
            finally
            {
                _connection.Close();
            }

            return TestAppointmentID;
        }
        public static bool UpdateTestAppointment(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, 
                            DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked)
        {
            int result = -1;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update TestAppointments set
                                          TestTypeID = @TestTypeID,
                                          LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID, 
                                          AppointmentDate = @AppointmentDate, 
                                          PaidFees = @PaidFees, 
                                          CreatedByUserID = @CreatedByUserID, 
                                          IsLocked = @IsLocked
                             Where TestAppointmentID = @TestAppointmentID;";

            SqlCommand cmd = new SqlCommand(query, _connection);

            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            cmd.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            cmd.Parameters.AddWithValue("@IsLocked", IsLocked);

            try
            {
                _connection.Open();
                
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _connection.Close();
                return false;
            }
            finally
            {
                _connection.Close();
            }

            return (result >= 0);
        }
    
    }
}
