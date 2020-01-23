using Osahaneat.Data;
using Osahaneat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
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
            List<Restaurant> restaurants = context.Restaurants
            .Include(r => r.User)
            .Include(r => r.Meals)
            .OrderByDescending(m => m.Meals.Count).Take(10).ToList();
            List<Meal> meals = context.Meals
                .Include(m=>m.Restaurant.User)
                .Include(m => m.CategoryMeal)
                .Include(m => m.Reviews)
                .Include(m => m.Kitchen)
                .OrderByDescending(m => m.Orders.Count).Take(9).ToList();

            HomePage CR = new HomePage
            {
                meals=meals,
                Restaurants=restaurants
            };

            return View(CR);
        }
    }
}