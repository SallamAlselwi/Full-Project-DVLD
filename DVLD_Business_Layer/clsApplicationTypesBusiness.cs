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
        public string ClassName { get; set; }
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
        public static clsApplicationTypesBusiness Find(int ID)
        {
            string Title = ""; decimal Fees = 0;

            if (clsApplicationTypesDataAccess.GetApplicationTypeInfoByID(ID, ref Title, ref Fees))

                return new clsApplicationTypesBusiness(ID, Title, Fees);
            else
                return null;

        }
        
        static public clsApplicationTypesBusiness FindApplicationTypes(int ApplicationTypeID)
        {
            DataRow row = clsApplicationTypesDataAccess.FindApplicationTypes(ApplicationTypeID);

            return new clsApplicationTypesBusiness(int.Parse(row["ApplicationTypeID"].ToString()), row["applicationTypeTitle"].ToString(), Convert.ToDecimal(row["ApplicationFees"].ToString()));
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
