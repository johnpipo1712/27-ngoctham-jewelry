using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using W_GJS.Models;
namespace W_GJS.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        public GJSEntities Db_gsj;
        public ActionResult Index()
        {
            Db_gsj = new GJSEntities();
            return View(Db_gsj.O_PRODUCT);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(O_PRODUCT PRODUCT)
        {

            if (ModelState.IsValid)
            {
                Db_gsj = new GJSEntities();
                PRODUCT.ACTIVE = true;
                PRODUCT.STATUS = 0;
                PRODUCT.CREATEDATE = DateTime.Now;
                Db_gsj.Entry(PRODUCT).State = EntityState.Added;
                Db_gsj.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return View(PRODUCT);
            }
        }
        [HttpGet]
        public ActionResult Edit(int? PRODUCT_CD)
        {
            if (PRODUCT_CD == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Db_gsj = new GJSEntities();
            O_PRODUCT PRODUCT_edit = Db_gsj.O_PRODUCT.Single(t => t.PRODUCT_CD == PRODUCT_CD);
            if (PRODUCT_edit == null)
                return HttpNotFound();
            return View(PRODUCT_edit);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(O_PRODUCT PRODUCT)
        {
            if (ModelState.IsValid)
            {
                Db_gsj = new GJSEntities();
                O_PRODUCT PRODUCT_edit = Db_gsj.O_PRODUCT.Single(t => t.PRODUCT_CD == PRODUCT.PRODUCT_CD);
                PRODUCT_edit.PRODUCT_CODE = PRODUCT.PRODUCT_CODE;
                PRODUCT_edit.PRODUCT_NAME = PRODUCT.PRODUCT_NAME;
                Db_gsj.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return View(PRODUCT);
            }
        }


        public ActionResult Deactive([Bind(Include = "PRODUCT_CD")]O_PRODUCT PRODUCT)
        {
            if (PRODUCT == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Db_gsj = new GJSEntities();
            PRODUCT = Db_gsj.O_PRODUCT.Single(t => t.PRODUCT_CD == PRODUCT.PRODUCT_CD);
            PRODUCT.ACTIVE = false;
            Db_gsj.Entry(PRODUCT).State = EntityState.Modified;
            Db_gsj.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Active([Bind(Include = "PRODUCT_CD")]O_PRODUCT PRODUCT)
        {
            if (PRODUCT == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Db_gsj = new GJSEntities();
            PRODUCT = Db_gsj.O_PRODUCT.Single(t => t.PRODUCT_CD == PRODUCT.PRODUCT_CD);
            PRODUCT.ACTIVE = true;
            Db_gsj.Entry(PRODUCT).State = EntityState.Modified;
            Db_gsj.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}