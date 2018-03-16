using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ITSourceManagement.ViewModel
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string EmailAddr { get; set; }
    }
}