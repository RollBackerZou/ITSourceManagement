using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ITSourceManagement.Models
{
    public class LoginModel
    {
        [DisplayName("用户名")]
        [Required(ErrorMessage="用户名不能为空")]
        public string UserName { get; set; }

        [DisplayName("密码")]
        [Required(ErrorMessage = "密码不能为空")]
        public string PassWord { get; set; }
        
        [DisplayName("记住登录")]
        public bool RememberMe { get; set; }

        public string Login()
        {
            string result = null;
            if(this.UserName == "guest" && this.PassWord=="guest")
            {
                result = "Add";
            }
            else if(this.UserName == "admin" && this.PassWord=="admin")
            {
                result = "Add,Edit";
            }
            return result;
        }

    }
}