using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsCountriesDataAccess
    {
        static public DataTable GetCountries()
        {
            DataTable dataTable = new DataTable();

            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select * from Countries;";

            SqlCommand command = new SqlCommand(query, _connection);

            try
            {
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dataTable.Load(reader);
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
        static public String GetCountryName(int ID)
        {
            string CountryName;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select CountryName from Countries Where CountryID = @ID;";

            SqlCommand command = new SqlCommand(query, _connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                _connection.Open();
                CountryName = command.ExecuteScalar().ToString();
                
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

            return CountryName;
        }
        static public bool GetCountryByID(int ID, ref string CounterName)
        {
            bool isFound = false;
            SqlConnection _connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select CountryName from Countries Where CountryID = @ID;";

            SqlCommand command = new SqlCommand(query, _connection);

            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                _connection.Open();
                object reader = command.ExecuteScalar();

                if (reader != null)
                {
                    isFound = true;
                    CounterName = reader.ToString();
                }
                else
                {
                    CounterName = null;
                }

            }
            catch (Exception ex)
            {
                _connection.Close();
                return isFound;
            }
            finally
            {
                _connection.Close();
            }

            return isFound;
        }
    }
}
