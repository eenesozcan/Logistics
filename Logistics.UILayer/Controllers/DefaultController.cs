using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logistics.UILayer.Models;

namespace Logistics.UILayer.Controllers
{

    [AllowAnonymous]
    public class DefaultController : Controller
    {
        DbLogisticEntities1 dB = new DbLogisticEntities1();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialHeader()
        {
            return PartialView();
        }

        public PartialViewResult PartialTestimonial()
        {
            var values = dB.TblTestimonial.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialStatistic()
        {
            ViewBag.v1 = dB.TblCustomer.Count();
            ViewBag.v2 = dB.TblOrder.Count();
            ViewBag.v3 = dB.TblCity.Count();
            ViewBag.v4 = dB.TblTestimonial.Count();
            return PartialView();
        }
    }
}