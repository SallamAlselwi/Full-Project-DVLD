using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsDrivers
    {
        public enum enMode { New=0, Update=1};
        public int DriverID;
        public int PersonID;
        public int CreatedByUserID;
        public DateTime CreatedDate;
        enMode Mode;

        public clsDrivers()
        {
            DriverID = 0;
            PersonID = 0;
            CreatedByUserID = 0;
            CreatedDate = DateTime.Now;

            this.Mode = enMode.New;
        }

        clsDrivers(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;

            this.Mode = enMode.Update;
        }
        public static async Task<DataTable> GetAllDrivers()
        {
            return await clsDriversData.GetAllDrivers();
        }
        bool _AddNew()
        {
            clsDrivers driver = FindByPersonID(this.PersonID);
            if (driver != null)
            {
                this.DriverID = driver.DriverID;
                this.PersonID = driver.PersonID;
                this.CreatedDate = driver.CreatedDate;
                this.CreatedByUserID = driver.CreatedByUserID;
                
                return true;
            }
            else
                this.DriverID = clsDriversData.AddNewDriver(this.PersonID, this.CreatedByUserID, this.CreatedDate);

            return (this.DriverID > 0) ? true : false;
        }
        bool _Update()
        {
            return clsDriversData.UpdateDriver(this.DriverID, this.PersonID, this.CreatedByUserID, this.CreatedDate);
        }
        public static bool IsExist(int DriverID)
        {
            return clsDriversData.IsExist(DriverID);
        }
        public static clsDrivers FindByDriverID(int DriverID)
        {           
            int PersonID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;
            if (clsDriversData.GetDriver(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))
            {
                return new clsDrivers(DriverID, PersonID, CreatedByUserID, CreatedDate);
            }
            else
                return null;
        }
        public static clsDrivers FindByPersonID(int PersonID)
        {           
            int DriverID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;
            if (clsDriversData.GetDriverByPersonID(ref DriverID, PersonID, ref CreatedByUserID, ref CreatedDate))
            {
                return new clsDrivers(DriverID, PersonID, CreatedByUserID, CreatedDate);
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
