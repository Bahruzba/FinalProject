using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Osahaneat.Models
{
    public class Admin
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Xananı doldurun.")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}