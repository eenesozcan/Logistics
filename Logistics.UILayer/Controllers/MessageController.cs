using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logistics.UILayer.Models;
using Newtonsoft.Json.Linq;

namespace Logistics.UILayer.Controllers
{
    public class MessageController : Controller
    {

        DbLogisticEntities1 dB = new DbLogisticEntities1();
        public ActionResult Inbox()
        {
            var mail = Session["CustomerMail"].ToString();
            var values = dB.TblMessage.Where(x => x.MessageReceiver == mail).ToList();
            return View(values);
        }



        public ActionResult Outbox()
        {
            var mail = Session["CustomerMail"].ToString();
            var values = dB.TblMessage.Where(x => x.MessageSender == mail).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }



        [HttpPost]
        public ActionResult SendMessage(TblMessage p)
        {
            var mail = Session["CustomerMail"].ToString();
            p.MessageSender = mail;
            p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            string mesajiGonderen = dB.TblCustomer.Where(x => x.CustomerMail == mail).Select(y => y.CustomerName + "  " + y.CustomerSurname).FirstOrDefault();

            string alici = dB.TblCustomer.Where(x => x.CustomerMail == p.MessageReceiver).Select(y => y.CustomerName + " " + y.CustomerSurname).FirstOrDefault();

            p.SenderName = mesajiGonderen;
            p.ReceiverName = alici;
            dB.TblMessage.Add(p);
            dB.SaveChanges();
            return RedirectToAction("Outbox");
        }

        public ActionResult MessageDetails(int id)
        {

            var values = dB.TblMessage.Find(id);
            return View(values);

        }
    }
}