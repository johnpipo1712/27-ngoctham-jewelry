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
    public class NewsHighlightController : Controller
    {
        //
        // GET: /NEWS_HIGHLIGHTS/
        public GJSEntities Db_gsj;
        public ActionResult Index()
        {
            Db_gsj = new GJSEntities();
            return View(Db_gsj.O_NEWS_HIGHLIGHTS);
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
        public ActionResult Create(O_NEWS_HIGHLIGHTS NEWS_HIGHLIGHTS)
        {

            if (ModelState.IsValid)
            {
                Db_gsj = new GJSEntities();
                NEWS_HIGHLIGHTS.ACTIVE = true;
                NEWS_HIGHLIGHTS.STATUS = 0;
                NEWS_HIGHLIGHTS.CREATEDATE = DateTime.Now;
                Db_gsj.Entry(NEWS_HIGHLIGHTS).State = EntityState.Added;
                Db_gsj.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return View(NEWS_HIGHLIGHTS);
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

            O_NEWS_HIGHLIGHTS NEWS_HIGHLIGHTS_edit = Db_gsj.O_NEWS_HIGHLIGHTS.Single(t => t.CD == CD);
            if (NEWS_HIGHLIGHTS_edit == null)
                return HttpNotFound();
            return View(NEWS_HIGHLIGHTS_edit);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(O_NEWS_HIGHLIGHTS NEWS_HIGHLIGHTS)
        {
            if (ModelState.IsValid)
            {
                Db_gsj = new GJSEntities();
                O_NEWS_HIGHLIGHTS NEWS_HIGHLIGHTS_edit = Db_gsj.O_NEWS_HIGHLIGHTS.Single(t => t.CD == NEWS_HIGHLIGHTS.CD);
                NEWS_HIGHLIGHTS_edit.NEWS_CD = NEWS_HIGHLIGHTS.NEWS_CD;
                Db_gsj.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return View(NEWS_HIGHLIGHTS);
            }
        }


        public ActionResult Deactive([Bind(Include = "CD")]O_NEWS_HIGHLIGHTS NEWS_HIGHLIGHTS)
        {
            if (NEWS_HIGHLIGHTS == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Db_gsj = new GJSEntities();
            NEWS_HIGHLIGHTS = Db_gsj.O_NEWS_HIGHLIGHTS.Single(t => t.CD == NEWS_HIGHLIGHTS.CD);
            NEWS_HIGHLIGHTS.ACTIVE = false;
            Db_gsj.Entry(NEWS_HIGHLIGHTS).State = EntityState.Modified;
            Db_gsj.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Active([Bind(Include = "CD")]O_NEWS_HIGHLIGHTS NEWS_HIGHLIGHTS)
        {
            if (NEWS_HIGHLIGHTS == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Db_gsj = new GJSEntities();
            NEWS_HIGHLIGHTS = Db_gsj.O_NEWS_HIGHLIGHTS.Single(t => t.CD == NEWS_HIGHLIGHTS.CD);
            NEWS_HIGHLIGHTS.ACTIVE = true;
            Db_gsj.Entry(NEWS_HIGHLIGHTS).State = EntityState.Modified;
            Db_gsj.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}