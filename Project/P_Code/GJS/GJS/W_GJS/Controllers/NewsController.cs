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
    public class NewsController : Controller
    {
        //
        // GET: /News/
        public GJSEntities Db_gsj;
        public ActionResult Index()
        {
            Db_gsj = new GJSEntities();
            return View(Db_gsj.O_NEWS);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(O_NEWS NEWS)
        {

            if (ModelState.IsValid)
            {
                Db_gsj = new GJSEntities();
                NEWS.ACTIVE = true;
                NEWS.STATUS = 0;
                NEWS.CREATEDATE = DateTime.Now;
                Db_gsj.Entry(NEWS).State = EntityState.Added;
                Db_gsj.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return View(NEWS);
            }
        }
        [HttpGet]
        public ActionResult Edit(int? NEWS_CD)
        {
            if (NEWS_CD == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Db_gsj = new GJSEntities();
            O_NEWS NEWS_edit = Db_gsj.O_NEWS.Single(t => t.NEWS_CD == NEWS_CD);
            if (NEWS_edit == null)
                return HttpNotFound();
            return View(NEWS_edit);

        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(O_NEWS NEWS)
        {
            if (ModelState.IsValid)
            {
                Db_gsj = new GJSEntities();
                O_NEWS NEWS_edit = Db_gsj.O_NEWS.Single(t => t.NEWS_CD == NEWS.NEWS_CD);
                NEWS_edit.IMAGE_NEWS = NEWS.IMAGE_NEWS;
                NEWS_edit.NEWS_CONTENT = NEWS.NEWS_CONTENT;
                NEWS_edit.NEWS_TITLE = NEWS.NEWS_TITLE;
                Db_gsj.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return View(NEWS);
            }
        }


        public ActionResult Deactive([Bind(Include = "NEWS_CD")]O_NEWS NEWS)
        {
            if (NEWS == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Db_gsj = new GJSEntities();
            NEWS = Db_gsj.O_NEWS.Single(t => t.NEWS_CD == NEWS.NEWS_CD);
            NEWS.ACTIVE = false;
            Db_gsj.Entry(NEWS).State = EntityState.Modified;
            Db_gsj.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Active([Bind(Include = "NEWS_CD")]O_NEWS NEWS)
        {
            if (NEWS == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Db_gsj = new GJSEntities();
            NEWS = Db_gsj.O_NEWS.Single(t => t.NEWS_CD == NEWS.NEWS_CD);
            NEWS.ACTIVE = true;
            Db_gsj.Entry(NEWS).State = EntityState.Modified;
            Db_gsj.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}