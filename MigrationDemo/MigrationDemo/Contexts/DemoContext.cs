using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MigrationDemo.Models;

namespace MigrationDemo.Contexts
{
    public class DemoContext: DbContext
    {
        public DemoContext() : base("Name=DefaultConnection") { }
        public DbSet<Student> Students { get; set; }
    }
}