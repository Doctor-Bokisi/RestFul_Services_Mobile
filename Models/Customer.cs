using System;





namespace MyAppServices.Models
{
    public class Customer
    {

        public int CustId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string password { get; set; }


        public Customer(string email, string Password,string mobile, string firstname, string lastname)
        {
            Email = email;
            password = password;
            Firstname = firstname;
            Lastname = lastname;
            Mobile = mobile;
        }

        public Customer()
        {

        }

        public Customer(int ID, string email,string mobile, string Password, string firstname, string lastname)
        {
            CustId = ID;
            Email = email;
            password = password;
            Firstname = firstname;
            Lastname = lastname;
            Mobile = mobile;

        }

        public Customer( string mobile, string firstname, string lastname)
        {
          
            Firstname = firstname;
            Lastname = lastname;
            Mobile = mobile;

        }


    


    }
}

