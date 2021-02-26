using MachineTest.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MachineTest.Models.ViewModels
{
    public class ProductsEditorViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}