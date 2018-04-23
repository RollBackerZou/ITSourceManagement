using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITSourceManagement.Controllers
{
    public class PrimaryController : Controller
    {
        public PrimaryController()
        {
            if(HttpContext==null)
            {
                System.Web.HttpContext.Current.Session["StartTime"] = DateTime.Now;
            }
            //if(HttpContext.Session["StartTime"]==null)
            //{
            //    System.Web.HttpContext.Current.Session["StarTime"] = DateTime.Now;               
            //}
        }

    }
}
