using MachineTest.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MachineTest.Controllers
{
    public class CategoriesController : Controller
    {
        private AppDbContext _context;

        public CategoriesController()
        {
            _context = new AppDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var model = _context.Categories.ToList();
            return View(model);
        }

        public ActionResult Detail(int id = 0)
        {
            if (id != 0)
            {
                var category = _context.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
                if (category != null)
                {
                    return View(category);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id = 0)
        {
            if (id != 0)
            {
                var category = _context.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
                if (category != null)
                {
                    return View(category);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Save(Category c)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index");

                }
                if (c.CategoryId != 0)
                {
                    var category = _context.Categories.Where(x => x.CategoryId == c.CategoryId).FirstOrDefault();
                    category.CategoryName = c.CategoryName;
                }
                else
                {
                    _context.Categories.Add(c);
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
                var category = _context.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
                if (category != null)
                {
                    _context.Categories.Remove(category);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}