using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsDriversData
    {
        static public async Task<DataTable> GetAllDrivers()
        {
            DataTable dataTable = new DataTable();
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            /*string query = @"SELECT DISTINCT D.DriverID, D.PersonID, P.NationalNo, 
                                P.FirstName + ' ' + P.SecondName + ' ' + ISNULL(P.ThirdName, '') + ' ' + P.LastName AS FullName, 
                                D.CreatedDate As 'Date', L.IsActive As 'Active Licenses' FROM Drivers D 
                                INNER JOIN Licenses L ON L.DriverID = D.DriverID
                                INNER JOIN People P ON P.PersonID = D.PersonID;";*/
            
            string query = @"SELECT * FROM Drivers_View;";

            SqlCommand cmd = new SqlCommand(query, _connection);

            try
            {
                await _connection.OpenAsync();
                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.HasRows)
                {
                    dataTable.Load(Reader);
                }
            }
            catch (Exception ex)
            {
                _connection.Close();
                return null;
            }
            finally
            {
                _connection.Close();
            }

            return dataTable;
        }
        static public bool GetDriver(int DriverID, ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool result = false;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *FROM Drivers
                                WHERE DriverID = @DriverID;";

            SqlCommand cmd = new SqlCommand(query, _connection);

            cmd.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                _connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.Read())
                {
                    PersonID = Convert.ToInt16(Reader["PersonID"]);
                    CreatedByUserID = Convert.ToInt16(Reader["CreatedByUserID"]);
                    CreatedDate = Convert.ToDateTime(Reader["CreatedDate"]);
                    

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
        static public bool GetDriverByPersonID(ref int DriverID, int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool result = false;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *FROM Drivers
                                WHERE PersonID = @PersonID;";

            SqlCommand cmd = new SqlCommand(query, _connection);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                _connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.Read())
                {
                    DriverID = Convert.ToInt16(Reader["DriverID"]);
                    CreatedByUserID = Convert.ToInt16(Reader["CreatedByUserID"]);
                    CreatedDate = Convert.ToDateTime(Reader["CreatedDate"]);
                    

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
        public static int AddNewDriver(int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            int _ID = -1;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into Drivers (PersonID, CreatedByUserID, CreatedDate)
                             VALUES(@PersonID, @CreatedByUserID, @CreatedDate);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, _connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);

            try
            {
                _connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    _ID = insertedID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _connection.Close();
            }


            return _ID;
        }
        public static bool UpdateDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            int rowsAffected = 0;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Drivers set
                                          PersonID = @PersonID, 
                                          CreatedByUserID = @CreatedByUserID, 
                                          CreatedDate = @CreatedDate
                             Where DriverID = @DriverID;";

            SqlCommand command = new SqlCommand(query, _connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                _connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                _connection.Close();
            }


            return (rowsAffected >= 0);
        }
        public static bool IsExist(int PersonID)
        {
            bool IsFound = false;

            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM Drivers
                              WHERE PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(query, _connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                _connection.Close();
            }

            return IsFound;
        }
    }
}
