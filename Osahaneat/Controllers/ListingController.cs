using Osahaneat.Data;
using Osahaneat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Osahaneat.ViewModels;

namespace Osahaneat.Controllers
{
    public class ListingController : Controller
    {
        // GET: Listing
        private readonly RestaurantsContext context;
        public ListingController()
        {
            context = new RestaurantsContext();
        }
        // GET: Home

        public ActionResult Index()
        {
            List<Meal> meals = context.Meals.Include("Restaurant.User").Include("CategoryMeal").Include("Kitchen").Include("Restaurant.Reviews").OrderByDescending(m => m.Orders.Count).Take(9).ToList();
            List<CategoryMeal> categoryMeals= context.CategoryMeals.OrderByDescending(m=>m.Meals.Count).Take(10).ToList();
            List<Restaurant> restaurants = context.Restaurants.Include("Reviews").Include("Comments").Include("Meals").Include("User").OrderByDescending(r => r.OrderList.Count).Take(10).ToList();
            List<Place> places = context.Places.Include("Restaurants").OrderByDescending(p => p.Restaurants.Count).ToList();
            List<Kitchen> kitchens = context.Kitchens.Include("Meals").OrderBy(k => k.Meals.Count).ToList();

            ListingPage MCRPK = new ListingPage
            {
                meals = meals,
                categoryMeals = categoryMeals,
                restaurants = restaurants,
                places = places,
                kitchens = kitchens
            };
            return View(MCRPK);
        }

        public ActionResult GetFilter(string restorans = "", string categories = "", string places = "", string kitchens = "", int count=0, string sort="")
        {
            List<int> restaurantList = new List<int>();
            List<int> categoryMeallist = new List<int>();
            List<int> placeList = new List<int>();
            List<int> kitchenList = new List<int>();
            if (restorans != "")
            {
                restaurantList = restorans.Split(',').Select(Int32.Parse).ToList();
            }
            if (categories != "")
            {
                categoryMeallist = categories.Split(',').Select(Int32.Parse).ToList();
            }
            if (places != "")
            {
                placeList = places.Split(',').Select(Int32.Parse).ToList();
            }
            if (kitchens != "")
            {
                kitchenList = kitchens.Split(',').Select(Int32.Parse).ToList();
            }
            List<Meal> meals = context.Meals.Include("Restaurant.User").Include("CategoryMeal").Include("Kitchen").Include("Restaurant.Reviews").Include("Restaurant.Comments")
                .Where(m=>(restorans == ""?true: restaurantList.Contains(m.RestaurantId))&&
                          (categories == ""?true: categoryMeallist.Contains(m.CategoryMealId))&&
                          (places == ""?true: placeList.Contains(m.Restaurant.PlaceId))&&
                          (kitchens == ""?true: kitchenList.Contains(m.KitchenId))
                )
                .OrderByDescending(m => m.Orders.Count).ToList();
            List<Meal> meals1 = meals;
            if (sort == "1")
            {
                meals1 = meals.OrderBy(m => m.Created).ToList();
            }
            if (sort == "2")
            {
                meals1 = meals.OrderBy(m => m.Price).ToList();
            }
            if (sort == "3")
            {
                meals1 = meals.OrderByDescending(m => m.Price).ToList();
            }

            var a = meals1.Skip(count).Take(9).Select(m => new { m.Id, m.Name, category=m.CategoryMeal.Name, kitchen= m.Kitchen.Name, restoran= m.Restaurant.User.FullName, m.Price, m.Restaurant.Reviews.Count, m.Restaurant.Reviews, m.Restaurant.Comments});

            string output = String.Empty;
            foreach (var item in a)
            {
                int rating = 0;
                foreach (var review in item.Reviews)
                {
                    rating += review.Rating;
                }
                        output += "<div id="+item.Id+" class='item-cover col-md-4 mt-4'>" +
                            "<div class='item'>"+
                                "<div class='img'>"+
                                    "<a href = '#'>"+
                                        "<img src='/Public/img/slider.png' alt=''>"+
                                        "<span class='promoted'>Promoted</span>"+
                                        "<i class='fas fa-heart'></i>"+
                                        "<span class='text-center reating'><i class='fas fa-star'></i> "+(item.Reviews.Count!=0? (rating / item.Reviews.Count).ToString("0.0"):"0 (0)") +" </span>"+
                                    "</a>"+
                                "</div>"+
                                "<div class='under-image'>" +
                                    "<a class='name-meal' href='#'>"+item.Name+"</a>" +
                                    "<p class='about-meal'>• "+item.restoran + "</p>" +
                                    "<p class='about-meal'>• "+item.kitchen+" </p>" +
                                    "<p class='about-meal'>• "+item.category+" </p>" +
                                    "<span class='time-delivery'><i class='far fa-clock'></i> 20-25 min</span> <span price="+item.Price+" class='priece-delivery'>"+item.Price.ToString("0.00")+" AZN</span>" +
                                    "<p class='cupon'>" +
                                        "<span class='px-2'>OFFER</span> 65% off | Use Coupon OSAHAN50" +
                                    "</p>" +
                                "</div>" +
                            "</div>" +
                        "</div>";
            }

            return Content(output);
        }
    }
}