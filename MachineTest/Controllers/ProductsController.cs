using MachineTest.Models.DBModels;
using MachineTest.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MachineTest.Controllers
{
    public class ProductsController : Controller
    {
        private AppDbContext _context;

        public ProductsController()
        {
            _context = new AppDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var model = new ProductsViewModel();
            model.PageNo = GetQueryParameter(Request.QueryString["PageNo"]);
            model.Size = GetQueryParameter(Request.QueryString["Size"]);
            model.Size = model.Size == 0 ? 10 : model.Size;
            model.Products = _context.Products.Include(x => x.Category).ToList();
            model.Total = model.Products.Count();
            model.PageNo = model.PageNo == 0 ? 1 : model.PageNo;
            model.Products = model.Products.Skip((model.PageNo-1) * model.Size).Take(model.Size);
            

            return View(model);
        }

        private int GetQueryParameter(string s)
        {
            int param = 0;
            Int32.TryParse(s, out param);
            return param;
        }

        public ActionResult Detail(int id = 0)
        {
            if (id != 0)
            {
                var product = _context.Products.Include(x => x.Category).Where(x => x.ProductId == id).FirstOrDefault();
                if (product != null)
                {
                    return View(product);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id = 0)
        {
            var model = new ProductsEditorViewModel();
            model.Categories = _context.Categories;
            if (id != 0)
            {
                var product = _context.Products.Include(x => x.Category).Where(x => x.ProductId == id).FirstOrDefault();
                if (product != null)
                {
                    model.Product = product;
                }
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Save(ProductsEditorViewModel p)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index");

                }
                if (p.Product.ProductId != 0)
                {
                    var product = _context.Products.Where(x => x.ProductId == p.Product.ProductId).FirstOrDefault();
                    product.ProductName = p.Product.ProductName;
                    product.CategoryId = p.Product.CategoryId;
                }
                else
                {
                    _context.Products.Add(p.Product);
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(int id = 0)
        {
            if (id != 0)
            {
                var product = _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
                if (product != null)
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}