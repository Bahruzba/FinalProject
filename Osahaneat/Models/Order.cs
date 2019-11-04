using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Osahaneat.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Xananı doldurun.")]
        [Range(0, 500, ErrorMessage = "Qiymət maximum 500 AZN ola bilər.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Xananı doldurun.")]
        public int MealId { get; set; }
        public Meal Meal { get; set; }
        [Required(ErrorMessage = "Xananı doldurun.")]
        public int OrderListId { get; set; }
        public OrderList OrderList { get; set; }

    }
}