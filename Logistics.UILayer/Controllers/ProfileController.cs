using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logistics.UILayer.Models;

namespace Logistics.UILayer.Controllers
{
    public class ProfileController : Controller
    {
        DbLogisticEntities1 dB = new DbLogisticEntities1();

        public ActionResult Index()
        {

            var mail = Session["CustomerMail"].ToString();
            //var values = dB.TblCustomer.Where(x => x.CustomerMail == mail).ToList(); //kullanıcının tüm bilgilerini getirir
            //return View(values);
            
            
            var values = dB.TblCustomer.Where(x => x.CustomerMail == mail).FirstOrDefault();
            ViewBag.v1 = values.CustomerName;
            ViewBag.v2 = values.CustomerSurname;
            ViewBag.v3 = values.CustomerMail;
            ViewBag.v4 = values.CustomerPhone;
            return View();


            //Sisteme giriş yapan kullanıcının bütün bilgileri values değişkenine atanmış durumda

        }


        public ActionResult UpdateProfile(int id)
        {
            var values = dB.TblCustomer.Find(id);
            return View(values);
        }
    }
}