using System;
using System.Collections.Generic;
using System.Linq;
<<<<<<< HEAD
=======
using System.Data.Entity;
>>>>>>> change reviews structure
using System.Web;
using System.Web.Mvc;
using Osahaneat.Models;
using Osahaneat.Data;
using Osahaneat.ViewModels;

namespace Osahaneat.Controllers
{
    public class DetailController : Controller
    {
        // GET: Detail
        private RestaurantsContext context;
        public DetailController()
        {
            context = new RestaurantsContext();
        }
        public ActionResult Index(int id)
        {
<<<<<<< HEAD
            Restaurant restaurant = context.Restaurants.Include("User").Include("Place").Include("Meals").Include("Meals.CategoryMeal").Include("Reviews").Include("Comments").FirstOrDefault(r=>r.Id==id);
=======
            Restaurant restaurant = context.Restaurants
                .Include(r => r.User)
                .Include(r => r.Place)
                .Include(r => r.Meals)
                .Include("Meals.CategoryMeal")
                .Include("Meals.Reviews")
                .FirstOrDefault(r => r.Id == id);
>>>>>>> change reviews structure
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            List<string> categoryName = new List<string>();
            List<CategoryMeal> catMeal = new List<CategoryMeal>();

            foreach (var meal in restaurant.Meals)
            {
                if (!categoryName.Contains(meal.Name))
                {
                    categoryName.Add(meal.Name);
                    catMeal.Add(meal.CategoryMeal);

                }
            }
            DetailPage detailPage = new DetailPage
            {
                Restaurant = restaurant,
                categoryMeal = catMeal
            };
<<<<<<< HEAD

=======
>>>>>>> change reviews structure
            return View(detailPage);
        }
    }
}