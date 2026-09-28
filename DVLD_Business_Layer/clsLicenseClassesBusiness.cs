using DVLD_Business_Layer.Tests;
using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsLicenseClassesBusiness
    {
        public enum enMode { Update = 1, AddNew = 0 }

        public int LicenseClassID { get; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public decimal ClassFees { get; set; }
        enMode Mode { get; set; }
        clsLicenseClassesBusiness() 
        {
            this.LicenseClassID = -1;
            this.ClassName = "";
            this.ClassDescription = "";
            this.MinimumAllowedAge = 18;
            this.DefaultValidityLength = 10;
            this.ClassFees = 0;

            Mode = enMode.AddNew;
        }
        clsLicenseClassesBusiness(int LicenseClassID, string ClassName, string ClassDescription, byte MinimumAllowedAge, 
                                    byte DefaultValidityLength, decimal ClassFees)
        {
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;

            Mode = enMode.Update;
        }
        static public DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassesDataAccess.GetAllLicenseClassess();
        }

        public static clsLicenseClassesBusiness Find(int LicenseClassID)
        {
            DataRow row = clsLicenseClassesDataAccess.FindLicenseClasses(LicenseClassID);
            if (row != null)
                return new clsLicenseClassesBusiness(int.Parse(row["LicenseClassID"].ToString()), row["ClassName"].ToString(), row["ClassDescription"].ToString(),
                                Convert.ToByte(row["MinimumAllowedAge"].ToString()), Convert.ToByte(row["DefaultValidityLength"].ToString()), 
                                Convert.ToDecimal(row["ClassFees"].ToString()));
            else
                return null;
        }
        
        public static clsLicenseClassesBusiness Find(string ClassName)
        {
            int LicenseClassID = -1; string ClassDescription = "";
            byte MinimumAllowedAge = 18; byte DefaultValidityLength = 10; decimal ClassFees = 0;

            if (clsLicenseClassesDataAccess.GetLicenseClassInfoByClassName(ClassName, ref LicenseClassID, ref ClassDescription,
                    ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))

                return new clsLicenseClassesBusiness(LicenseClassID, ClassName, ClassDescription,
                    MinimumAllowedAge, DefaultValidityLength, ClassFees);
            else
                return null;

        }



    }
}
