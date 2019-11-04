using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Osahaneat.Models
{
    public enum UserType
    {
        admin, restaurant, customer
    }
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Xananı doldurun.")]
        [MaxLength(30, ErrorMessage = "Maximum 30 xaratket yaza bilərsiz.")]
        [MinLength(2, ErrorMessage = "Minimum 2 xaratket yaza bilərsiz.")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Xananı doldurun.")]
        [MaxLength(10, ErrorMessage = "Telefon nömrəsi 10 rəqəmli olmalıdır.")]
        [MinLength(10, ErrorMessage = "Telefon nömrəsi 10 rəqəmli olmalıdır.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Xananı doldurun.")]
        [MaxLength(50, ErrorMessage = "Maximum 50 xaratket yaza bilərsiz.")]
        [MinLength(10, ErrorMessage = "Minimum 10 xaratket yaza bilərsiz.")]
        public string UserName { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        [MaxLength(50, ErrorMessage = "Maximum 50 xaratket yaza bilərsiz.")]
        public string Token { get; set; }
        [Required(ErrorMessage = "Xananı doldurun.")]
        public DateTime Created { get; set; }
        public List<OrderList> OrderLists { get; set; }
        [Required]
        public bool IsActived { get; set; }
        public UserType UserType { get; set; }
    }
}