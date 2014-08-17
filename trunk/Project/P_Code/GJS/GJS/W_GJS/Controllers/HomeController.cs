﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
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
                listproduct = Db_gsj.O_PRODUCT.Where(t => t.ACTIVE == true).ToList().Skip(beginPos).Take(numItemsInBlock).ToList();
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
        [HttpGet]
        public ActionResult Checkout()
        {
            O_ORDER ord = (O_ORDER)Session["Cart"];
            if (ord != null)
            {
                ViewBag.Infomation = "Điền thông tin thanh toán";
                Db_gsj = new GJSEntities();
                ord.CUSTOMER_CD = 1;
                Db_gsj.O_ORDER.Add(ord);
                Db_gsj.SaveChanges();

                foreach (var item in ord.D_ORDER_DETAIL)
                {
                    item.ORDER_CD = ord.ORDER_CD;
                    Db_gsj.D_ORDER_DETAIL.Add(item);
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
        [HttpPost]
        public ActionResult Checkout(O_ORDER ord)
        {
            return View();
            if (ModelState.IsValid)
            {
                //db = new DbWebDNEntities();
                //int Maord = 0;
                //if (db.O_ORDERs.Count() > 0)
                //{
                //    O_ORDER Phieudh = db.O_ORDERs.OrderByDescending(t => t.ID).Skip(0).Take(1).FirstOrDefault();
                //    int dodai = Phieudh.Maord.Length - 3;
                //    Maord = Convert.ToInt32(Phieudh.Maord.Substring(3, dodai));
                //}
                //ord.NgayDH = DateTime.Now;
                //ord.Maord = "ord" + (Maord + 1).ToString();
                //if (User.Identity.IsAuthenticated)
                //    ord.NguoiDung = db.NguoiDungs.Single(t => t.TenDN == User.Identity.Name);
                //ord.TrangThai = 0;
                //db.O_ORDERs.Add(ord);
                //db.SaveChanges();
                //O_ORDER ord = (O_ORDER)Session["Cart"];
                //foreach (CTO_ORDER ct in ord.CTO_ORDERs)
                //{
                //    CTO_ORDER ctord = new CTO_ORDER();
                //    ctord.IDord = ord.ID;
                //    ctord.IDpro = ct.O_PRODUCT.ID;
                //    ctord.SoLuong = ct.SoLuong;
                //    ctord.GiaTien = ct.O_PRODUCT.Gia * ct.SoLuong;
                //    db.CTO_ORDERs.Add(ctord);
                //    db.SaveChanges();
                //}
                //ProcessSendMail.SendMail_ThanhToan(ord);
                //ProcessSendMail.SendMail_ThongBao(ord);
                //Session["Cart"] = null;
                //return RedirectToAction("CheckoutComplete");
            }
            else
            {
                return View(ord);
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
    }
}