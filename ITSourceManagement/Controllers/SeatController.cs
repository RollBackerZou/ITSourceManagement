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
        SQLContext sqlContext = new SQLContext();
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
            model.Date = DateTime.Now;
            model.AllBelongs = result;
            for (var i = 0; i < 2;i++)
            {
                model.ComputerSources.Add(new ComputerSource() { Date = DateTime.Now});
            }
            return View(model);
        }

        public JsonResult Save(SeatSourceViewModel model)
        {
            JsonResult result = new JsonResult();
           
            //sqlContext.Database.CreateIfNotExists(); 

            SeatSource seatSource = new SeatSource();
            seatSource.SeatNo = model.SeatNo;
            seatSource.Number = model.Number;
            seatSource.Date = model.Date;
            seatSource.Belongs = model.Belongs;
            seatSource.ComputerSources = model.ComputerSources;

            sqlContext.SeatSources.Add(seatSource);
            int code = sqlContext.SaveChanges();
            result.Data = code;
            return Json(result);
        }

        public ActionResult List()
        {
            var data = sqlContext.SeatSources;
            var result = data
                //.Where(m => m.SeatNo == "A11")
                .ToList();
            PagerInfo pager = new PagerInfo();
            pager.CurrentPageIndex = 1;
            pager.PageSize = 5;
            pager.RecordCount = result.Count;
            
            var rel = new PageNavigationHelp<SeatSource>(pager,result);
            return View(rel);
        }
    }
}