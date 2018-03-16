using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ITSourceManagement.ViewModel
{
    public class ResetPswViewModel
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string NewPassWord { get; set; }

    }
}