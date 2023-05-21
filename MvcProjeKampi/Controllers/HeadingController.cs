using BussiensLayer.Concrete;
using DataAccessLAyer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {

        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index(string p = "")
        {
            var HeadingValues = hm.GetListSearch(p);


            return View(HeadingValues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> ValueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()

                                                  }).ToList();
            ViewBag.vlc = ValueCategory;

            List<SelectListItem> ValueWriter = (from x in wm.GetList()

                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurName,
                                                    Value = x.WriterID.ToString()
                                                }).ToList();
            ViewBag.vlw = ValueWriter;


            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingStatus = true;
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {

            List<SelectListItem> ValueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()

                                                  }).ToList();
            ViewBag.vlc = ValueCategory;


            var HeadingValues = hm.GetByID(id);
            return View(HeadingValues);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {


            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {

            var DeleteValues = hm.GetByID(id);

            if (DeleteValues.HeadingStatus == true)
            {
                DeleteValues.HeadingStatus = false;
                hm.HeadingDelete(DeleteValues);
            }
            else
            {
                DeleteValues.HeadingStatus = true;
                hm.HeadingDelete(DeleteValues);

            }

            return RedirectToAction("Index");
        }


    }
}