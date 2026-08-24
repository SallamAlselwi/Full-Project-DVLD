using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using DVLD_DataAccess;

namespace DVLD_Business_Layer
{
    public class clsPeopleBusiness
    {
        enum _enPersonMode { Update, AddNew }

        public int PersonID { set;  get; }
        public string NationalNo { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }
        public string LastName { set; get; }
        public string FullName { get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; } }
        public DateTime DateOfBirth { set; get; }
        public byte Age { get { return Convert.ToByte(DateTime.Now.Year - DateOfBirth.Year); } }
        public byte Gender { set; get; }
        public string GenderTXT { 
            get
            {
                switch (Gender)
                {
                    case 0: return "Male";
                    case 1: return "Female";
                    default: return "Unknown";
                }
            } }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public int NationalityCountryID { set; get; }
        public clsCountriesBusiness CountryInfo {  set; get; } 
        public string ImagePath { set; get; }

        _enPersonMode Mode;

        public clsPeopleBusiness()
        {
            PersonID = -1;
            //NationalNo = "";
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            DateOfBirth = DateTime.Now;
            //Gender = 0;
            Address = "";
            Phone = "";
            Email = "";
            NationalityCountryID = -1;
            ImagePath = "";

            Mode = _enPersonMode.AddNew;
        }
        private clsPeopleBusiness(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName,
               string LastName, DateTime DateOfBirth, byte Gendor, string Address,
               string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.CountryInfo = clsCountriesBusiness.Find(NationalityCountryID);
            this.ImagePath = ImagePath;

            Mode = _enPersonMode.Update;
        }
        private bool _AddNewPerson()
        {
            PersonID = clsPeopleDataAccess.AddNewPerson(NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
                                                      Gender, Address, Phone, Email, NationalityCountryID, ImagePath);

            return (PersonID != -1);
        }
        private bool _UpdatePerson()
        {
            return clsPeopleDataAccess.UpdatePerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, 
                                                    LastName, DateOfBirth, Gender, Address, Phone, Email, 
                                                    NationalityCountryID, ImagePath);
        }
        
        public static clsPeopleBusiness Find(int PersonID)
         {
            int NationalityCountryID = -1;
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "",
                    LastName = "", Address = "", Phone = "", Email = "", ImagePath = "";
            DateTime DateOfBirth = new DateTime();
            byte Gender = 0;

            if (clsPeopleDataAccess.GetPersonByID(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName,
                   ref LastName, ref DateOfBirth, ref Gender, ref Address,
                   ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPeopleBusiness(PersonID, NationalNo, FirstName, SecondName, ThirdName,
                LastName, DateOfBirth, Gender, Address,
                Phone, Email, NationalityCountryID, ImagePath);
            }
            else
                return null;
         }
        public static clsPeopleBusiness Find(string NationalNo)
         {
            int NationalityCountryID = -1, PersonID = -1;
            string FirstName = "", SecondName = "", ThirdName = "",
                    LastName = "", Address = "", Phone = "", Email = "", ImagePath = "";
            DateTime DateOfBirth = new DateTime();
            byte Gender = 0;

            if (clsPeopleDataAccess.GetPersonByNationsal(NationalNo, ref PersonID, ref FirstName, ref SecondName, ref ThirdName,
                   ref LastName, ref DateOfBirth, ref Gender, ref Address,
                   ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))
            {
                return new clsPeopleBusiness(PersonID, NationalNo, FirstName, SecondName, ThirdName,
                                LastName, DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
                return null;
         }
        public bool Save()
        {
            switch (Mode)
            {
                case _enPersonMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = _enPersonMode.Update;
                        return true;
                    }
                    else
                        return false;

                case _enPersonMode.Update:
                    return _UpdatePerson() ;
            }

            return false;
        }
        static public async Task<DataTable> GetAllPeople()
        {
            return await clsPeopleDataAccess.GetAllPeople();
        }
        
        static public clsPeopleBusiness Full(DataRow row)
        {
            clsPeopleBusiness person = new clsPeopleBusiness();

            if(row != null) 
            {
                person.PersonID = (int)(row["PersonID"]);
                person.FirstName = row["FirstName"].ToString();
                person.SecondName = row["SecondName"].ToString();
                person.ThirdName = row["ThirdName"].ToString();
                person.LastName = row["LastName"].ToString();
                person.NationalNo = row["NationalNo"].ToString();
                person.Gender = (byte)row["Gender"];
                person.Email = row["Email"].ToString();
                person.Address = row["Address"].ToString();
                person.DateOfBirth = (DateTime)row["DateOfBirth"];
                person.Phone = row["Phone"].ToString();
                person.NationalityCountryID = (int)row["NationalityCountryID"];
                person.ImagePath = row["ImagePath"].ToString();
            }

            return person;
        }
      
        public static bool IsEmailFound(string Email)
        {
            return clsPeopleDataAccess.IsEmailExist(Email);
        }
        public static bool IsPersonExist(string NationsalNo)
        {
            return clsPeopleDataAccess.IsPersonExist(NationsalNo);
        }
        public static bool IsPersonExist(int PersonID)
        {
            return clsPeopleDataAccess.IsPersonExist(PersonID);
        }


    }
}
