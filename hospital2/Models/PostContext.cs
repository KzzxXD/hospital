using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace hospital2.Models
{
    public class PostContext : DbContext
    {
        public PostContext()
            : base("Post")
        { }
        public DbSet<Post> Posts { get; set; }
       
    }

}