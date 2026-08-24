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
        enum _enMode { Update, AddNew }
        public int LicenseClassID { get; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public decimal ClassFees { get; set; }
        _enMode Mode { get; set; }
        clsLicenseClassesBusiness() { }
        clsLicenseClassesBusiness(int LicenseClassID, string ClassName, string ClassDescription, byte MinimumAllowedAge, 
                                    byte DefaultValidityLength, decimal ClassFees)
        {
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;

            Mode = _enMode.Update;
        }
        static public DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassesDataAccess.GetAllLicenseClassess();
        }
        static public clsLicenseClassesBusiness FindLicenseClasses(int LicenseClassID)
        {
            DataRow row = clsLicenseClassesDataAccess.FindLicenseClasses(LicenseClassID);
            if (row != null)
                return new clsLicenseClassesBusiness(int.Parse(row["LicenseClassID"].ToString()), row["ClassName"].ToString(), row["ClassDescription"].ToString(),
                                Convert.ToByte(row["MinimumAllowedAge"].ToString()), Convert.ToByte(row["DefaultValidityLength"].ToString()), 
                                Convert.ToDecimal(row["ClassFees"].ToString()));
            else
                return null;
        }

        //private bool _Update()
        //{
        //    return clsLicenseClassesDataAccess.Update();
        //}
        //public bool Save()
        //{
        //    switch (this.Mode)
        //    {
        //        case _enMode.Update: return _Update();
        //        default: return false;
        //    }
        //}
    }
}
