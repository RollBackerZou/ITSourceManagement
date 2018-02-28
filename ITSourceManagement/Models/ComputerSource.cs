using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace ITSourceManagement.Models
{
    public class ComputerSource
    {
        public int Id { get; set; }
        public int SeatId { get; set; }

        [DisplayName("编号")]
        public string Number { get; set; }
        [DisplayName("批次")]
        public DateTime Date { get; set; }
        [DisplayName("归属")]
        public Belongs Belongs { get; set; }
        public virtual SeatSource SeatSource { get; set; }
    }

    public enum Belongs
    {
        Heyi,
        Safs,
        Influx,
        ZAIS,
    }
}