using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsUsersDataAccess
    {
        static public async Task<DataTable> GetAllUsers()
        {
            DataTable dataTable = new DataTable();

            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT U.UserID, U.PersonID,
                                    FullName = (Select P.FirstName +' '+ P.SecondName +' '+ P.ThirdName +' '+ P.LastName 
                                            from People P 
                                            where P.PersonID = U.PersonID),
                                    U.UserName, U.IsActive 
                            From Users U;";

            SqlCommand cmd = new SqlCommand(query, _connection);

            try
            {
                await _connection.OpenAsync();

                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.HasRows)
                {
                    dataTable.Load(Reader);
                }
                _connection.Close();
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
        
        //static public bool GetUserByID(int UsersID, ref int UserID, ref string UserName, ref string Password, ref bool IsActive)
        //{
        //    bool reader = false;
        //    SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        //    string query = @"SELECT *FROM Users
        //                      where UserID = @ID;";

        //    SqlCommand cmd = new SqlCommand(query, _connection);

        //    cmd.Parameters.AddWithValue("@ID", UsersID);

        //    try
        //    {
        //        _connection.Open();
        //        SqlDataReader Reader = cmd.ExecuteReader();

        //        if (Reader.Read())
        //        {
                    
        //            reader = true;

        //            UserID = int.Parse(Reader["UserID"].ToString());
        //            UserName = Reader["UserName"].ToString();
        //            Password = Reader["Password"].ToString();
        //            IsActive = BitConverter.(Reader["IsActive"]);

        //        }
        //        else
        //        {
        //            reader = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _connection.Close();
        //        return reader;
        //    }
        //    finally
        //    {
        //        _connection.Close();
        //    }

        //    return reader;
        //}
        static public DataRow GetUserByUserNameAndPassword(string UserName, string Password) 
        {
            DataTable dt = new DataTable();

            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *
                              FROM Users
                              where UserName = @UserName 
                                    and Password = @Password;";

            SqlCommand cmd = new SqlCommand(query, _connection);

            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                _connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.HasRows)
                {
                    dt.Load(Reader);
                }
                else
                {
                    dt = null;
                }
            }
            catch (Exception ex) 
            {
                dt = null;
            }
            finally
            {
                _connection.Close();
            }
            
            return (dt != null)? dt.Rows[0]: null;
        }
        public static int AddNewUser(int PersonID, string UserName, string Password, bool IsActive)
        {
            int _UserID = -1;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into Users (PersonID, UserName, Password, IsActive)
                             VALUES(@PersonID, @UserName, @Password, @IsActive);

                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, _connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
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
        public static bool UpdateUser(int UserID, string UserName, string Password, bool IsActive)
        {
            int rowsAffected = -1;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Users 
                                         set 
                                          UserName = @UserName,
                                          Password = @Password,
                                          IsActive = @IsActive
                            Where UserID = @UserID";

            SqlCommand command = new SqlCommand(query, _connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
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
        public static bool ChangePassword(int UserID, string Password)
        {
            int rowsAffected = -1;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Users
                                          set Password = @Password
                                where UserID = @UserID;";

            SqlCommand command = new SqlCommand(query, _connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@Password", Password);
            
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
        public static bool GetUser(int UserID, ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool IsFound = false;

            string query = @"Select * From Users Where UserID = @UserID;";

            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand _command = new SqlCommand(query, _connection);

            _command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                _connection.Open();

                SqlDataReader reader = _command.ExecuteReader();

                if (reader.Read())
                {

                    PersonID = int.Parse(reader["PersonID"].ToString());
                    UserName = reader["UserName"].ToString();
                    Password = reader["Password"].ToString();
                    IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                    
                    IsFound = true;
                }

            }
            catch
            {
                _connection.Close();
                return IsFound;
            }
            finally
            {
                _connection.Close(); 
            }


            return IsFound;
        }
        static public bool IsUserExist(int PersonID)
        {
            bool IsFound = false;

            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM Users U
                                WHERE U.PersonID = @PersonID;";

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
        static public bool IsUserExist(string Nationsal)
        {
            bool IsFound = false;

            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM People P, Users U
                                WHERE P.NationalNo = @Nationsal and P.PersonID != U.PersonID;";

            SqlCommand command = new SqlCommand(query, _connection);

            command.Parameters.AddWithValue("@Nationsal", Nationsal);

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
        static public bool IsUserNameExist(string UserName)
        {
            bool IsFound = false;

            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM Users U
                                WHERE U.UserName = @UserName;";

            SqlCommand command = new SqlCommand(query, _connection);

            command.Parameters.AddWithValue("@UserName", UserName);

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
