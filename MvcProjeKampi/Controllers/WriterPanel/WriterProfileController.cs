using BussiensLayer.Concrete;
using DataAccessLAyer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers.WriterPanel
{

    public class WriterProfileController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());

        public ActionResult Anasayfa()
        {
            return View();
        }
        public ActionResult WriterProfiles()
        {
            var writervalue = wm.GetByID(Convert.ToInt32(Session["WriterID"]));
            return View(writervalue);
        }
    }
}