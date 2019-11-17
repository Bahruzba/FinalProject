using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Osahaneat.Data;
using Osahaneat.Models;

namespace Osahaneat.Controllers
{
    public class DATAController : Controller
    {
        // GET: DATA
        private readonly RestaurantsContext context;
        public DATAController()
        {
            context = new RestaurantsContext();
        }
        public ActionResult Index()
        {
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                if (i % 5 == 0)
                {
                    CategoryMeal categoryMeal = new CategoryMeal
                    {
                        Name= "Yemek Movu "+(i/5+1),
                        Created= DateTime.Now
                    };
                    context.CategoryMeals.Add(categoryMeal);
                    context.SaveChanges();

                    Kitchen kitchen = new Kitchen
                    {
                        Name = "Italyan metbexti " + (i/5+1)
                    };
                    context.Kitchens.Add(kitchen);
                    context.SaveChanges();

                    Place place = new Place
                    {
                        Name = "Baki " + (i / 5 + 1)
                    };
                    context.Places.Add(place);
                    context.SaveChanges();

                    User user = new User
                    {
                        FullName = "Ad Soyad " +i,
                        PhoneNumber = "05569655" + i.ToString("00"),
                        Created = DateTime.Now,
                        UserName = "restoran@info.az",
                        UserType = UserType.restaurant,
                        IsActived = true
                    };
                    context.Users.Add(user);
                    context.SaveChanges();

                    Restaurant restaurant = new Restaurant
                    {   
                        PlaceId=place.Id,
                        UserId=user.Id,
                        HolidayOfWeek="SunSat",
                        OpenHours=9,
                        ClooseHours=22,
                        Address="Allaha sukur butun metrolarin yanindayix"
                    };
                    context.Restaurants.Add(restaurant);
                    context.SaveChanges();

                    User user1 = new User
                    {
                        FullName = "Ad Soyad " + i,
                        PhoneNumber = "05569655" + i.ToString("00"),
                        Created = DateTime.Now,
                        UserName = "musteri@info.az",
                        UserType = UserType.customer,
                        IsActived = true
                    };
                    context.Users.Add(user1);
                    context.SaveChanges();

                    Customer customer = new Customer
                    {
                        UserId=user1.Id
                    };
                    context.Customers.Add(customer);
                    context.SaveChanges();

                    User user2 = new User
                    {
                        FullName = "Admin " + i,
                        PhoneNumber = "05569655" + i.ToString("00"),
                        Created = DateTime.Now,
                        UserName = "admin@info.az",
                        UserType = UserType.admin,
                        IsActived = true
                    };
                    context.Users.Add(user2);
                    context.SaveChanges();
                    Admin admin = new Admin
                    {
                        UserId = user2.Id,
                    };
                    context.Admins.Add(admin);
                    context.SaveChanges();

                    Review review = new Review
                    {
                        Rating = 4,
                        RestaurantId = restaurant.Id,
                        CustomerId = customer.Id

                    };
                    context.Reviews.Add(review);
                    context.SaveChanges();
                }

                Meal meal = new Meal
                {
                    Name = "Burger " + (i+1),
                    Price = rnd.Next(1000,20000)/100,
                    Count = rnd.Next(5, 30),
                    Created = DateTime.Now,
                    KitchenId = (i - i % 5) / 5 + 1,
                    CategoryMealId = (i - i % 5) / 5 + 1,
                    RestaurantId = (i-i%5)/5+1
                };
                context.Meals.Add(meal);
                context.SaveChanges();

                Comment comment = new Comment
                {
                    RestaurantId = (i - i % 5) / 5 + 1,
                    CustomerId= (i - i % 5) / 5 + 1,
                    Context="Sagolsunlar tez catdirillar."
                };
                context.Comments.Add(comment);
                context.SaveChanges();
            }
            return View();
        }

        public ActionResult Order()
        {
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                OrderList Orderlist = new OrderList
                {
                    Price = rnd.Next(1000, 20000) / 100,
                    Created = DateTime.Now,
                    RestaurantId = i + 1,
                    CustomerId = i + 1
                };
                context.OrderLists.Add(Orderlist);
                context.SaveChanges();
                for (int j = 0; j < 10; j++)
                {
                    Order order = new Order
                    {
                        Price = rnd.Next(1000, 20000) / 100,
                        MealId = j + 1,
                        OrderListId = Orderlist.Id
                    };
                    context.Orders.Add(order);
                    context.SaveChanges();
                }

            }

            return View();
        }
    }
}