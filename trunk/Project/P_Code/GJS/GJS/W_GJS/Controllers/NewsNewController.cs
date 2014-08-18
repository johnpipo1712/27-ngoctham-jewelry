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
    public class NewsNewController : Controller
    {
        //
        // GET: /NEWS_NEW/
        public GJSEntities Db_gsj;
        public ActionResult Index()
        {
            Db_gsj = new GJSEntities();
            return View(Db_gsj.O_NEWS_NEW);
        }
        [HttpGet]
        public ActionResult Create()
        {
            Db_gsj = new GJSEntities();
            var query = Db_gsj.O_NEWS.Select(t => new { t.NEWS_CD, t.NEWS_TITLE }).ToList();
            ViewBag.News = new SelectList(query.AsEnumerable(), "NEWS_CD", "NEWS_TITLE", 1);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(O_NEWS_NEW NEWS_NEW)
        {

            if (ModelState.IsValid)
            {
                Db_gsj = new GJSEntities();
                NEWS_NEW.ACTIVE = true;
                NEWS_NEW.STATUS = 0;
                NEWS_NEW.CREATEDATE = DateTime.Now;
                Db_gsj.Entry(NEWS_NEW).State = EntityState.Added;
                Db_gsj.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return View(NEWS_NEW);
            }
        }
        [HttpGet]
        public ActionResult Edit(int? CD)
        {
            if (CD == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Db_gsj = new GJSEntities();
            var query = Db_gsj.O_NEWS.Select(t => new { t.NEWS_CD, t.NEWS_TITLE }).ToList();
            ViewBag.News = new SelectList(query.AsEnumerable(), "NEWS_CD", "NEWS_TITLE", 1);

            O_NEWS_NEW NEWS_NEW_edit = Db_gsj.O_NEWS_NEW.Single(t => t.CD == CD);
            if (NEWS_NEW_edit == null)
                return HttpNotFound();
            return View(NEWS_NEW_edit);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(O_NEWS_NEW NEWS_NEW)
        {
            if (ModelState.IsValid)
            {
                Db_gsj = new GJSEntities();
                O_NEWS_NEW NEWS_NEW_edit = Db_gsj.O_NEWS_NEW.Single(t => t.CD == NEWS_NEW.CD);
                NEWS_NEW_edit.NEWS_CD = NEWS_NEW.NEWS_CD;
                Db_gsj.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return View(NEWS_NEW);
            }
        }


        public ActionResult Deactive([Bind(Include = "CD")]O_NEWS_NEW NEWS_NEW)
        {
            if (NEWS_NEW == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Db_gsj = new GJSEntities();
            NEWS_NEW = Db_gsj.O_NEWS_NEW.Single(t => t.CD == NEWS_NEW.CD);
            NEWS_NEW.ACTIVE = false;
            Db_gsj.Entry(NEWS_NEW).State = EntityState.Modified;
            Db_gsj.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Active([Bind(Include = "CD")]O_NEWS_NEW NEWS_NEW)
        {
            if (NEWS_NEW == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Db_gsj = new GJSEntities();
            NEWS_NEW = Db_gsj.O_NEWS_NEW.Single(t => t.CD == NEWS_NEW.CD);
            NEWS_NEW.ACTIVE = true;
            Db_gsj.Entry(NEWS_NEW).State = EntityState.Modified;
            Db_gsj.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}