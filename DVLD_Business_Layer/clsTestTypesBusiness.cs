using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsTestTypesBusiness
    {
        enum _enMode { Update, AddNew }
        public int TestTypeID { get; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }
        _enMode Mode { get; set; }
        clsTestTypesBusiness() { }
        clsTestTypesBusiness(int TestTypeID, string TestTypeTitle, string TestTypeDescription, decimal TestTypeFees)
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;

            Mode = _enMode.Update;
        }
        static public DataTable GetAllTestTypes()
        {
            return clsTestTypesDataAccess.GetAllTestTypes();
        }
        static public clsTestTypesBusiness FindTestTypes(int TestTypeID)
        {
            DataRow row = clsTestTypesDataAccess.FindTestTypes(TestTypeID);
            if(row != null)
                return new clsTestTypesBusiness(int.Parse(row["LicenseClassID"].ToString()), row["ClassName"].ToString(), row["TestTypeDescription"].ToString(), Convert.ToDecimal(row["MinimumAllowedAge"].ToString()));
            else
                return null;
        }
        private bool _Update()
        {
            return clsTestTypesDataAccess.UpdateTestTypes(this.TestTypeID, this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
        }
        public bool Save()
        {
            switch (this.Mode)
            {
                case _enMode.Update: return _Update();
                default: return false;
            }
        }
    }
}
