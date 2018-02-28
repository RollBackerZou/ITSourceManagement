using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITSourceManagement.Models;
using System.ComponentModel;

namespace ITSourceManagement.ViewModel
{
    public class SeatSourceViewModel
    {
        public SeatSourceViewModel()
        {
            ComputerSources = new List<ComputerSource>();
            AllBelongs = new List<SelectListItem>();
        }
        public int Id { get; set; }

        [DisplayName("座位号")]
        public string SeatNo { get; set; }
        public List<ComputerSource> ComputerSources { get; set; }

        public IEnumerable<SelectListItem> AllBelongs { get; set; }
    }
}