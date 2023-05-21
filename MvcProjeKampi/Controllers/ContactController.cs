using BussiensLayer.Concrete;
using BussiensLayer.ValidationRules;
using DataAccessLAyer.Abstract;
using DataAccessLAyer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {

        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
        MessageManager msm = new MessageManager(new EfMessageDal());
        public PartialViewResult Contactleft()
        {
            var ContactValues = cm.GetList();
            ViewBag.iletisim = ContactValues.Count();

            var messagelist = msm.GetListInbox(Session["UserName"].ToString());
            ViewBag.gelenmesaj = messagelist.Count();

            var messagelist2 = msm.GetListSendInbox(Session["UserName"].ToString());
            ViewBag.gonderilenmesaj = messagelist2.Count();
            return PartialView();
        }

        public ActionResult Index()
        {
            var ContactValues = cm.GetList();
         
            return View(ContactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = cm.GetByID(id);

            return View(contactvalues);
        }


    }
}