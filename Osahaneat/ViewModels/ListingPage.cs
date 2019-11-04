using Osahaneat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Osahaneat.ViewModels
{
    public class ListingPage
    {
        public List<Meal> meals { get; set; }
        public List<CategoryMeal> categoryMeals { get; set; }
        public List<Restaurant> restaurants { get; set; }
        public List<Place> places { get; set; }
        public List<Kitchen> kitchens { get; set; }
    }
}