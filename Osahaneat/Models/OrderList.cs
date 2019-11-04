using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Osahaneat.Models
{
    public class OrderList
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Xananı doldurun.")]
        [Range(0, 10000, ErrorMessage = "Məbləğ maximum 10 000 AZN ola bilər.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Xananı doldurun.")]
        public DateTime Created { get; set; }
        [Required(ErrorMessage = "Xananı doldurun.")]
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        [Required(ErrorMessage = "Xananı doldurun.")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<Order> Orders { get; set; }
    }
}