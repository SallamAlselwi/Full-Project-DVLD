using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsReports
    {
        static public async Task<DataTable> GetApplicationReports()
        {
            return await clsReportsData.GetApplicationReports();
        }
        static public async Task<DataTable> GetDriversReports()
        {
            return await clsReportsData.GetDriversReports();
        }
    }
}
