using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITSourceManagement.Controllers
{
    public class RedisController : Controller
    {
        //
        // GET: /Redis/
      
        public ActionResult Index()
        {
            //System.Diagnostics.Process.Start(@"");开启redis服务
            return View();
        }

        [HttpPost]
        public ActionResult SaveAll()
        {
            using(var redisClient = RedisManager.GetClient())
            {
                var user = redisClient.GetTypedClient<User>();
                #region
                if (user.GetAll().Count>0)
                {
                    user.DeleteAll();
                }

                var qiujialong = new User
                {
                    Id = user.GetNextSequence(),
                    Name = "qiujialong",
                    Job = new Job { Position = ".NET" }
                };
                var chenxingxing = new User
                {
                    Id = user.GetNextSequence(),
                    Name = "chenxingxing",
                    Job = new Job { Position = ".NET" }
                };
                var luwei = new User
                {
                    Id = user.GetNextSequence(),
                    Name = "luwei",
                    Job = new Job { Position = ".NET" }
                };
                var zhourui = new User
                {
                    Id = user.GetNextSequence(),
                    Name = "zhourui",
                    Job = new Job { Position = "Java" }
                };
                #endregion
                var usertoStore = new List<User> { qiujialong, chenxingxing, luwei, zhourui };
                user.StoreAll(usertoStore);
                 return Content("目前共有：" + user.GetAll().Count.ToString() + "人！");
            }

           
        }

        public ActionResult SaveOne()
        {
            return Content("");
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Job Job { get; set; }
    }
    public class Job
    {
        public string Position { get; set; }
    }
}
