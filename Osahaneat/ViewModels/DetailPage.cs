using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Osahaneat.Models;

namespace Osahaneat.ViewModels
{
    public class DetailPage
    {
        public Restaurant Restaurant { get; set; }
        public List<CategoryMeal> categoryMeal { get; set; }

    }
}