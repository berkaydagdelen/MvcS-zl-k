using BussiensLayer.Concrete;
using DataAccessLAyer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers.WriterPanel
{
    public class WriterLoginController : Controller
    {


        WriterLoginManager wm = new WriterLoginManager(new EfWriterDal());


        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(Writer p)
        {

            var writeruserinfo = wm.GetWriter(p.WriterMail, p.WriterPassword);

            if (writeruserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);

                Session["WriterID"] = writeruserinfo.WriterID;
                Session["WriterName"] = p.WriterMail;


                return Json(new { Durum = true }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { Durum = false }, JsonRequestBehavior.AllowGet);

            }


        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}