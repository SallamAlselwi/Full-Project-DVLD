using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Business_Layer.Tests
{
    public class clsTestAppointmentsBusiness
    {
        public enum Mode { Add = 0, Update = 1 }

        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }

        Mode mode { get; set; }

        public clsTestAppointmentsBusiness()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = -1;
            this.LocalDrivingLicenseApplicationID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.IsLocked = false;
            this.mode = Mode.Add;
        }
        clsTestAppointmentsBusiness(int testAppointmentID, int testTypeID, int localDrivingLicenseApplicationID, DateTime appointmentDate, 
                            decimal paidFees, int createdByUserID, bool isLocked)
        {
            this.TestAppointmentID = testAppointmentID;
            this.TestTypeID = testTypeID;
            this.LocalDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            this.AppointmentDate = appointmentDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUserID;
            this.IsLocked = isLocked;

            mode = Mode.Update;
        }
    
        public static clsTestAppointmentsBusiness FindTestAppointment(int TestAppointmentID)
        {
            
            int TestTypeID = -1;
            int LocalDrivingLicenseApplicationID = -1;
            DateTime AppointmentDate = DateTime.Now;
            Decimal PaidFees = 0;
            int CreatedByUserID = -1;
            bool IsLocked = false;

            if (clsTestAppointmentsDataAccess.GetTestAppointmentData(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID,
                    ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked))
            {
                return new clsTestAppointmentsBusiness(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked);
            }
            else 
            { 
                return null;
            }

        }

        bool _AddNew()
        {
            this.TestAppointmentID = clsTestAppointmentsDataAccess.AddNewTestAppointment(this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate,
                            this.PaidFees, this.CreatedByUserID, this.IsLocked);

            return (this.TestAppointmentID > 0);
        }
        bool _Update()
        {
            return clsTestAppointmentsDataAccess.UpdateTestAppointment(this.TestAppointmentID, this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate,
                            this.PaidFees, this.CreatedByUserID, this.IsLocked);

            
        }

        public bool Save()
        {
            switch (this.mode)
            {
                case Mode.Add: return _AddNew();
                case Mode.Update: return _Update();
                    default: return false;
            }
        }
    }
}