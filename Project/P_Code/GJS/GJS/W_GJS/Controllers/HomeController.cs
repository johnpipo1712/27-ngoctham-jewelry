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
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            // remove session
            Session[LOGINED_USER_KEY] = null;

            // logout and redirect to index page.
            LoginModel.Logout();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register(RegisterModel MODEL)
        {
            RegisterModel.Register(MODEL);
            return RedirectToAction("Index", "Home");
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

        public ActionResult NewsDetail([Bind(Include = "NEWS_CD")]O_NEWS NEWS)
        {
            Db_gsj = new GJSEntities();
            return View(Db_gsj.O_NEWS.Single(t=>t.NEWS_CD == NEWS.NEWS_CD));
        }

        public ActionResult Category_News([Bind(Include = "CATEGORY_NEWS_CD")]O_CATEGORY_NEWS CATEGORY_NEWS)
        {
            Db_gsj = new GJSEntities();
            return View(Db_gsj.O_NEWS.Where(t=>t.CATEGORY_NEWS_CD == CATEGORY_NEWS.CATEGORY_NEWS_CD).ToList());
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

        public ActionResult ProductDetail([Bind(Include = "PRODUCT_CD")]O_PRODUCT PRODUCT)
        {
            Db_gsj = new GJSEntities();
            return View(Db_gsj.O_PRODUCT.Single(t=>t.PRODUCT_CD == PRODUCT.PRODUCT_CD));
        }

        public ActionResult Product_Category([Bind(Include = "CATEGORY_PRODUCT_CD")]O_CATEGORY_PRODUCT CATEGORY_PRODUCT)
        {
            Db_gsj = new GJSEntities();
            return View(Db_gsj.O_PRODUCT.Where(t=>t.CATEGORY_PRODUCT_CD == CATEGORY_PRODUCT.CATEGORY_PRODUCT_CD));
        }

        public ActionResult Product_Category_Detail([Bind(Include = "CATEGORY_PRODUCT_DETAIL_CD")]O_CATEGORY_PRODUCT_DETAIL CATEGORY_PRODUCT_DETAIL)
        {
            Db_gsj = new GJSEntities();
            return View(Db_gsj.O_PRODUCT.Where(t=>t.CATEGORY_PRODUCT_DETAIL_CD == CATEGORY_PRODUCT_DETAIL.CATEGORY_PRODUCT_DETAIL_CD).ToList());
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