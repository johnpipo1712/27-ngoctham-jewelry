using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using W_GJS.General;
using W_GJS.Models;
namespace W_GJS.Controllers
{
    public class HomeController : Controller
    {

        public GJSEntities Db_gsj;
        public ActionResult Index()
        {
            Db_gsj = new GJSEntities();

            return View();
        }

        [ChildActionOnly]
        public ActionResult ProductLazyList(List<W_GJS.Models.O_PRODUCT> Model)
        {
            return PartialView(Model);
        }

        [HttpPost]
        public ActionResult GetNext15Products(int blockNumber)
        {
            Db_gsj = new GJSEntities();
            JsonModel jsonModel = new JsonModel();
            List<W_GJS.Models.O_PRODUCT> listproduct = new List<W_GJS.Models.O_PRODUCT>();
            int numItemsInBlock = 15;
            int totalItems = Db_gsj.O_PRODUCT.Count();
            // check if out of size.
            if (totalItems / numItemsInBlock < blockNumber)
            {
                jsonModel.NoMoreData = true;
            }
            else
            {
                jsonModel.NoMoreData = false;

                // calc beginPos
                int beginPos = numItemsInBlock * blockNumber;
                listproduct = Db_gsj.O_PRODUCT.Where(t => t.ACTIVE == true && t.STATUS == 1).ToList().Skip(beginPos).Take(numItemsInBlock).ToList();
            }

            
            jsonModel.HTMLString = RenderPartialViewToString("ProductLazyList", listproduct);

            return Json(jsonModel);
        }

        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            Db_gsj = new GJSEntities();
            JsonResultLoginModel jsonModel = new JsonResultLoginModel();

            jsonModel = LoginModel.Login(username, password);
            if (jsonModel.RoleOrFailed == 0) // failed
            {
                return Json(jsonModel);
            }

            //store session if succeed
            Session[SessionConstants.LOGINED_USER_KEY] = username;
            return RedirectToAction("Index", "Administrator");
        }


