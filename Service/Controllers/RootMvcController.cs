using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThingsWeNeed.Service.Controllers
{
    public class RootMvcController : Controller
    {
        [Route] //  Root route
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("All", "ThingsMvc");
            } 
            else
            {
                return RedirectToAction("Login", "UsersMvc");
            }
        }
    }
}