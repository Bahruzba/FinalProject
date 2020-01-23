using Osahaneat.Data;
using Osahaneat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
<<<<<<< HEAD
=======
using System.Data.Entity;
>>>>>>> change reviews structure
using System.Web.Mvc;
using Osahaneat.ViewModels;

namespace Osahaneat.Controllers
{
    public class HomeController : Controller
    {
        private readonly RestaurantsContext context;
        public HomeController()
        {
            context = new RestaurantsContext();
        }
        // GET: Home
        public ActionResult Index()
        {
            List<Restaurant> restaurants = context.Restaurants.Include("User").Include("Meals").OrderByDescending(m => m.Meals.Count).Take(10).ToList();
<<<<<<< HEAD
            List<Meal> meals = context.Meals.Include("Restaurant.User").Include("CategoryMeal").Include("Restaurant.Reviews").Include("Kitchen").OrderByDescending(m => m.Orders.Count).Take(9).ToList();

            //return Content(meals[1].ToString());
=======
            List<Meal> meals = context.Meals
                .Include(m=>m.Restaurant.User)
                .Include(m => m.CategoryMeal)
                .Include(m => m.Reviews)
                .Include(m => m.Kitchen)
                .OrderByDescending(m => m.Orders.Count).Take(9).ToList();

>>>>>>> change reviews structure
            HomePage CR = new HomePage
            {
                meals=meals,
                Restaurants=restaurants
            };

            return View(CR);
        }
    }
}