        public ActionResult Logout()
        {
            // remove session
            Session[SessionConstants.LOGINED_USER_KEY] = null;

            // logout and redirect to index page.
            LoginModel.Logout();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register(RegisterModel MODEL)
        {
            RegisterModel.Register(MODEL);
            return RedirectToAction("Index", "Home");
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
            return View(Db_gsj.O_PRODUCT.Where(t=>t.CATEGORY_PRODUCT_CD == CATEGORY_PRODUCT.CATEGORY_PRODUCT_CD && t.STATUS == 1 && t.ACTIVE == true));
        }

        public ActionResult Product_Category_Detail([Bind(Include = "CATEGORY_PRODUCT_DETAIL_CD")]O_CATEGORY_PRODUCT_DETAIL CATEGORY_PRODUCT_DETAIL)
        {
            Db_gsj = new GJSEntities();
            return View(Db_gsj.O_PRODUCT.Where(t => t.CATEGORY_PRODUCT_DETAIL_CD == CATEGORY_PRODUCT_DETAIL.CATEGORY_PRODUCT_DETAIL_CD && t.STATUS == 1 && t.ACTIVE == true).ToList());
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
        public ActionResult ViewCart()
        {

            ViewBag.Where = "Xem giỏ hàng";

            O_ORDER ord = (O_ORDER)Session["Cart"];
            if (ord != null)
            {
                ViewData.Model = ord;
                ViewBag.Price_Total = O_ORDER.Price_Total(ord);
                return View();

            }
            else
                return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult AddCart([Bind(Include = "PRODUCT_CD,QUANTITY,SIZE")]O_PRODUCT pro)
        {
            O_ORDER ord = (O_ORDER)Session["Cart"];
            if (ord == null)
                ord = new O_ORDER();
            int ketqua = ord.AddCart(pro);
            Session.Add("Cart", ord);
            Response.Redirect(Request.UrlReferrer.AbsoluteUri);
            
            return RedirectToAction("Index", "Home");
            
        }
        [HttpPost]
        public ActionResult AddCartQuantity([Bind(Include = "PRODUCT_CD,QUANTITY,SIZE")]O_PRODUCT pro)
        {
        
            O_ORDER ord = (O_ORDER)Session["Cart"];
            if (ord == null)
                ord = new O_ORDER();
            int ketqua = ord.AddCart(pro);
            Session.Add("Cart", ord);
            Response.Redirect(Request.UrlReferrer.AbsoluteUri);
            return RedirectToAction("Index", "Home");
            
        }
        [HttpPost]
        public ActionResult UpdateCart([Bind(Include = "PRODUCT_CD,QUANTITY")]O_PRODUCT pro)
        {

            O_ORDER ord = (O_ORDER)Session["Cart"];
            ord.UpdateCart(pro);
            return RedirectToAction("Cart");
        }
        public ActionResult DeleteCart([Bind(Include = "PRODUCT_CD")]O_PRODUCT pro)
        {

            O_ORDER ord = (O_ORDER)Session["Cart"];
            if (ord.D_ORDER_DETAIL.Count == 1)
            {
                Session["Cart"] = null;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ord.DeleteCart(pro);
                return RedirectToAction("Cart");
            }

        }
        public ActionResult DeleteAllCart()
        {
            Session["Cart"] = null;
            return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        public ActionResult Checkout()
        {
            O_ORDER ord = (O_ORDER)Session["Cart"];
            if (ord != null)
            {
                Db_gsj = new GJSEntities();
                O_ORDER ordcheckout = new O_ORDER();
                ordcheckout.ACTIVE = true;
                ordcheckout.STATUS = 0;
                ordcheckout.CREATEDATE = DateTime.Now;
                ordcheckout.CUSTOMER_CD = 1;
                ordcheckout.O_CUSTOMER = Db_gsj.O_CUSTOMER.Single(t=>t.CUSTOMER_CD == 1);
                ordcheckout.PHONE = ordcheckout.O_CUSTOMER.PHONE;
                ordcheckout.EMAIL = ordcheckout.O_CUSTOMER.EMAIL;
                ordcheckout.DELIVERY_ADDRESS = ordcheckout.O_CUSTOMER.ADDRESS;
                Db_gsj.Entry(ordcheckout).State = EntityState.Added;
                Db_gsj.SaveChanges();
                foreach (var item in ord.D_ORDER_DETAIL)
                {
                    D_ORDER_DETAIL orddetail = new D_ORDER_DETAIL();
                    orddetail.STATUS = 0;
                    orddetail.CREATEDATE = DateTime.Now;
                    orddetail.ACTIVE = true;
                    orddetail.ORDER_CD = ordcheckout.ORDER_CD;
                    orddetail.PRODUCT_CD = item.PRODUCT_CD;
                    orddetail.QUANTITY = item.QUANTITY;
                    orddetail.SIZE = item.SIZE;
                    orddetail.PRICE = item.PRICE;
                    Db_gsj.Entry(orddetail).State = EntityState.Added;
                    Db_gsj.SaveChanges();
                }
                Session["Cart"] = null;
               
                return RedirectToAction("Index", "Home");
                
            }
            else
            {
                return RedirectToAction("Index", "Home");

            }
        }
        
        public ActionResult CheckoutComplete()
        {
            ViewBag.Where = "Thanh toán thành công";

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
        public ActionResult Branches()
        {
            Db_gsj = new GJSEntities();
            var query = Db_gsj.O_CITIES.Select(t => new { t.CITIES_CD,t.CITIES_NAME} ).ToList();
            ViewBag.Cities = new SelectList(query.AsEnumerable(), "CITIES_CD", "CITIES_NAME",1);
            var queryD = Db_gsj.D_CITIES_DETAIL.Where(t=>t.CITIES_CD == 1).ToList();
            ViewBag.DCities = new SelectList(queryD.AsEnumerable(), "CITIES_DETAIL_CD", "CITIES_DETAIL_NAME",1);

            return View(Db_gsj.O_BRANCH.Where(t => t.CITIES_CD == 1).ToList());
        }

        [HttpPost]
        public ActionResult Branches(string CITIES_CD, string CITIES_DETAIL_CD)
        {
            Db_gsj = new GJSEntities();
           
            return View();
        }
        [HttpPost]

        public JsonResult GetDetailByCityAJAX(long? CITIES_CD)
 
        {
            Db_gsj = new GJSEntities();
            return Json(Db_gsj.D_CITIES_DETAIL.Where(t => t.CITIES_CD == CITIES_CD).ToList().Select(t => new { t.CITIES_DETAIL_CD, t.CITIES_DETAIL_NAME }).ToArray());
 
        }

         [HttpPost]

        public JsonResult GetBrancheslByCityAJAX(long? CITIES_CD)
        {
            Db_gsj = new GJSEntities();
            return Json(Db_gsj.O_BRANCH.Where(t => t.CITIES_CD == CITIES_CD).ToList().Select(t=> new{t.BRANCH_NAME,t.ADDRESS,t.PHONE,t.LATITUDE,t.LONGITUDE}).ToArray());
 
        }

         [HttpPost]

         public JsonResult GetBrancheslByDCityAJAX(long? CITIES_DETAIL_CD)
         {
             Db_gsj = new GJSEntities();
             return Json(Db_gsj.O_BRANCH.Where(t => t.CITIES_DETAIL_CD == CITIES_DETAIL_CD).ToList().Select(t => new { t.BRANCH_NAME, t.ADDRESS, t.PHONE, t.LATITUDE, t.LONGITUDE }).ToArray());

         }
      
    }
}