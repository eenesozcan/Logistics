using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Logistics.UILayer.Models;

namespace Logistics.UILayer.Controllers
{

    // *Authorize  -  Aşağıdaki hiç bir kural bu sınıf için geçerli olmasın demek. Bu komut yazılmadan önce FilterConfig.cs sınıfına yazılan komut nedeniyle login index sayfası da açılmıyordu. Bu komut sayesinde sadece login index sayfası açılabilecek
    [AllowAnonymous]

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
                TempData["msg"] = "<script>alert('Kullanıcı adı veya şifre hatalıdır.');</script>";



                ViewBag.v1 = "Kullanıcı adı veya şifre hatalıdır.";
                return RedirectToAction("Index");
            }
        }
    }
}