using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITSourceManagement.Controllers
{
    public class ManageController : Controller
    {
        //
        // GET: /Manage/

        public ActionResult Index()
        {
            //System.Web.Security.FormsAuthentication.SetAuthCookie
            return View();
        }

    }
}
