using BussiensLayer.Concrete;
using DataAccessLAyer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace MvcProjeKampi.Controllers
{
    public class LoginController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdminsDal());

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(Admin p)
        {

            var informations = adm.GetByID(p.AdminUserName, p.AdminPassword);

            if (informations != null)
            {
                FormsAuthentication.SetAuthCookie(informations.AdminUserName, false);

                Session["UserID"] = informations.AdminID;
                Session["UserName"] = p.AdminUserName;
                Session["UserRole"] = informations.AdminRole;


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