using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ITSourceManagement
{
    public class BaseController:Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            string userName = Session["UserName"] as string;

            if(String.IsNullOrEmpty(userName))
            {
                filterContext.Result = RedirectToAction("Login","Account");
                return;
            }
        }
    }
}