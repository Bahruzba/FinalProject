using Osahaneat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Osahaneat.ViewModels
{
    public class HomePage
    {
        public List<Restaurant> Restaurants { get; set; }
        public List<Meal> meals { get; set; }

    }
}