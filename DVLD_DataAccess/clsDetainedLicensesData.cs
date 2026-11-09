using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DVLD_DataAccess
{
    public class clsDetainedLicensesData
    {
        static public async Task<DataTable> GetAllDetainedLicenses()
        {
            DataTable dataTable = new DataTable();
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT 'D.ID' = DL.DetainID, 'L.ID' = L.LicenseID, 'D.Date' = DL.DetainDate, 'Is.Released' = DL.IsReleased, 
                                'Fine Fees' = DL.FineFees, 'Release Date' = DL.ReleaseDate, 
                                'N.No' = (SELECT P.NationalNo 
                                          FROM People P 
                                          WHERE D.PersonID = P.PersonID),
                                'Full.Name' = (SELECT P.FirstName +' '+ P.SecondName +' '+ ISNULL(P.ThirdName, '') +' '+ P.LastName 
                                            FROM People P 
                                            WHERE D.PersonID = P.PersonID),
                                'Release.App.ID' = DL.ReleaseApplicationID
                             FROM DetainedLicenses DL
                             INNER JOIN Licenses L ON DL.LicenseID = L.LicenseID
                             INNER JOIN Drivers D ON L.DriverID = D.DriverID
                             ORDER BY DL.IsReleased ASC";

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

        public static int AddNewDetained(int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID, bool IsReleased)
        {
            int _ID = -1;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into DetainedLicenses (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased)
                             VALUES(@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @IsReleased);
                             
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, _connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);

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
        public static bool UpdateDetained(int DetainID, int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID, bool IsReleased,
                            DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int rowsAffected = 0;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update DetainedLicenses set
                                                        LicenseID= @LicenseID,
                                                        DetainDate= @DetainDate,
                                                        FineFees= @FineFees,
                                                        CreatedByUserID= @CreatedByUserID,
                                                        IsReleased= @IsReleased,
                                                        ReleaseDate= @ReleaseDate,
                                                        ReleasedByUserID= @ReleasedByUserID,
                                                        ReleaseApplicationID= @ReleaseApplicationID

                             Where DetainID = @DetainID;";

            SqlCommand command = new SqlCommand(query, _connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);

            if(ReleaseDate == null)
                command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            if(ReleasedByUserID == -1)
                command.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            if(ReleaseApplicationID == -1)
                command.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);
            else
                command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);

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
        public static bool Release(int DetainID, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int rowsAffected = 0;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update DetainedLicenses set
                                                        ReleaseDate= @ReleaseDate,
                                                        ReleasedByUserID= @ReleasedByUserID,
                                                        ReleaseApplicationID= @ReleaseApplicationID

                             Where DetainID = @DetainID;";

            SqlCommand command = new SqlCommand(query, _connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);
            command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);

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
        
        static public bool GetDetainedByDetainID(int DetainID, ref int LicenseID, ref DateTime DetainDate, ref decimal FineFees, ref int CreatedByUserID, ref bool IsReleased,
                            ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool result = false;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *FROM DetainedLicenses
                                WHERE DetainID = @DetainID;";

            SqlCommand cmd = new SqlCommand(query, _connection);

            cmd.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                _connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.Read())
                {
                    LicenseID = int.Parse(Reader["LicenseID"].ToString());
                    DetainDate = Convert.ToDateTime(Reader["DetainDate"]);
                    FineFees = Convert.ToDecimal(Reader["FineFees"]);
                    CreatedByUserID = int.Parse(Reader["CreatedByUserID"].ToString());
                    IsReleased = Convert.ToBoolean(Reader["IsReleased"]);
                    ReleaseDate = Convert.ToDateTime(Reader["ReleaseDate"]);
                    ReleasedByUserID = int.Parse(Reader["ReleasedByUserID"].ToString());
                    ReleaseApplicationID = int.Parse(Reader["ReleaseApplicationID"].ToString());

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
        static public bool GetDetainedByLicenseID(ref int DetainID, int LicenseID, ref DateTime DetainDate, ref decimal FineFees, ref int CreatedByUserID, ref bool IsReleased,
                            ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool result = false;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *FROM DetainedLicenses
                                WHERE LicenseID = @LicenseID
                                AND IsReleased = 0;";

            SqlCommand cmd = new SqlCommand(query, _connection);

            cmd.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                _connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.Read())
                {
                    DetainID = int.Parse(Reader["DetainID"].ToString());
                    DetainDate = Convert.ToDateTime(Reader["DetainDate"]);
                    FineFees = Convert.ToDecimal(Reader["FineFees"]);
                    CreatedByUserID = int.Parse(Reader["CreatedByUserID"].ToString());
                    IsReleased = Convert.ToBoolean(Reader["IsReleased"]);
                    if (Reader["ReleaseDate"] != DBNull.Value)
                        ReleaseDate = Convert.ToDateTime(Reader["ReleaseDate"]);
                    
                    if (Reader["ReleasedByUserID"] != DBNull.Value)
                        ReleasedByUserID = int.Parse(Reader["ReleasedByUserID"].ToString());
                    if (Reader["ReleaseApplicationID"] != DBNull.Value)
                        ReleaseApplicationID = int.Parse(Reader["ReleaseApplicationID"].ToString());

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
        
    }
}
