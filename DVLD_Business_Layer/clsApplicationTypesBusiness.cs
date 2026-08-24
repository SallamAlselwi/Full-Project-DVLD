using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business_Layer
{
    public class clsApplicationTypesBusiness
    {
        enum _enMode { Update, AddNew }

        public int ApplicationTypeID {get;}
        public string ApplicationTypeTitle { get; set;}
        public decimal ApplicationFees { get; set; }
        _enMode Mode { get; set;}

        clsApplicationTypesBusiness() { }
        clsApplicationTypesBusiness(int applicationTypeID, string applicationTypeTitle, decimal applicationFees)
        {
            ApplicationTypeID = applicationTypeID;
            ApplicationTypeTitle = applicationTypeTitle;
            ApplicationFees = applicationFees;

            Mode = _enMode.Update;
        }

        static public DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypesDataAccess.GetAllApplicationTypes();

        }
        static public clsApplicationTypesBusiness FindApplicationTypes(int ApplicationTypeID)
        {
            DataRow row = clsApplicationTypesDataAccess.FindApplicationTypes(ApplicationTypeID);

            return new clsApplicationTypesBusiness(int.Parse(row["LicenseClassID"].ToString()), row["applicationTypeTitle"].ToString(), Convert.ToDecimal(row["MinimumAllowedAge"].ToString()));
        }
        private bool _Update()
        {
            return clsApplicationTypesDataAccess.UpdateApplicationTypes(this.ApplicationTypeID, this.ApplicationTypeTitle, this.ApplicationFees);
        }

        public bool Save()
        {
            switch(Mode)
            {
                case _enMode.Update: return _Update();
                    default: return false;
            }

        } 
    }
}
