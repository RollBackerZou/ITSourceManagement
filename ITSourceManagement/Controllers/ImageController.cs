using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace ITSourceManagement.Controllers
{
    public class ImageController : Controller
    {
        //
        // GET: /Image/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload()
        {
            var file = Request.Files["UploadImage"];
            if(file==null||file.ContentLength==0)
            {
                return Content("请重新选择一张照片");
            }
            var path = Server.MapPath("~/Upload/Image");
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string name = DateTime.Now.ToString("yyyyMMddHHmmss")+".png";
            string uploadPath = Path.Combine(path,name);
            file.SaveAs(uploadPath);
            return Content("上传成功");
        }
    }
}
