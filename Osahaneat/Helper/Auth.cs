using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Osahaneat.Data;

namespace Osahaneat.Helper
{
    public class Auth:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(HttpContext.Current.Session["user"]==null)
            {
                filterContext.Result = new RedirectResult("/login");
            }
            base.OnActionExecuting(filterContext);
        }

    }
}