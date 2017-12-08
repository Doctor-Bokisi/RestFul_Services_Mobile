using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyAppServices.Models;

namespace MyAppServices.Controllers
{
    public class ResController : System.Web.Http.ApiController
    {
        static DataAccess dataA = new DataAccess();

        //Get all the restaurants information stored in the database
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Restaurants")]
        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return dataA.GetRestaurant();
        }
    }
}
