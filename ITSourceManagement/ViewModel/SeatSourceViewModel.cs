using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITSourceManagement.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ITSourceManagement.ViewModel
{
    public class SeatSourceViewModel
    {
        public SeatSourceViewModel()
        {
            ComputerSources = new List<ComputerSource>();
            AllBelongs = new List<SelectListItem>();
        }
        [Key]
        public int Id { get; set; }

        [DisplayName("座位号")]
        [Required]
        public string SeatNo { get; set; }
        [DisplayName("编号")]
        public string Number { get; set; }
        [DisplayName("批次")]
        public DateTime Date { get; set; }
        [DisplayName("归属")]
        public Belongs Belongs { get; set; }
        public List<ComputerSource> ComputerSources { get; set; }

        public IEnumerable<SelectListItem> AllBelongs { get; set; }
    }
}