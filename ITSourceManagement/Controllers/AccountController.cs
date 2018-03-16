using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITSourceManagement.ViewModel;
using ITSourceManagement.Models;
using System.Threading.Tasks;

namespace ITSourceManagement.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        SQLContext allData = new SQLContext();
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new AppUser { UserName = model.UserName,PassWord = model.PassWord,Email = model.Email};
                allData.Users.Add(user);
                int code = allData.SaveChanges();
                if(code>0)
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    return Content("注册保存失败");
                }
            }
            else
            {
                return Content("注册信息填写有误导致失败");
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            var user = allData.Users
                .Where(m => m.UserName == model.UserName).FirstOrDefault();
            if(user == null)
            {
                return Content("No this User");
            }
            if(user.PassWord == model.PassWord)
            {
                Session["UserName"] = model.UserName;
                return RedirectToAction("Index","Home");
            }
            else
            {
                return Content("登录失败");
            }
        }

        public ActionResult ResetPsw(string userName)
        {
            ResetPswViewModel output = new ResetPswViewModel();
            var user = allData.Users.Where(m => m.UserName == userName).FirstOrDefault();
            if(user == null)
            {
                return Content("没有这个用户");
            }
            output.UserName = user.UserName;
            output.PassWord = user.PassWord;
            return View(output);
        }

        [HttpPost]
         public ActionResult ResetPsw(ResetPswViewModel model)
        {
            var user = allData.Users.Where(m => m.UserName == model.UserName).FirstOrDefault();
            if (user == null)
            {
                return Content("没有这个用户");
            }

            user.PassWord = model.NewPassWord;
            int code = allData.SaveChanges();
            return RedirectToAction("Login","Account");
        }

        public ActionResult ForgetPsw()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult ForgetPsw(ForgotPasswordViewModel model)
        //{
        //    EmailService es = new EmailService();
            
        //}
    }
}
