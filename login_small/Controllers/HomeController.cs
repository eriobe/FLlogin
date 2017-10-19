using login_small.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace login_small.Controllers
{
    // För att detta ska fungera måste man lägga till kod i web.config
    /*
     * system.web
     * 
     *     <authentication mode="Forms">
      <forms loginUrl="~/Account/Login"
             defaultUrl="~/Home/Welcome">
      </forms>
    </authentication>
    */
     
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AuthorizeRoles("Admin","Medlem")]

        public ActionResult Contact()
        {
            ViewBag.Message = "Endast administratörer.";

            return View();
        }

        [Authorize]
        public ActionResult Members()
        {
            return View();
        }


    }
}
 