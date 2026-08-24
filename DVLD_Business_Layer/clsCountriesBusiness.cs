using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business_Layer
{
    public class clsCountriesBusiness
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public clsCountriesBusiness() 
        { 
            CountryID = -1;
            CountryName = "";
        }
        private clsCountriesBusiness(int CountryID, string CountryName) 
        { 
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }
        public static DataTable GetCountries()
        {
            return clsCountriesDataAccess.GetCountries();
        }
        public static string GetCountryName(int ID)
        {
            return clsCountriesDataAccess.GetCountryName(ID);
        }
        public static clsCountriesBusiness Find(int CountryID)
        {
            string CountryName = "";
            
            bool isFound = clsCountriesDataAccess.GetCountryByID(CountryID, ref CountryName);

            if (isFound)
            {
                return new clsCountriesBusiness(CountryID, CountryName);
            }
            else
                return null;

            //throw new NotImplementedException();
        }
    }
}
