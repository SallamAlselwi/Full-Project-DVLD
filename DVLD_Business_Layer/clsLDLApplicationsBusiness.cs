using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_Business_Layer.clsLDLApplicationsBusiness;

namespace DVLD_Business_Layer
{
    public class clsLDLApplicationsBusiness : clsApplicationBusiness
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int LocalDrivingLicenseApplicationID { set; get; }
        public int LicenseClassID { set; get; }
        public clsLicensesBuisness LicenseClassInfo;

        public clsLDLApplicationsBusiness()

        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.LicenseClassID = -1;


            Mode = enMode.AddNew;

        }

        private clsLDLApplicationsBusiness(int LocalDrivingLicenseApplicationID, int ApplicationID, int ApplicationPersonID,
            DateTime ApplicationDate, int ApplicationTypeID,
             Status ApplicationStatus, DateTime LastStatusDate,
             decimal PaidFees, int CreatedByUserID, int LicenseClassID)

        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID; ;
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicationPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = (int)ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.LicenseClassID = LicenseClassID;
            //this.LicenseClassInfo = clsLicensesBuisness.Find(LicenseClassID);
            Mode = enMode.Update;
        }

        public string PersonFullName
        {
            get
            {
                return clsPeopleBusiness.Find(ApplicantPersonID).FullName;
            }

        }

        static public DataTable GetLDLApplicationsTypes()
        {
            return clsLDLApplicationsDataAccess.GetAllLDLApplicationsTypes();
        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            //call DataAccess Layer 

            this.LocalDrivingLicenseApplicationID = clsLDLApplicationsDataAccess.AddNewLocalDrivingLicenseApplication
                (this.ApplicationID, this.LicenseClassID);

            return (this.LocalDrivingLicenseApplicationID != -1);
        }

        public static clsLDLApplicationsBusiness FindByLocalDrivingAppLicenseID(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = -1, LicenseClassID = -1;

            bool isFound = clsLDLApplicationsDataAccess.GetByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID);

            if (isFound)
            {
                clsApplicationBusiness Application = clsApplicationBusiness.FindBaseApplication(ApplicationID);


                return new clsLDLApplicationsBusiness(LocalDrivingLicenseApplicationID, ApplicationID, Application.ApplicantPersonID,
                                                    Application.ApplicationDate, Application.ApplicationTypeID, Application.ApplicationStatus, Application.LastStatusDate,
                                                    Application.PaidFees, Application.CreatedByUserID, LicenseClassID);
            }
            else
                return null;

        }

        public bool Cancel()
        {
            return clsApplicationsDataAccess.UpdateStatus(this.ApplicationID, 2);
        }
        public bool Save()
        {
            base.Mode = (clsApplicationBusiness.enMode)Mode; 
            if(!base.Save())
                return false;


            switch (Mode)
            {
                case enMode.AddNew: return _AddNewLocalDrivingLicenseApplication();
                //case enMode.Update: return _Update();
                default: return false;
            }

        }
    }
}
