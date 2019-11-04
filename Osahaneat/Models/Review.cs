﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Osahaneat.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get; set; }
    }
}