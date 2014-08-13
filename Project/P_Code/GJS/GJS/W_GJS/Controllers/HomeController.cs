using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using W_GJS.Models;
namespace W_GJS.Controllers
{
    public class HomeController : Controller
    {
        public const string LOGINED_USER_KEY = "logineduser";

        public GJSEntities Db_gsj;
        public ActionResult Index()
        {
            Db_gsj = new GJSEntities();
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            int roleOrFailed = LoginModel.Login(username, password);
            if (roleOrFailed == 0) // failed
            {
                return RedirectToAction("index", "Administrator"); // go to admin index
            }

            //store session if succeed
            Session[LOGINED_USER_KEY] = username;
            return View("Index", "Home");
        }

        public ActionResult Logout()
        {
            // remove session
            Session[LOGINED_USER_KEY] = null;

            // logout and redirect to index page.
            LoginModel.Logout();
            return View("Index", "Home");
        }

        public ActionResult Register(RegisterModel MODEL)
        {
            RegisterModel.Register(MODEL);
            return View("Index", "Home");
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

        public ActionResult ShowAlbum()
        {
            return View();
        }

        public ActionResult Catalog()
        {
            return View();
        }

        public ActionResult Cart()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }
        public ActionResult Chat()
        {
            return View();
        }
    }
}