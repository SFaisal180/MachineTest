using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MachineTest.Models.DBModels
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}