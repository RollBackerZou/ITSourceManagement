using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ITSourceManagement.Models;

namespace ITSourceManagement
{
    public class SQLContext:DbContext
    {
        public DbSet<ComputerSource> ComputerSources { get; set; }
        public DbSet<SeatSource> SeatSources { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}