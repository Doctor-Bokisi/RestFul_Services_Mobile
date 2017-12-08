using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using MyAppServices.Models;

namespace MyAppServices.Controllers
{
    public class Restuarant : ApiController
    {
        static DataAccess dataA = new DataAccess();

        //Get all the restaurants information stored in the database
        [System.Web.Mvc.HttpGet]
        [Route("api/Restaurants")]
        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return dataA.GetRestaurant();
        }
    }
}
