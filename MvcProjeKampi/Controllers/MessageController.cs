using BussiensLayer.Concrete;
using BussiensLayer.ValidationRules;
using DataAccessLAyer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{

    public class MessageController : Controller
    {
        MessageManager msm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();

        public ActionResult Inbox()
        {

            var messagelist = msm.GetListInbox(Session["UserName"].ToString());
            return View(messagelist);
        }
        public ActionResult InboxDetails(int id)
        {
            var Messagevalues = msm.GetByID(id);

            return View(Messagevalues);
        }
        public ActionResult SendBox()
        {
            var messagelist = msm.GetListSendInbox(Session["UserName"].ToString());
            return View(messagelist);
        }
        public ActionResult SendBoxDetails(int id)
        {
            var Messagevalues = msm.GetByID(id);

            return View(Messagevalues);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {

            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = messagevalidator.Validate(p);

            if (results.IsValid)
            {

                p.SenderMail = Session["UserName"].ToString();
                p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());

                msm.MessageAdd(p);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();


        }
    }
}