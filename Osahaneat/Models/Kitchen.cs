using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Osahaneat.Models
{
    public class Kitchen
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Meal> Meals { get; set; }
    }
}