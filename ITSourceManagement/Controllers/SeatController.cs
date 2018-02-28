using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITSourceManagement.ViewModel;
using ITSourceManagement.Models;

namespace ITSourceManagement.Controllers
{
    public class SeatController:Controller
    {
        public ActionResult Index()
        {
            SeatSourceViewModel model = new SeatSourceViewModel();
            List<SelectListItem> result = new List<SelectListItem>();
            List<string> list = new List<string>() {  "Heyi","Safs","Influx","ZAIS"};
            foreach(var item in list)
            {
                result.Add(new SelectListItem()
                { 
                         Text = item,
                         Value=item
                });
            }
            model.AllBelongs = result;
            for (var i = 0; i < 2;i++)
            {
                model.ComputerSources.Add(new ComputerSource() { Date = DateTime.Now});
            }
            return View(model);
        }

        //public JsonResult Save(SeatSourceViewModel model)
        //{

        //}
    }
}