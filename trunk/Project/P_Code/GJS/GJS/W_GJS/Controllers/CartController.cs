using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using W_GJS.Models;

namespace W_GJS.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/
        GJSEntities gjs;
        public ActionResult ViewCart()
        {
            
            Session["Controller"] = "Cart";
            Session["Action"] = "ViewCart";
            Session["Router"] = null;
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
        public ActionResult AddCart([Bind(Include = "PRODUCT_CD,QUANTITY")]O_PRODUCT pro)
        {
            Session["Controller"] = "Cart";
            Session["Action"] = "ViewCart";
            Session["Router"] = null;
          
            O_ORDER ord = (O_ORDER)Session["Cart"];
            if (ord == null)
                ord = new O_ORDER();
            int ketqua = ord.AddCart(pro);
            Session.Add("Cart", ord);
               return RedirectToAction("Index","Home");
            //if (ketqua == 1)
            //{
            //    Session.Add("Cart", ord);
            //    if (Session["Router"] == null)
            //        return RedirectToAction(Session["Action"].ToString(), Session["Controller"].ToString(), null);
            //    else if (Session["Action"] != "CategoryCT")
            //    {
            //        return RedirectToAction(Session["Action"].ToString(), Session["Controller"].ToString(), new { id = Session["Router"].ToString() });
            //    }
            //    else
            //    {
            //        return RedirectToAction(Session["Action"].ToString(), Session["Controller"].ToString(), new { id = Session["Router"].ToString(), idCT = Session["Router2"].ToString() });
            //    }
            //}
            //else
            //{
            //    if (Session["Router"] == null)
            //        return RedirectToAction(Session["Action"].ToString(), Session["Controller"].ToString(), null);
            //    else if (Session["Action"] != "CategoryCT")
            //    {
            //        return RedirectToAction(Session["Action"].ToString(), Session["Controller"].ToString(), new { id = Session["Router"].ToString() });
            //    }
            //    else
            //    {
            //        return RedirectToAction(Session["Action"].ToString(), Session["Controller"].ToString(), new { id = Session["Router"].ToString(), idCT = Session["Router2"].ToString() });
            //    }
            //}
        }
        [HttpPost]
        public ActionResult AddCartQuantity([Bind(Include = "PRODUCT_CD,QUANTITY")]O_PRODUCT pro)
        {
            Session["Controller"] = "Cart";
            Session["Action"] = "ViewCart";
            Session["Router"] = null;

            
            O_ORDER ord = (O_ORDER)Session["Cart"];
            if (ord == null)
                ord = new O_ORDER();
            int ketqua = ord.AddCart(pro);
            Session.Add("Cart", ord);
            return RedirectToAction("Index","Home");
            //if (ketqua == 1)
            //{
            //    Session.Add("Cart", ord);
            //    if (Session["Router"] == null)
            //        return RedirectToAction(Session["Action"].ToString(), Session["Controller"].ToString(), null);
            //    else
            //        return RedirectToAction(Session["Action"].ToString(), Session["Controller"].ToString(), new { id = Session["Router"].ToString() });
            //}
            //else
            //{
            //    if (Session["Router"] == null)
            //        return RedirectToAction(Session["Action"].ToString(), Session["Controller"].ToString(), null);
            //    else
            //        return RedirectToAction(Session["Action"].ToString(), Session["Controller"].ToString(), new { id = Session["Router"].ToString() });

            //}
        }
        [HttpPost]
        public ActionResult UpdateCart([Bind(Include = "PRODUCT_CD,QUANTITY")]O_PRODUCT pro)
        {
  
            O_ORDER ord = (O_ORDER)Session["Cart"];
            ord.UpdateCart(pro);
            return RedirectToAction("ViewCart");
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
                return RedirectToAction("ViewCart");
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
                if (User.Identity.IsAuthenticated)
                {

                    //db = new DbWebDNEntities();
                    //NguoiDung nd = db.NguoiDungs.Single(t => t.TenDN == User.Identity.Name);
                    //ord.HoTenNN = nd.HoTen = nd.HoTen;
                    //ord.Email = nd.Email;
                    //ord.DiaChi = nd.DiaChi;
                    //ord.SDT = nd.SDT;
                }
                ViewData.Model = ord;
                return View();
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

    }
}


