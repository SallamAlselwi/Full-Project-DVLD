using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business_Layer
{
    public class clsLicensesBuisness
    {
        public enum enMode { New = 0, Update = 1 };
        public enum enIssueReason { FirstTime = 1, Renew = 2, ReplacementForDamaged = 3, ReplacementForLost = 4 };

        public int LicenseID {get; set;}
        public int ApplicationID {get; set;}
        public int DriverID {get; set;}
        public int LicenseClass {get; set;}
        public DateTime IssueDate {get; set;}
        public DateTime ExpirationDate {get; set;}
        public string Notes {get; set;}
        public decimal PaidFees {get; set;}
        public bool IsActive {get; set;}
        public enIssueReason IssueReason {get; set;}
        public int CreatedByUserID { get; set; }
        enMode Mode;

        public clsLicensesBuisness()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClass = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = 0000;
            this.IsActive = true;
            this.IssueReason = enIssueReason.FirstTime;
            this.CreatedByUserID = -1;

            this.Mode = enMode.New;
        }
        clsLicensesBuisness(int LicenseID, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, 
                            string Notes, decimal PaidFees, bool IsActive, enIssueReason IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;

            this.Mode = enMode.Update;
        }

        public static async Task<DataTable> GetAllLicenses(int DriverID)
        {
            return await clsLicensesDataAccess.GetAllLicenses(DriverID);
        }
        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID)
        {
            return (GetActiveLicenseIDByPersonID(PersonID, LicenseClassID) != -1);
        }
        public static clsLicensesBuisness FindApplicationID(int ApplicationID)
        {
            int LicenseID =-1;
            int DriverID =-1;
            int LicenseClass =-1;
            DateTime IssueDate =DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            string Notes ="";
            decimal PaidFees =00;
            bool IsActive =false;
            byte IssueReason =0;
            int CreatedByUserID =-1;

            if (clsLicensesDataAccess.GetLicenseByApplicationID(ref LicenseID, ApplicationID, ref DriverID, ref LicenseClass, ref IssueDate, ref ExpirationDate, 
                            ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                return new clsLicensesBuisness(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate,
                            Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            }
            else
                return null;
        }
        public static clsLicensesBuisness FindLicenseID(int LicenseID)
        {
            int ApplicationID = -1;
            int DriverID =-1;
            int LicenseClass =-1;
            DateTime IssueDate =DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            string Notes ="";
            decimal PaidFees =00;
            bool IsActive =false;
            byte IssueReason =0;
            int CreatedByUserID =-1;

            if (clsLicensesDataAccess.GetLicense(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass, ref IssueDate, ref ExpirationDate, 
                            ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                return new clsLicensesBuisness(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate,
                            Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            }
            else
                return null;
        }
        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            return clsLicensesDataAccess.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);
        }
        bool _AddNew()
        {
            this.LicenseID = clsLicensesDataAccess.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClass, this.IssueDate, this.ExpirationDate, 
                                            this.Notes, this.PaidFees, this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);

            return (this.LicenseID > 0) ? true : false;
        }
        bool _Update()
        {
            return clsLicensesDataAccess.UpdateLicenses(this.LicenseID, this.ApplicationID, this.DriverID, this.LicenseClass, this.IssueDate, this.ExpirationDate, 
                                            this.Notes, this.PaidFees, this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);
        }

        public static bool IsExist(int ApplicationID, int LicenseClass)
        {
            return clsLicensesDataAccess.IsExist(ApplicationID, LicenseClass);
        }
        public static bool Active(int LicenseID)
        {
            return clsLicensesDataAccess.IsActive(LicenseID);
        }
        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.New:
                    if (_AddNew())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update: return _Update();

                    default : return false;
            }
        }
    }
}
