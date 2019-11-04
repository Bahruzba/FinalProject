using System;
using System.Collections.Generic;
using System.Linq;
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
            Restaurant restaurant = context.Restaurants.Include("User").Include("Place").Include("Meals").FirstOrDefault(r=>r.Id==id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            List<string> categoryName = new List<string>();
            foreach (var meal in restaurant.Meals)
            {
                if (!categoryName.Contains(meal.Name))
                {
                    categoryName.Add(meal.Name);
                }
            }
            DetailPage detailPage = new DetailPage
            {
                Restaurant = restaurant,
                categoryName = categoryName
            };

            return View(detailPage);
        }
    }
}