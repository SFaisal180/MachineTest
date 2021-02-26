using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MachineTest.Models.DBModels
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("MachineTest")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}