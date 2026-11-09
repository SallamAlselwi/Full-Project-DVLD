using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer.Tests
{
    public class clsTestsBusiness
    {
        public enum enMode { New = 0, Update = 1 }

        public int TestID;
        public int TestAppointmentID;
        public bool TestResult;
        public string Notes;
        public int CreatedByUserID;
        public enMode Mode;

        public clsTestsBusiness()
        {
            TestID = -1;
            TestAppointmentID = -1;
            TestResult = false;
            Notes = "";
            CreatedByUserID = -1;
            Mode = enMode.New;

        }
        clsTestsBusiness(int TestID, int TestAppointmentID,  bool TestResult, string Notes, int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;

            this.Mode = enMode.Update;

        }
        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTestsDataAccess.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }
        bool __AddNewTest()
        {
            this.TestID = clsTestsDataAccess.AddNewTest(this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);

            return (TestID > 0);
        }
        public static clsTestsBusiness Find(int TestID)
        {
            int TestAppointmentID = -1;
            bool TestResult= false;
            string Notes= "";
            int CreatedByUserID= -1;

            if (clsTestsDataAccess.GetTestData(TestID, ref TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID))
            {
                return new clsTestsBusiness(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            }
            else
                return null;

        }
        public static clsTestsBusiness FindByTestAppointmentID(int TestAppointmentID)
        {
            int TestID = -1;
            bool TestResult= false;
            string Notes= "";
            int CreatedByUserID= -1;

            if (clsTestsDataAccess.GetByTestAppointmentID(ref TestID, TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID))
            {
                return new clsTestsBusiness(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            }
            else
                return null;

        }
        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.New: return __AddNewTest();

                    default: return false;
            }
        }
    }
}
