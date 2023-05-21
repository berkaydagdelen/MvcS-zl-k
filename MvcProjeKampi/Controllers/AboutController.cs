using BussiensLayer.Concrete;
using DataAccessLAyer.Abstract;
using DataAccessLAyer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {

        AboutManager aboutManager = new AboutManager(new EfAboutDal());

        public ActionResult Index()
        {
            var AboutValues = aboutManager.GetList();
            return View(AboutValues);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            aboutManager.AboutAddBl(p);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial()
        {

            return PartialView();
        }
    }
}