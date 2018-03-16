using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITSourceManagement.Models;
using ITSourceManagement.ViewModel;
using System.Text;

namespace ITSourceManagement.Controllers
{
    public class ShopController : Controller
    {
        //
        // GET: /Shop/
        SQLContext sqlContext = new SQLContext();
        public ActionResult Index(string bbGenre)
        {
            var list = sqlContext.Products.ToList();
            return View(list);
        }

        public ActionResult PutCar(int id)
        {
            //if (Session["UserName"] == null)
            //    return RedirectToAction("Login","Account");
            var product = sqlContext.Products.Find(id);
            HttpCookie cookies = new HttpCookie("shopcar");
            cookies.Values.Add(id.ToString(),id.ToString());
            Response.Cookies.Add(cookies);
            return RedirectToAction("Index");
        }
        public ActionResult ShopCar()
        {
            List<ShopCarViewModel> model = new List<ShopCarViewModel>();
            StringBuilder sb = new StringBuilder();
            if(Request.Cookies["shopcar"]!=null)
            {
                HttpCookie cookie = Request.Cookies["shopcar"];
                for (var i = 0; i < cookie.Values.Count;i++)
                {
                    sb.Append(cookie.Values.AllKeys[i]+",");
                }
            }

            string[] strs = sb.ToString().Split(',');
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Add()
        //{
            
        //}

        private int AddData()
        {
            var xx = sqlContext.Products.ToList();
            sqlContext.Products.RemoveRange(xx);
            sqlContext.SaveChanges();
            List<Product> products = new List<Product>();
            for (var i = 1; i <= 3; i++)
            {
                products.Add(new Product()
                {
                    Id = i,
                    Description = "商品" + i,
                    Price = i * 100,
                    Genre = "all",
                    Title = "标题" + i,
                    ReleaseDate = DateTime.Today,
                    Photo = @"../Upload/ShopImage/" + i + ".png",
                });
            }

            sqlContext.Products.AddRange(products);
            return sqlContext.SaveChanges();
        }
    }
}
