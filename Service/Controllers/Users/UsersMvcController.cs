using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThingsWeNeed.Service.Controllers.Users
{
    [Authorize]
    [RoutePrefix("Users")]
    public class UsersMvcController : Controller
    {
        [AllowAnonymous]
        [Route("login")]
        public ActionResult Login()
        {
            return View("Login");
        }

        [AllowAnonymous]
        [Route("register")]
        public ActionResult Register()
        {
            return View("Register");
        }
    }
}