using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ITSourceManagement.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("PassWord",ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPsw { get; set; }
    }
}