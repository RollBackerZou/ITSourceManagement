using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ITSourceManagement.ViewModel
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public bool RememberMe { get; set; }
    }
}