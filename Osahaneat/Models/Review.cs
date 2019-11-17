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
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}