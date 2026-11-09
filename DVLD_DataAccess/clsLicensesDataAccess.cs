using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsLicensesDataAccess
    {
        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT        Licenses.LicenseID
                            FROM Licenses INNER JOIN
                                                     Drivers ON Licenses.DriverID = Drivers.DriverID
                            WHERE  
                             
                             Licenses.LicenseClass = @LicenseClass 
                              AND Drivers.PersonID = @PersonID
                              And IsActive=1;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClassID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return LicenseID;
        }

        static public async Task<DataTable> GetAllLicenses()
        {
            DataTable dataTable = new DataTable();
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *FROM Licenses;";

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
        static public async Task<DataTable> GetAllLicenses(int DriverID)
        {
            DataTable dataTable = new DataTable();
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT L.LicenseID, L.ApplicationID, 
                                   (SELECT LC.ClassName FROM LicenseClasses LC WHERE LC.LicenseClassID = L.LicenseClass) AS ClassName,
                                   L.IssueDate, L.ExpirationDate, L.IsActive 
                            FROM Licenses L
                            WHERE L.DriverID = @DriverID
                            ORDER BY L.IsActive DESC, L.IssueDate DESC;";

            SqlCommand cmd = new SqlCommand(query, _connection);

            cmd.Parameters.AddWithValue("@DriverID", DriverID);

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
        static public bool GetLicense(int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClass, ref DateTime IssueDate, ref DateTime ExpirationDate,
                            ref string Notes, ref decimal PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {
            bool result = false;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *FROM Licenses
                                WHERE LicenseID = @LicenseID;";

            SqlCommand cmd = new SqlCommand(query, _connection);

            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                _connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.Read())
                {
                    ApplicationID = Convert.ToInt16(Reader["ApplicationID"].ToString());
                    DriverID = Convert.ToInt16(Reader["DriverID"].ToString());
                    LicenseClass = Convert.ToInt16(Reader["LicenseClass"].ToString());
                    IssueDate = Convert.ToDateTime(Reader["IssueDate"].ToString());
                    ExpirationDate = Convert.ToDateTime(Reader["ExpirationDate"].ToString());

                    if (Reader["Notes"] != DBNull.Value)
                        Notes = Reader["Notes"].ToString();
                    else
                        Notes = "";
                    
                    PaidFees = Convert.ToDecimal(Reader["PaidFees"].ToString());
                    IsActive = Convert.ToBoolean(Reader["IsActive"].ToString());
                    IssueReason = Convert.ToByte(Reader["IssueReason"].ToString());
                    CreatedByUserID = Convert.ToInt16(Reader["CreatedByUserID"].ToString());

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
        static public bool GetLicenseByApplicationID(ref int LicenseID, int ApplicationID, ref int DriverID, ref int LicenseClass, ref DateTime IssueDate, ref DateTime ExpirationDate,
                            ref string Notes, ref decimal PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {
            bool result = false;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *FROM Licenses
                                WHERE ApplicationID = @ApplicationID;";

            SqlCommand cmd = new SqlCommand(query, _connection);

            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                _connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.Read())
                {
                    LicenseID = Convert.ToInt16(Reader["LicenseID"].ToString());
                    DriverID = Convert.ToInt16(Reader["DriverID"].ToString());
                    LicenseClass = Convert.ToInt16(Reader["LicenseClass"].ToString());
                    IssueDate = Convert.ToDateTime(Reader["IssueDate"].ToString());
                    ExpirationDate = Convert.ToDateTime(Reader["ExpirationDate"].ToString());
                    Notes = Reader["Notes"].ToString();
                    PaidFees = Convert.ToDecimal(Reader["PaidFees"].ToString());
                    IsActive = Convert.ToBoolean(Reader["IsActive"].ToString());
                    IssueReason = Convert.ToByte(Reader["IssueReason"].ToString());
                    CreatedByUserID = Convert.ToInt16(Reader["CreatedByUserID"].ToString());

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
        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate,
                            string Notes, decimal PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            int _ID = -1;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Licenses (ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
                             VALUES(@ApplicationID, @DriverID, @LicenseClass, @IssueDate, @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID);
                             
                                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, _connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            if(Notes == "" || Notes == null)
                command.Parameters.AddWithValue("@Notes", System.DBNull.Value);
            else
                command.Parameters.AddWithValue("@Notes", Notes);
            
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

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
        public static bool UpdateLicenses(int LicenseID, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate,
                    string Notes, decimal PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            int rowsAffected = 0;

            string query = @"UPDATE Licenses SET
                            ApplicationID = @ApplicationID,
                            DriverID = @DriverID,
                            LicenseClass = @LicenseClass,
                            IssueDate = @IssueDate,
                            ExpirationDate = @ExpirationDate,
                            Notes = @Notes,
                            PaidFees = @PaidFees,
                            IsActive = @IsActive,
                            IssueReason = @IssueReason,
                            CreatedByUserID = @CreatedByUserID
                     WHERE LicenseID = @LicenseID;";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LicenseID", LicenseID);
                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                    command.Parameters.AddWithValue("@DriverID", DriverID);
                    command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
                    command.Parameters.AddWithValue("@IssueDate", IssueDate);
                    command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

                    if (string.IsNullOrEmpty(Notes))
                        command.Parameters.AddWithValue("@Notes", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Notes", Notes);

                    command.Parameters.AddWithValue("@PaidFees", PaidFees);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

                    command.Parameters.AddWithValue("@IssueReason", IssueReason);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
            }

            return (rowsAffected > 0);
        }

        public static bool IsExist(int ApplicationID, int LicenseClass)
        {

            bool IsFound = false;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT 1 FROM Licenses
                             Where ApplicationID = @ApplicationID
                             AND LicenseClass = @LicenseClass;";

            SqlCommand command = new SqlCommand(query, _connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);

            try
            {
                _connection.Open();

                SqlDataReader result = command.ExecuteReader();
                
                IsFound = result.HasRows;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                _connection.Close();
            }


            return IsFound;
        }
        public static bool IsActive(int LicenseID)
        {

            bool IsFound = false;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT IsActive FROM Licenses
                             Where LicenseID = @LicenseID;";

            SqlCommand command = new SqlCommand(query, _connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                _connection.Open();

                SqlDataReader result = command.ExecuteReader();
                
                IsFound = Convert.ToBoolean(result["IsActive"]);

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                _connection.Close();
            }


            return IsFound;
        }


    }
}
