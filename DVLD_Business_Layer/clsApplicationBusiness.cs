using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business_Layer
{
    public class clsApplicationBusiness
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enum Status { New = 1, Cancelled = 2, Completed = 3}

        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
        };

        public int ApplicationID { get; set; }
        public int ApplicantPersonID {get; set;}
        public string ApplicantFullName 
        {   get
            {
                return clsPeopleBusiness.Find(this.ApplicantPersonID).FullName;
            }
        }
        public DateTime ApplicationDate {get; set;}
        public int ApplicationTypeID {get; set;}
        public Status ApplicationStatus {get; set;}
        public DateTime LastStatusDate {get; set;}
        public decimal PaidFees {get; set;}
        public int CreatedByUserID { get; set; }

        public enMode Mode { get; set;}
        

        public clsApplicationBusiness() 
        {
            ApplicationID = -1;
            ApplicantPersonID = -1;
            ApplicationDate = DateTime.Now;
            LastStatusDate = DateTime.Now;
            ApplicationTypeID = -1;
            PaidFees = 0;
            CreatedByUserID = -1;

            Mode = enMode.AddNew;
            ApplicationStatus = Status.New;

        }
        clsApplicationBusiness(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int applicationTypeID,
                            byte ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = (Status)ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }

        public static DataTable GetAllApplication()
        {
            return clsApplicationsDataAccess.GetAllApplications();
        }

        public static clsApplicationBusiness FindBaseApplication(int ApplicationID)
        {
            int ApplicantPersonID = -1, applicationTypeID = -1, CreatedByUserID = -1;
            byte ApplicationStatus = 1;
            DateTime LastStatusDate = DateTime.Now, ApplicationDate = DateTime.Now;
            decimal PaidFees = 0;

            bool isFound = clsApplicationsDataAccess.GetApplicationInfoByID(ApplicationID, ref ApplicantPersonID, ref ApplicationDate, ref applicationTypeID,
                                                                            ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID);

            if (isFound)
            {
                return new clsApplicationBusiness(ApplicationID, ApplicantPersonID, ApplicationDate, applicationTypeID, ApplicationStatus,
                                        LastStatusDate, PaidFees, CreatedByUserID);
            }
            else
                return null;
        }

        bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationsDataAccess.AddNewApplication(this.ApplicantPersonID, this.ApplicationDate, 
                this.ApplicationTypeID, (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

            if(this.ApplicationID > 0)
            {
                this.Mode = enMode.Update;
                return true;
            }
            else
            {
                return false;
            }
        }
       
        /*static public clsApplicationBusiness FindApplication(int ApplicationTypeID)
        {
            DataRow row = clsApplicationTypesDataAccess.FindApplicationTypes(ApplicationTypeID);

            return new clsApplicationTypesBusiness(int.Parse(row["LicenseClassID"].ToString()), row["applicationTypeTitle"].ToString(), Convert.ToDecimal(row["MinimumAllowedAge"].ToString()));
        }*/
        /*private bool _Update()
        {
            return clsApplicationDataAccess.UpdateApplicationTypes(this.ApplicationID, this.ApplicationTitle, this.ApplicationFees);
        }*/

        static public int IsApplicationExist(int ApplicantPersonID, int ApplicationTypeID)
        {
            return clsApplicationsDataAccess.IsApplicationExist(ApplicantPersonID, ApplicationTypeID);
        }
        public static int GetActiveApplicationIDForLicenseClass(int PersonID, clsApplicationBusiness.enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return clsApplicationsDataAccess.GetActiveApplicationIDForLicenseClass(PersonID, (int)ApplicationTypeID, LicenseClassID);
        }

        public bool Save()
        {
            switch(this.Mode)
            {
                case enMode.AddNew: return _AddNewApplication();
                //case enMode.Update: return _Update();
                    default: return false;
            }

        } 
    }
}
