using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using MyAppServices.Models;

namespace MyAppServices.Controllers
{
    public class CustomerController : System.Web.Http.ApiController
    {
        static DataAccess obj = new DataAccess();

        //Retrive customer information from database
        //Registering customers on the mobile application
        [System.Web.Http.HttpPost]
        //[Route("api/Register")]
        [System.Web.Http.Route("api/Regist")]
        public string PostCust(Customer cust)
        {
            if (cust != null)
            {
                return obj.AddCust(cust);
            }
            return "Unable to add";
        }


        //Login into the system
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/ClientsLogin")]
        public Customer GetCust(string email, string password)
        {
            return obj.CustomerLogin(email, password);
        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/ClientsUpdate")]
        public Customer PutCust(Customer cust , int id)
        {
            return obj.CustomerUpdate(cust,id);
        }
       
    }
}
