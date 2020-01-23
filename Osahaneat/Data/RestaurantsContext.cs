using Osahaneat.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Osahaneat.Data
{
    public class RestaurantsContext : DbContext
    {
        public RestaurantsContext() : base("RestaurantsContext") { }

        public DbSet<CategoryMeal> CategoryMeals { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderList> OrderLists { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Kitchen> Kitchens { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Review> Reviews { get; set; }
<<<<<<< HEAD
        public DbSet<Comment> Comments { get; set; }
=======
>>>>>>> change reviews structure
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}