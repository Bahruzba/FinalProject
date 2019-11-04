using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Osahaneat.Models
{
    public class CategoryMeal
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Xananı doldurun.")]
        [MaxLength(30,ErrorMessage ="Maximum 30 xaratket yaza bilərsiz.")]
        [MinLength(2,ErrorMessage ="Minimum 2 xaratket yaza bilərsiz.")]
        public string Name { get; set; }
        public List<Meal> Meals { get; set; }
        [Required(ErrorMessage = "Xananı doldurun.")]
        public DateTime Created { get; set; }
    }
}