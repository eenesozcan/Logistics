using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logistics.UILayer.Models;

namespace Logistics.UILayer.Controllers
{
    public class MapController : Controller
    {
        DbLogisticEntities1 dB = new DbLogisticEntities1();
        public ActionResult Index()
        {
            var values = dB.TblMap.ToList();
            return View(values);
        }
    }
}