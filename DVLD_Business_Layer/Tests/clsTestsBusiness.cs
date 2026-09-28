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
        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTestsDataAccess.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }
    }
}
