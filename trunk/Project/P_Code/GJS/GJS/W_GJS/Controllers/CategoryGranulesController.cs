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
    public class CategoryGranulesController : Controller
    {
        //
        public GJSEntities Db_gsj;
        // GET: /CategoryNews/
        public ActionResult Index()
        {
            Db_gsj = new GJSEntities();
            return View(Db_gsj.O_CATEGORY_GRANULES);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(O_CATEGORY_GRANULES CATEGORY_NEWS)
        {
            
            if (ModelState.IsValid)
            {
                Db_gsj = new GJSEntities();
                CATEGORY_NEWS.ACTIVE = true;
                CATEGORY_NEWS.STATUS = 0;
                CATEGORY_NEWS.CREATEDATE = DateTime.Now;
                Db_gsj.Entry(CATEGORY_NEWS).State = EntityState.Added;
                Db_gsj.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return View(CATEGORY_NEWS);
            }
        }
        [HttpGet]
        public ActionResult Edit(int? CATEGORY_GRANULES_CD)
        {
            if (CATEGORY_GRANULES_CD == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Db_gsj = new GJSEntities();
            O_CATEGORY_GRANULES CATEGORY_GRANULES_edit = Db_gsj.O_CATEGORY_GRANULES.Single(t => t.CATEGORY_GRANULES_CD == CATEGORY_GRANULES_CD);
            if (CATEGORY_GRANULES_edit == null)
                return HttpNotFound();
            return View(CATEGORY_GRANULES_edit);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(O_CATEGORY_GRANULES CATEGORY_GRANULES)
        {
            if (ModelState.IsValid)
            {
                Db_gsj = new GJSEntities();
                O_CATEGORY_GRANULES CATEGORY_GRANULES_edit = Db_gsj.O_CATEGORY_GRANULES.Single(t => t.CATEGORY_GRANULES_CD == CATEGORY_GRANULES.CATEGORY_GRANULES_CD);
                CATEGORY_GRANULES_edit.CATEGORY_GRANULES_CONTENT = CATEGORY_GRANULES.CATEGORY_GRANULES_CONTENT;
                CATEGORY_GRANULES_edit.CATEGORY_GRANULES_NAME = CATEGORY_GRANULES.CATEGORY_GRANULES_NAME;
                CATEGORY_GRANULES_edit.CATEGORY_GRANULES_WEIGHT = CATEGORY_GRANULES.CATEGORY_GRANULES_WEIGHT;
                Db_gsj.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return View(CATEGORY_GRANULES);
            }
        }


        public ActionResult Deactive([Bind(Include = "CATEGORY_GRANULES_CD")]O_CATEGORY_GRANULES CATEGORY_NEWS)
        {
            if (CATEGORY_NEWS == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Db_gsj = new GJSEntities();
            CATEGORY_NEWS = Db_gsj.O_CATEGORY_GRANULES.Single(t => t.CATEGORY_GRANULES_CD == CATEGORY_NEWS.CATEGORY_GRANULES_CD);
            CATEGORY_NEWS.ACTIVE = false;
            Db_gsj.Entry(CATEGORY_NEWS).State = EntityState.Modified;
            Db_gsj.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Active([Bind(Include = "CATEGORY_GRANULES_CD")]O_CATEGORY_GRANULES CATEGORY_NEWS)
        {
            if (CATEGORY_NEWS == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Db_gsj = new GJSEntities();
            CATEGORY_NEWS = Db_gsj.O_CATEGORY_GRANULES.Single(t => t.CATEGORY_GRANULES_CD == CATEGORY_NEWS.CATEGORY_GRANULES_CD);
            CATEGORY_NEWS.ACTIVE = true;
            Db_gsj.Entry(CATEGORY_NEWS).State = EntityState.Modified;
            Db_gsj.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}