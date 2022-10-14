using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Logistics.UILayer.Models;

namespace Logistics.UILayer.Controllers
{
    public class LoginController : Controller
    {
        DbLogisticEntities1 dB = new DbLogisticEntities1();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Index(TblCustomer p)
        {
            var values = dB.TblCustomer.FirstOrDefault(x => x.CustomerMail == p.CustomerMail && x.CustomerPassword == p.CustomerPassword);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.CustomerMail, false);
                Session["CustomerMail"] = values.CustomerMail;
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}