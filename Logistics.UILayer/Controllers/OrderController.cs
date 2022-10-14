using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logistics.UILayer.Models;
using Newtonsoft.Json.Linq;

namespace Logistics.UILayer.Controllers
{

    [Authorize]
    public class OrderController : Controller
    {
        
        DbLogisticEntities1 dB=new DbLogisticEntities1();
        
        public ActionResult Index()
        {
            var values = dB.TblOrder.ToList();
            return View(values);
        }

        public ActionResult DeleteOrder(int id)
        {
            var values = dB.TblOrder.Find(id);
            dB.TblOrder.Remove(values);
            dB.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}