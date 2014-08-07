using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jewellry.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Branches()
        {
            return View();
        }

        public ActionResult DiamondAssess()
        {
            return View();
        }

        public ActionResult ColoredStonesAssess()
        {
            return View();
        }

        public ActionResult LaserInscription()
        {
            return View();
        }

        public ActionResult News()
        {
            return View();
        }

        public ActionResult NewsDetail()
        {
            return View();
        }

        public ActionResult NewsGold()
        {
            return View();
        }

        public ActionResult NewsFinancial()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult AboutCompany()
        {
            ViewBag.Message = "Giới thiệu công ty.";

            return View();
        }

        public ActionResult AboutAchievements()
        {
            ViewBag.Message = "Thành tựu.";

            return View();
        }

        public ActionResult AboutDevelopment()
        {
            ViewBag.Messagetham = "Quá trình phát triển.";

            return View();
        }

        public ActionResult AboutLicense()
        {
            ViewBag.Message = "Công ty TNHH Ngọc thẩm.";

            return View();
        }

        public ActionResult AboutVision()
        {
            ViewBag.Message = "Tầm nhìn và phát triển.";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ProductDetail()
        {
            return View();
        }

        public ActionResult ProductList()
        {
            return View();
        }
    }
}