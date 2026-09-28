using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using DVLD_DataAccess;
using System.Xml.Linq;
using System.Runtime.CompilerServices;

namespace DVLD_Business_Layer
{
    public class clsUsersBusines
    {
        public enum enUserMode {New, Update }
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public clsPeopleBusiness Person {  get; set; }
        public enUserMode Mode { get; set; }
        public clsUsersBusines()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.IsActive = false;
            this.Person = new clsPeopleBusiness();

            this.Mode = enUserMode.New;
        }
        public clsUsersBusines(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;

            Person = clsPeopleBusiness.Find(PersonID);

            this.Mode = enUserMode.Update;
        }
        static public clsUsersBusines GetUserByUserNameAndPassword(string UserName, string Password)
        {
            DataRow dr = clsUsersDataAccess.GetUserByUserNameAndPassword(UserName, Password);
            if(dr != null)
            {
                return new clsUsersBusines(int.Parse(dr["UserID"].ToString()), int.Parse(dr["PersonID"].ToString()), dr["UserName"].ToString(),
                    dr["Password"].ToString(), Convert.ToBoolean(dr["IsActive"].ToString()));
            }
            else
            {
                return null;
            }
        }
        static async public Task<DataTable> GetAllUsers()
        {
            return await clsUsersDataAccess.GetAllUsers();

        }
        static async public Task<DataTable> GetUsersReport()
        {
            return await clsUsersDataAccess.GetUsersReport();

        }
        bool _AddNewUser()
        {
            this.PersonID = this.Person.PersonID;

            this.UserID = clsUsersDataAccess.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);

            return (this.UserID > 0);
        }
        bool _UpdateUser()
        {
            return clsUsersDataAccess.UpdateUser(this.UserID, this.UserName, this.Password, this.IsActive);
        }
        public static clsUsersBusines Find(int UserID)
        {
            int PersonID = -1;
            string UserName = "", Password = "";
            bool IsActive = false;
            
            if(clsUsersDataAccess.GetUser(UserID, ref PersonID, ref UserName, ref Password, ref IsActive))
            {
                return new clsUsersBusines(UserID, PersonID, UserName, Password, IsActive);
            }
            else { return null; }
        }
        public static bool IsUserExist(string NationsalNo)
        {
            return clsUsersDataAccess.IsUserExist(NationsalNo);
        }
        public static bool IsUserExist(int PersonID)
        {
            return clsUsersDataAccess.IsUserExist(PersonID);
        }
        public static bool IsUserNameExist(string UserName)
        {
            return clsUsersDataAccess.IsUserNameExist(UserName);
        }
        public bool Save()
        {
            bool IsSuccessful = false;

            switch (this.Mode)
            {
                case enUserMode.New: 
                    if (_AddNewUser()){
                        this.Mode = enUserMode.Update;
                        IsSuccessful = true;
                    }
                    else
                    {
                        IsSuccessful = false;
                    }
                    break;

                case enUserMode.Update: 
                    IsSuccessful = _UpdateUser(); break;

                    default: return false;
            }

            return IsSuccessful;
        }
        public bool ChangePassword(string NewPassword, string ConfirmPassword)
        {
            if(NewPassword == ConfirmPassword)
            {
                return clsUsersDataAccess.ChangePassword(this.UserID, ConfirmPassword);
            }
            else
            {
                return false;
            }
        }

        

    }
}
