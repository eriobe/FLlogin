using login_small.Data;
using login_small.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace login_small.Controllers
{
    public class AccountController : Controller
    {
        private DbOperations db = new DbOperations();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (db.CheckUserCredentials(model.Username, model.Password))
                {
                    // om man är inloggad sätt login cookie
                    FormsAuthentication.SetAuthCookie(model.Username, false);

                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Members", "Home");
                    }
                }
                else
                    ModelState.AddModelError("", "Felaktigt användarnamn eller lösenord");


            }
            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }

    
}