using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using MyAppServices.Models;

namespace MyAppServices.Controllers
{
    public class PaymentController : ApiController
    {
        static DataAccess dataA = new DataAccess();

        //Get all the restaurants information stored in the database
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/pay")]
        public string paymnets(Payment pay)
        {
            return dataA.payments(pay);
        }
    }
}
