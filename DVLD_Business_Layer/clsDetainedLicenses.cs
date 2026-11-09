using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsDetainedLicenses

    {
        public enum enMode { New=0, Update=1};

        public int DetainID { get; set;}
        public int LicenseID { get; set;}
        public DateTime DetainDate { get; set;}
        public decimal FineFees { get; set;}
        public int CreatedByUserID { get; set;}
        public bool IsReleased { get; set;}
        public DateTime ReleaseDate { get; set;}
        public int ReleasedByUserID { get; set;}
        public int ReleaseApplicationID { get; set; }

        enMode Mode;

        public clsDetainedLicenses()
        {
            this.DetainID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime. Now;
            this.FineFees = 0000;
            this.CreatedByUserID = -1;
            this.IsReleased = false;
            this.ReleaseDate = DateTime.Now;
            this.ReleasedByUserID = -1;
            this.ReleaseApplicationID = -1;


            this.Mode = enMode.New;
        }

        clsDetainedLicenses(int DetainID, int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID, bool IsReleased, 
                            DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;


            this.Mode = enMode.Update;
        }
        public static async Task<DataTable> GetAllDetainedLicenses()
        {
            return await clsDetainedLicensesData.GetAllDetainedLicenses();
        }
        bool _AddNew()
        {
            this.DetainID = clsDetainedLicensesData.AddNewDetained(this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID, this.IsReleased);

            return (this.DetainID > 0) ? true : false;
        }
        bool _Update()
        {
            return clsDetainedLicensesData.UpdateDetained(this.DetainID, this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID, this.IsReleased,
                            this.ReleaseDate, this.ReleasedByUserID, this.ReleaseApplicationID);
        }
        public static clsDetainedLicenses FindByDetainID(int DetainID)
        {
            int LicenseID = -1, ReleasedByUserID = -1, ReleaseApplicationID = -1, CreatedByUserID = -1;
            DateTime DetainDate = new DateTime(), ReleaseDate = new DateTime();
            decimal FineFees = 0000;
            bool IsReleased = false;

            if(clsDetainedLicensesData.GetDetainedByDetainID(DetainID, ref LicenseID, ref DetainDate, ref FineFees, ref CreatedByUserID, ref IsReleased, 
                                ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID))
            {
                return new clsDetainedLicenses(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, 
                                ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            }
            else
                return null;

        }
        public static clsDetainedLicenses FindByLicenseID(int LicenseID)
        {
            int DetainID = -1, ReleasedByUserID = -1, ReleaseApplicationID = -1, CreatedByUserID = -1;
            DateTime DetainDate = new DateTime(), ReleaseDate = new DateTime();
            decimal FineFees = 0000;
            bool IsReleased = false;

            if(clsDetainedLicensesData.GetDetainedByLicenseID(ref DetainID, LicenseID, ref DetainDate, ref FineFees, ref CreatedByUserID, ref IsReleased, 
                                            ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID))
            {
                return new clsDetainedLicenses(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, 
                                    ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            }
            else
                return null;

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
