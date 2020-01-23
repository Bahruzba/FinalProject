using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Osahaneat.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Xananı doldurun.")]
        public int UserId { get; set; }
        public User User { get; set; }
        public List<OrderList> OrderLists { get; set; }
<<<<<<< HEAD
        public List<Comment> Comments { get; set; }
=======
>>>>>>> change reviews structure
        public List<Review> Reviews { get; set; }
    }
}