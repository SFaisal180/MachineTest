using MachineTest.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MachineTest.Models.ViewModels
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public int PageNo { get; set; }
        public int Total { get; set; }
        public int Size { get; set; }
    }
}