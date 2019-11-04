using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Osahaneat.Models
{
    public class Meal
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Xananı doldurun.")]
        [MaxLength(50, ErrorMessage = "Maximum 50 xaratket yaza bilərsiz.")]
        [MinLength(2, ErrorMessage = "Minimum 2 xaratket yaza bilərsiz.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Xananı doldurun.")]
        [Range(0,500, ErrorMessage ="Qiymət maximum 500 AZN ola bilər.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Xananı doldurun.")]
        [Range(0, 500, ErrorMessage = "Say maximum 500 ola bilər.")]
        public int Count { get; set; }
        [Required(ErrorMessage = "Xananı doldurun.")]
        public DateTime Created { get; set; }
        [Required(ErrorMessage = "Xananı doldurun.")]
        public int KitchenId { get; set; }
        public Kitchen Kitchen { get; set; }
        [Required(ErrorMessage = "Xananı doldurun.")]
        public int CategoryMealId { get; set; }
        public CategoryMeal CategoryMeal { get; set; }
        [Required(ErrorMessage = "Xananı doldurun.")]
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public List<Order> Orders { get; set; }
        public List<Review> Reviews { get; set; }

    }
}