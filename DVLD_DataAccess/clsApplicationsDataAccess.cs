using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsApplicationsDataAccess
    {
        public static DataTable GetAllApplications()
        {
            DataTable dt = new DataTable();

            string query = "SELECT * FROM Applications;";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand cmd = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                else
                {
                    dt.Load(null);
                }

            }
            catch
            {
                dt.Load(null);
            }
            finally
            {
                connection.Close();
            }


            return dt;
        }

        public static int AddNewApplications(int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, 
                                        byte ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            int _UserID = -1;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
                             VALUES(@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedByUserID);

                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, _connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            
            try
            {
                _connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    _UserID = insertedID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _connection.Close();
            }


            return _UserID;
        }
        public static bool UpdateApplications(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, 
                                        byte ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            int rowsAffected = -1;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Applications SET
                                                ApplicantPersonID = @ApplicantPersonID,
                                                ApplicationDate = @ApplicationDate, 
                                                ApplicationTypeID = @ApplicationTypeID, 
                                                ApplicationStatus = @ApplicationStatus, 
                                                LastStatusDate = @LastStatusDate,
                                                PaidFees =@PaidFees,
                                                CreatedByUserID = @CreatedByUserID

                                        WHERE ApplicationID = @ApplicationID;";

            SqlCommand command = new SqlCommand(query, _connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            
            try
            {
                _connection.Open();

                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _connection.Close();
            }


            return (rowsAffected >= 0);
        }
        public static DataRow GetApplications(int ApplicationID)
        {
            DataTable dataTable = new DataTable();
            
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *FROM Applications
                                    WHERE ApplicationID = @ApplicationID;";

            SqlCommand command = new SqlCommand(query, _connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                _connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dataTable.Load(Reader);
                }
                else
                {
                    dataTable = null;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _connection.Close();
            }


            return (dataTable != null) ? dataTable.Rows[0] : null;
        }

    }
}
