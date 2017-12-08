using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyAppServices.Models;

namespace MyAppServices.Controllers
{
    public class prod : System.Web.Http.ApiController
    {
        static DataAccess dataA = new DataAccess();

        //Get all the restaurants information stored in the database
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/products")]
        public IEnumerable<Product> GetAllRestaurants()
        {
            return dataA.GetProduct();
        }
    }
}