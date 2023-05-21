using BussiensLayer.Concrete;
using DataAccessLAyer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers.WriterPanel
{
    public class WriterPanelContentController : Controller
    {

        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult MyContent()
        {

            var contentvalues = cm.GetListByMyHeadingID(Convert.ToInt32(Session["WriterID"]));
            return View(contentvalues);

        }
        [HttpGet]
        public ActionResult AddContent()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content p, int id)
        {
            p.ContentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.ContentStatus = true;
            p.WriterID = Convert.ToInt32(Session["WriterID"]);
            p.HeadingID = id;
            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }

    }
}