using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITSourceManagement.ViewModel;
using ITSourceManagement.Models;
using Aspose.Cells;
using System.IO;

namespace ITSourceManagement.Controllers
{
    public class SeatController : Controller
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        SQLContext sqlContext = new SQLContext();
        public ActionResult Index()
        {
            SeatSourceViewModel model = new SeatSourceViewModel();
            List<SelectListItem> result = new List<SelectListItem>();
            List<string> list = new List<string>() { "Heyi", "Safs", "Influx", "ZAIS" };
            foreach (var item in list)
            {
                result.Add(new SelectListItem()
                {
                    Text = item,
                    Value = item
                });
            }
            model.Date = DateTime.Now;
            model.AllBelongs = result;
            for (var i = 0; i < 2; i++)
            {
                model.ComputerSources.Add(new ComputerSource() { Date = DateTime.Now });
            }
            return View(model);
        }

        public JsonResult Save(SeatSourceViewModel model)
        {
            JsonResult result = new JsonResult();

            sqlContext.Database.CreateIfNotExists(); 

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

            var rel = new PageNavigationHelp<SeatSource>(pager, result);
            return View(rel);
        }

        [HttpGet]
        public ActionResult UploadExcel()
        {
            log.Info("UploadExcel");
            return View();
        }

        [HttpPost]
        public ActionResult UploadExcel(HttpPostedFileBase ff)
        {
            var file = Request.Files["UploadExcel"];
            if (file == null || file.ContentLength <= 0)
            {
                return Json(null);
            }
            var fileStream = file.InputStream;
            var workBook = new Workbook(fileStream);
            var cells = workBook.Worksheets[0].Cells;
            var x = cells[0].StringValue;
            return RedirectToAction("UploadExcel");
        }

        public FileResult Download()
        {
            var allData = sqlContext.SeatSources.ToList();
            var templatePath = Server.MapPath(@"~\Content\Template\SeatInfo.xlsx");
            Workbook wk = new Workbook(templatePath);
            Worksheet ws = wk.Worksheets[0];
            if (allData.Count == 0)
            {
                MemoryStream msEmpty = new MemoryStream();
                wk.Save(msEmpty, Aspose.Cells.SaveFormat.Xlsx);
                msEmpty.Position = 0;
                return File(msEmpty, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }

            for (var i = 0; i < allData.Count; i++)
            {
                ws.Cells[i + 1, 0].PutValue(allData[i].SeatNo);
                ws.Cells[i + 1, 1].PutValue(allData[i].Date);
                ws.Cells[i + 1, 2].PutValue(allData[i].Belongs);
                for (var j = 0; j < allData[i].ComputerSources.Count; j++)
                {
                    var computerSource = allData[i].ComputerSources.ToList();
                    ws.Cells[i + 1, 3 + j * 3].PutValue(computerSource[j].Number);
                    ws.Cells[i + 1, 4 + j * 3].PutValue(computerSource[j].Date);
                    ws.Cells[i + 1, 5 + j * 3].PutValue(computerSource[j].Belongs);
                }
            }
            MemoryStream ms = new MemoryStream();
            wk.Save(ms, Aspose.Cells.SaveFormat.Xlsx);
            ms.Position = 0;
            return File(ms, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
    }
}