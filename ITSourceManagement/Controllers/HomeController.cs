using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITSourceManagement.Models;
using System.Web.Security;

namespace ITSourceManagement.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        //[Authorize(Roles = "Add")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public ActionResult LoginCheck(LoginModel model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            string result = model.Login();
            if(result == null)
            {
                return View();
            }

            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1,model.UserName,DateTime.Now,DateTime.Now.AddHours(24),model.RememberMe,result);
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName,encryptedTicket);
            Response.Cookies.Add(authCookie);

            Response.Redirect("/Home",true);
            return new EmptyResult();
        }

    }
}
