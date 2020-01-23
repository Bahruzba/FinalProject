using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Osahaneat.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Xananı doldurun.")]
        [MaxLength(21)]
        public string HolidayOfWeek { get; set; }
        [Required(ErrorMessage = "Xananı doldurun.")]
        [Range(0,25,ErrorMessage ="0-24 arasında dəyər yaza bilərsiz.")]
        public int OpenHours { get; set; }
        [Range(0, 25, ErrorMessage = "0-24 arasında dəyər yaza bilərsiz.")]
        public int ClooseHours { get; set; }
        [Required(ErrorMessage = "Xananı doldurun.")]
        [MaxLength(50, ErrorMessage = "Maximum 50 xaratket yaza bilərsiz.")]
        [MinLength(10, ErrorMessage = "Minimum 10 xaratket yaza bilərsiz.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Xananı doldurun.")]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required(ErrorMessage = "Xananı doldurun.")]
        public int PlaceId { get; set; }
        public Place Place { get; set; }
        public List<Meal> Meals { get; set; }
        public List<OrderList> OrderList { get; set; }
    }
}