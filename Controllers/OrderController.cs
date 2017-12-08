using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using MyAppServices.Models;

namespace MyAppServices.Controllers
{
    public class OrderController : ApiController
    {
        static DataAccess dataA = new DataAccess();

        //Get all the restaurants information stored in the database
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Order")]
        public string paymnets(Order order)
        {
            return dataA.Orders(order);
        }
    }
}
