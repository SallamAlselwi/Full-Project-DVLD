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

        public static int AddNewApplication(int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
                                byte ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            int ApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)
                             VALUES (@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedByUserID);
                             
                                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ApplicationID = insertedID;
                }
            }

            catch (Exception ex)
            {
            }

            finally
            {
                connection.Close();
            }


            return ApplicationID;
        }

        public static bool UpdateStatus(int ApplicationID, byte Status)
        {
            int rowsAffected = -1;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Applications SET
                                                    ApplicationStatus = @Status

                                            WHERE ApplicationID = @ApplicationID;";

            SqlCommand command = new SqlCommand(query, _connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@Status", Status);

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
        public static bool GetApplicationInfoByID(int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationDate, ref int ApplicationTypeID,
                                ref byte ApplicationStatus, ref DateTime LastStatusDate, ref decimal PaidFees, ref int CreatedByUserID)
        {
            bool rowsAffected = false;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *FROM Applications A
                            WHERE A.ApplicationID = @ApplicationID;";

            SqlCommand command = new SqlCommand(query, _connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    ApplicantPersonID = (int)reader["ApplicantPersonID"];
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationStatus = (byte)reader["ApplicationStatus"];
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    rowsAffected = true;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _connection.Close();
            }


            return rowsAffected;
        }
        /*public static bool GetPersonByID(ref int ApplicationID, int ApplicantPersonID, ref DateTime ApplicationDate, ref int ApplicationTypeID,
                                ref byte ApplicationStatus, ref DateTime LastStatusDate, ref decimal PaidFees, ref int CreatedByUserID)
        {
            bool rowsAffected = false;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *FROM Applications A
                            WHERE A.ApplicationID = @ApplicationID;";

            SqlCommand command = new SqlCommand(query, _connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    ApplicantPersonID = (int)reader["ApplicantPersonID"];
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationStatus = (byte)reader["ApplicationStatus"];
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    rowsAffected = true;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _connection.Close();
            }


            return rowsAffected;
        }*/

        //public static bool UpdateApplications(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicantPersonID, 
        //                                byte ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        //{
        //    int rowsAffected = -1;
        //    SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        //    string query = @"UPDATE Applications SET
        //                                        ApplicantPersonID = @ApplicantPersonID,
        //                                        ApplicationDate = @ApplicationDate, 
        //                                        ApplicantPersonID = @ApplicantPersonID, 
        //                                        ApplicationStatus = @ApplicationStatus, 
        //                                        LastStatusDate = @LastStatusDate,
        //                                        PaidFees =@PaidFees,
        //                                        CreatedByUserID = @CreatedByUserID

        //                                WHERE ApplicationID = @ApplicationID;";

        //    SqlCommand command = new SqlCommand(query, _connection);

        //    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
        //    command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
        //    command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
        //    command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
        //    command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
        //    command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
        //    command.Parameters.AddWithValue("@PaidFees", PaidFees);
        //    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

        //    try
        //    {
        //        _connection.Open();

        //        rowsAffected = command.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {
        //        _connection.Close();
        //    }


        //    return (rowsAffected >= 0);
        //}
        //public static DataRow GetApplications(int ApplicationID)
        //{
        //    DataTable dataTable = new DataTable();

        //    SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        //    string query = @"SELECT *FROM Applications
        //                            WHERE ApplicationID = @ApplicationID;";

        //    SqlCommand command = new SqlCommand(query, _connection);

        //    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

        //    try
        //    {
        //        _connection.Open();
        //        SqlDataReader Reader = command.ExecuteReader();

        //        if (Reader.HasRows)
        //        {
        //            dataTable.Load(Reader);
        //        }
        //        else
        //        {
        //            dataTable = null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {
        //        _connection.Close();
        //    }


        //    return (dataTable != null) ? dataTable.Rows[0] : null;
        //}

        static public int IsApplicationExist(int ApplicantPersonID, int ApplicationTypeID)
        {
            int applicationID = -1;

            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT DISTINCT Found = 1 FROM Applications
                                    WHERE ApplicantPersonID = @ApplicantPersonID and ApplicationTypeID = @ApplicationTypeID and ApplicationStatus != 2;";

            SqlCommand command = new SqlCommand(query, _connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                applicationID = int.Parse(reader["ApplicationID"].ToString());
                reader.Close();
            }
            catch (Exception ex)
            {
                applicationID = -1;
            }
            finally
            {
                _connection.Close();
            }

            return applicationID;

        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, int ApplicationTypeID, int LicenseClassID)
        {
            int ActiveApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query =

                @"  SELECT ActiveApplicationID=A.ApplicationID
                            From
                            Applications A INNER JOIN
                            LocalDrivingLicenseApplications L ON A.ApplicationID = L.ApplicationID
                            WHERE A.ApplicantPersonID = @ApplicationPersonID
                            and ApplicationTypeID = @ApplicationTypeID
							and L.LicenseClassID = @LicenseClassID
                            and ApplicationStatus = 1
                            and ApplicationStatus = 3;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationPersonID", PersonID);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int AppID))
                {
                    ActiveApplicationID = AppID;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return ActiveApplicationID;
            }
            finally
            {
                connection.Close();
            }

            return ActiveApplicationID;
        }

    }
}
