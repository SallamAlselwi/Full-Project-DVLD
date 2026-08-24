using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsLicenseClassesDataAccess
    {
        static public DataTable GetAllLicenseClassess()
        {
            DataTable dt = new DataTable();

            string query = "SELECT * FROM LicenseClasses;";

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

        // الدالة تحتاج الى تعديل
        //static public bool UpdateLicenseClasses(int LicenseClassID, string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees)
        //{
        //    int result = -1;

        //    string query = @"UPDATE LicenseClasses 
        //                                    SET 
        //                                        TestTypeTitle = @TestTypeTitle,
        //                                        TestTypeDescription = @TestTypeDescription,
        //                                        TestTypeFees = @TestTypeFees
        //                     Where LicenseClassID = @LicenseClassID;";

        //    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        //    SqlCommand cmd = new SqlCommand(query, connection);

        //    cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
        //    cmd.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
        //    cmd.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
        //    cmd.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);

        //    try
        //    {
        //        connection.Open();

        //        result = cmd.ExecuteNonQuery();

        //    }
        //    catch
        //    {

        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }


        //    return (result >= 0);
        //}
        
        static public DataRow FindLicenseClasses(int LicenseClassID)
        {
            DataTable dt = new DataTable();

            string query = @"Select *from LicenseClasses
                                Where LicenseClassID = @LicenseClassID;";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

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


            return dt.Rows[0];
        }

    }
}
