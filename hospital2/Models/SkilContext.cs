using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace hospital2.Models
{
    public class SkilContext : DbContext
     {
        public SkilContext()
            : base("Skil")
        { }
        public DbSet<Skil> Skils { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}