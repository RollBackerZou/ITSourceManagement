using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITSourceManagement.Models
{
    public class SeatSource
    {
        public int Id { get; set; }
        public string SeatNo { get; set; }

        public virtual ICollection<ComputerSource> ComputerSources { get; set; }
    }
}