using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ITSourceManagement.Models
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Email { get; set; }      
    }
}