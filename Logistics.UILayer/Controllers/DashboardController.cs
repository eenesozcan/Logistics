using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logistics.UILayer.Models;

namespace Logistics.UILayer.Controllers
{
    public class DashboardController : Controller
    {

        DbLogisticEntities1 dB=new DbLogisticEntities1();
        public ActionResult Index()
        {


            ViewBag.v1 = dB.TblCategory.Count();
            ViewBag.v2 = dB.TblCustomer.Count();
            ViewBag.v3 = dB.TblCategory.Where(x => x.CategoryID == 1).Select(y => y.CategoryName).FirstOrDefault();
            ViewBag.v4 = dB.TblCategory.Where(x => x.CategoryStatus == true).Count();
            return View();
        }
    }
}