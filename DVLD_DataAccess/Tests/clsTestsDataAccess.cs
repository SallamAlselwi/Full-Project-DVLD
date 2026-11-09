using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsTestsDataAccess
    {

        public static bool GetTestData(int TestID, ref int TestAppointmentID, ref bool TestResult,
                                ref string Notes, ref int CreatedByUserID)
        {
            bool result = false;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *FROM Tests
                              where TestID = @TestID;";

            SqlCommand cmd = new SqlCommand(query, _connection);

            cmd.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                _connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.Read())
                {
                    TestAppointmentID = Convert.ToInt16(Reader["TestAppointmentID"]);
                    TestResult = Convert.ToBoolean(Reader["TestResult"]);
                    Notes = Convert.ToString(Reader["AppointmentDate"]);
                    CreatedByUserID = Convert.ToInt16(Reader["CreatedByUserID"]);


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

        public static bool GetByTestAppointmentID(ref int TestID, int TestAppointmentID, ref bool TestResult,
                                ref string Notes, ref int CreatedByUserID)
        {
            bool result = false;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *FROM Tests
                              where TestAppointmentID = @TestAppointmentID;";

            SqlCommand cmd = new SqlCommand(query, _connection);

            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                _connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.Read())
                {
                    TestID = Convert.ToInt16(Reader["TestID"]);
                    TestResult = Convert.ToBoolean(Reader["TestResult"]);
                    Notes = Convert.ToString(Reader["Notes"]);
                    CreatedByUserID = Convert.ToInt16(Reader["CreatedByUserID"]);


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

        public static int AddNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int ID = -1;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Insert into Tests (TestAppointmentID, TestResult, Notes, CreatedByUserID)
                             VALUES(@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID);

                             SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, _connection);

            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            cmd.Parameters.AddWithValue("@TestResult", TestResult);
            cmd.Parameters.AddWithValue("@Notes", Notes);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                _connection.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    ID = id;
                }
                else
                {
                    ID = -1;
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

            return ID;
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            byte Passed = 0;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select Count(TestTypeID) From Tests T
                             Inner Join TestAppointments TA ON t.TestAppointmentID = TA.TestAppointmentID
                             Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and TestResult = 1;";

            SqlCommand cmd = new SqlCommand(query, _connection);

            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                _connection.Open();

                object result = cmd.ExecuteScalar();

                if(result != null && byte.TryParse(result.ToString(), out byte b))
                {
                    Passed = b;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _connection.Close();
            }

            return Passed;
        }

    }
}
