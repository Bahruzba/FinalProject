using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Osahaneat.Data;
using Osahaneat.Models;

namespace Osahaneat.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        private RestaurantsContext context;
        public ProfileController()
        {
            context = new RestaurantsContext();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}