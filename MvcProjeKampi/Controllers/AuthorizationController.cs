using BussiensLayer.Concrete;
using BussiensLayer.ValidationRules;
using DataAccessLAyer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdminsDal());

        public ActionResult Index()
        {
            var adminvalues = adm.GetList();

            return View(adminvalues);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {

            adm.AdminAddBl(p);
            return RedirectToAction("Index");




        }


        public ActionResult DeleteAdmin(int id)
        {
            var AdminValue = adm.AdminGetByID(id);
            adm.AdminDelete(AdminValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var AdminValue = adm.AdminGetByID(id);

            return View(AdminValue);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin Admin)
        {
            adm.AdminUpdate(Admin);
            return RedirectToAction("Index");
        }


    }
}