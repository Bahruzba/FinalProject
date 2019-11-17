using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Osahaneat.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Context { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}