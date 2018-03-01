using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace ITSourceManagement.Models
{
    public class SeatSource
    {
        public int Id { get; set; }
        public string SeatNo { get; set; }
        [DisplayName("编号")]
        public string Number { get; set; }
        [DisplayName("批次")]
        public DateTime Date { get; set; }
        [DisplayName("归属")]
        public Belongs Belongs { get; set; }
        public virtual ICollection<ComputerSource> ComputerSources { get; set; }
    }
}