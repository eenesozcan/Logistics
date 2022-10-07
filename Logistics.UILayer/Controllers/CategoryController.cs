using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logistics.UILayer.Models;

namespace Logistics.UILayer.Controllers
{
    public class CategoryController : Controller
    {

        DbLogisticEntities1 dB = new DbLogisticEntities1();

        public ActionResult Index()
        {
            var values = dB.TblCategory.ToList();
            
            return View(values);
        }


        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(TblCategory p)
        {
            dB.TblCategory.Add(p);
            dB.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCategory(int id)
        {
            var values = dB.TblCategory.Find(id);
            dB.TblCategory.Remove(values);
            dB.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult UpdateCategory(int id)
        {
            var values = dB.TblCategory.Find(id);
            return View(values);
        }


        public ActionResult UpdateCategory(TblCategory p)
        {
            var values = dB.TblCategory.Find(p.CategoryID);
            values.CategoryName=p.CategoryName;
            dB.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}