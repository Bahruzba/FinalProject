using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Osahaneat.Areas.Admin.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Admin/Restaurant
        public ActionResult Index()
        {
            return View();
        }
    }
}