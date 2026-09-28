using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess
{
    public class clsPeopleDataAccess
    {
        static public async Task<DataTable> GetAllPeople() 
        {
            DataTable dataTable = new DataTable();
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
                            Gendor = 
				                    case
					                    when P.Gendor = 0 then 'Male'
					                    else 
						                    'Female'
				                    end
                            ,Address
                            ,Phone
                            ,Email
                            ,Nationlity =(select C.CountryName from Countries C where p.NationalityCountryID = C.CountryID)

                        FROM People P";

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
        //static public  DataRow GetPerson(int ID) 
        //{
        //    DataTable dataTable = new DataTable();
        //    SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        //    string query = @"SELECT *FROM people
        //                      where PersonID = @ID;";

        //    SqlCommand cmd = new SqlCommand(query, _connection);

        //    cmd.Parameters.AddWithValue("@ID", ID);

        //    try
        //    {
        //        _connection.Open();
        //        SqlDataReader Reader = cmd.ExecuteReader();

        //        if (Reader.HasRows)
        //        {
        //            dataTable.Load(Reader);
        //        }
        //    }
        //    catch (Exception ex) 
        //    {
        //        _connection.Close();
        //        return null;
        //    }
        //    finally
        //    {
        //        _connection.Close();
        //    }

        //    return dataTable.Rows[0];
        //}
        
        static public  bool GetPersonByID(int PersonID, ref string NationalNo, ref string FirstName,  ref string SecondName, ref string ThirdName,
                                       ref string LastName, ref DateTime DateOfBirth, ref byte Gendor, ref string Address,
                                       ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool result = false;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *FROM people
                              where PersonID = @ID;";

            SqlCommand cmd = new SqlCommand(query, _connection);

            cmd.Parameters.AddWithValue("@ID", PersonID);

            try
            {
                _connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();

                if(Reader.Read())
                {   

                    NationalNo = Reader["NationalNo"].ToString();
                    FirstName = Reader["FirstName"].ToString();
                    SecondName = Reader["SecondName"].ToString();
                    
                    if (Reader["ThirdName"] != DBNull.Value)
                        ThirdName = Reader["ThirdName"].ToString();
                    else
                        ThirdName = "";
                    
                    LastName = Reader["LastName"].ToString();
                    DateOfBirth = Convert.ToDateTime(Reader["DateOfBirth"]);
                    Gendor = Convert.ToByte(Reader["Gendor"].ToString());
                    Address = Reader["Address"].ToString();
                    Phone = Reader["Phone"].ToString();
                    
                    if (Reader["Email"] != DBNull.Value)
                        Email = Reader["Email"].ToString();
                    else
                        Email = "";
                    
                    NationalityCountryID = (int)Reader["NationalityCountryID"];
                    
                    if (Reader["ImagePath"] != DBNull.Value)
                        ImagePath = Reader["ImagePath"].ToString();
                    else
                        ImagePath = "";
                    
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
        static public  bool GetPersonByNationsal(string NationalNo, ref int PersonID, ref string FirstName,  ref string SecondName, ref string ThirdName,
                                       ref string LastName, ref DateTime DateOfBirth, ref byte Gendor, ref string Address,
                                       ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool result = false;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *FROM people
                              where NationalNo = @NationalNo;";

            SqlCommand cmd = new SqlCommand(query, _connection);

            cmd.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                _connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();

                if(Reader.Read())
                {   

                    PersonID = int.Parse(Reader["PersonID"].ToString());
                    FirstName = Reader["FirstName"].ToString();
                    SecondName = Reader["SecondName"].ToString();
                    
                    if (Reader["ThirdName"] != DBNull.Value)
                        ThirdName = Reader["ThirdName"].ToString();
                    else
                        ThirdName = "";
                    
                    LastName = Reader["LastName"].ToString();
                    DateOfBirth = Convert.ToDateTime(Reader["DateOfBirth"]);
                    Gendor = Convert.ToByte(Reader["Gendor"].ToString());
                    Address = Reader["Address"].ToString();
                    Phone = Reader["Phone"].ToString();
                    
                    if (Reader["Email"] != DBNull.Value)
                        Email = Reader["Email"].ToString();
                    else
                        Email = "";
                    
                    NationalityCountryID = (int)Reader["NationalityCountryID"];
                    
                    if (Reader["ImagePath"] != DBNull.Value)
                        ImagePath = Reader["ImagePath"].ToString();
                    else
                        ImagePath = "";
                    
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
        
        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName, string ThirdName,
                                       string LastName, DateTime DateOfBirth, byte Gendor, string Address,
                                       string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int _ID = -1;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into People (NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
                                                 Gendor, Address, Phone, Email, NationalityCountryID, ImagePath)
                             VALUES(@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth,
                                                 @Gendor, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, _connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if(ImagePath != "" && ImagePath == null)
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            else
                command.Parameters.AddWithValue("@ImagePath", ImagePath);

            try
            {
                _connection.Open();

                object result = command.ExecuteScalar();

                if(result != null && int.TryParse(result.ToString(), out int insertedID))
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
        public static bool UpdatePerson(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName,
                                       string LastName, DateTime DateOfBirth, byte Gendor, string Address,
                                       string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int rowsAffected = 0;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update People set
                                          NationalNo = @NationalNo,
                                          FirstName = @FirstName, 
                                          SecondName = @SecondName, 
                                          ThirdName = @ThirdName, 
                                          LastName = @LastName, 
                                          DateOfBirth = @DateOfBirth,
                                          Gendor = @Gendor, 
                                          Address = @Address, 
                                          Phone = @Phone, 
                                          Email = @Email, 
                                          NationalityCountryID = @NationalityCountryID, 
                                          ImagePath = @ImagePath
                             Where PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(query, _connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gendor);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (ThirdName != "" && ThirdName == null)
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ThirdName", ThirdName);

            if (Email != "" && Email == null)
                command.Parameters.AddWithValue("@Email", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Email", Email); ;
                
            
            if(ImagePath != "" && ImagePath == null)
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            else
                command.Parameters.AddWithValue("@ImagePath", ImagePath);

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
        
        static public bool IsEmailExist(string Email)
        {
            bool IsFound = false;

            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM people
                              WHERE Email = @Email;";

            SqlCommand command = new SqlCommand(query, _connection);

            command.Parameters.AddWithValue("@Email", Email);

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
        static public bool IsPersonExist(int PersonID)
        {
            bool IsFound = false;

            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM people
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
        static public bool IsPersonExist(string Nationsal)
        {
            bool IsFound = false;

            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found = 1 FROM people
                              WHERE NationalNo = @Nationsal;";

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
    }
}
