using Logistics.UILayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Logistics.UILayer.Controllers
{
    public class RegisterController : Controller
    {
        
        
        DbLogisticEntities1 dB=new DbLogisticEntities1();


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Index(TblCustomer p)
        {
            dB.TblCustomer.Add(p);
            dB.SaveChanges();
            return RedirectToAction("Index", "Login");

            //önce action conra controler adı
        }


        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
    }
}