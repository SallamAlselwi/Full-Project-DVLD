using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsApplicationTypesDataAccess
    {
        static public DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();

            string query = "Select *from ApplicationTypes;";

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
        static public bool UpdateApplicationTypes(int ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationFees)
        {
            int result = -1;

            string query = @"Update ApplicationTypes set 
                                                        ApplicationFees = @ApplicationFees,
                                                        ApplicationTypeTitle = @ApplicationTypeTitle
                             Where ApplicationTypeID = @ApplicationTypeID;";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            cmd.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            cmd.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);

            try
            {
                connection.Open();

                result = cmd.ExecuteNonQuery();

            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }


            return (result >= 0);
        }
        static public DataRow FindApplicationTypes(int ApplicationTypeID)
        {
            DataTable dt = new DataTable();

            string query = @"Select *from ApplicationTypes
                                Where ApplicationTypeID = @ApplicationTypeID;";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

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
                dt = null;
            }
            finally
            {
                connection.Close();
            }


            return dt.Rows[0];
        }
        public static bool GetApplicationTypeInfoByID(int ApplicationTypeID,
            ref string ApplicationTypeTitle, ref decimal ApplicationFees)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                    ApplicationFees = Convert.ToDecimal(reader["ApplicationFees"]);





                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

    }
}
