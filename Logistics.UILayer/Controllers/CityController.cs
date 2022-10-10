using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logistics.UILayer.Models;

namespace Logistics.UILayer.Controllers
{
    
    public class CityController : Controller
    {

        DbLogisticEntities1 dB=new DbLogisticEntities1();
        public ActionResult Index()
        {
            var values = dB.TblCity.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult AddCity()
        {
            return View();  
        }

        [HttpPost]
        public ActionResult AddCity(TblCity p)
        {
            dB.TblCity.Add(p);
            dB.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCity(int id)
        {
            var values = dB.TblCity.Find(id);
            dB.TblCity.Remove(values);
            dB.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult UpdateCity(int id)
        {
            var values = dB.TblCity.Find(id);
            return View(values);
        }


        public ActionResult UpdateCity(TblCity p)
        {
            var values=dB.TblCity.Find(p.CityID);
            values.CityName=p.CityName;
            dB.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}