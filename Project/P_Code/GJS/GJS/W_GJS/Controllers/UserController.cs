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
    public class UserController : Controller
    {
        //
        // GET: /User/
        public GJSEntities Db_gsj;
        public ActionResult Index()
        {
            Db_gsj = new GJSEntities();
            return View(Db_gsj.O_SEO);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(S_USER USER)
        {

            if (ModelState.IsValid)
            {
                Db_gsj = new GJSEntities();
                USER.ACTIVE = true;
                USER.STATUS = 0;
                USER.CREATEDATE = DateTime.Now;
                Db_gsj.Entry(USER).State = EntityState.Added;
                Db_gsj.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return View(USER);
            }
        }
        [HttpGet]
        public ActionResult Edit(int? USER_CD)
        {
            if (USER_CD == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Db_gsj = new GJSEntities();
            S_USER USER_edit = Db_gsj.S_USER.Single(t => t.USER_CD == USER_CD);
            if (USER_edit == null)
                return HttpNotFound();
            return View(USER_edit);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(S_USER USER)
        {
            if (ModelState.IsValid)
            {
                Db_gsj = new GJSEntities();
                S_USER USER_edit = Db_gsj.S_USER.Single(t => t.USER_CD == USER.USER_CD);
                USER_edit.USER_PASS = USER.USER_PASS;
                USER_edit.USER_NAME = USER.USER_NAME;
                Db_gsj.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return View(USER);
            }
        }


        public ActionResult Deactive([Bind(Include = "USER_CD")]S_USER USER)
        {
            if (USER == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Db_gsj = new GJSEntities();
            USER = Db_gsj.S_USER.Single(t => t.USER_CD == USER.USER_CD);
            USER.ACTIVE = false;
            Db_gsj.Entry(USER).State = EntityState.Modified;
            Db_gsj.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Active([Bind(Include = "USER_CD")]S_USER USER)
        {
            if (USER == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Db_gsj = new GJSEntities();
            USER = Db_gsj.S_USER.Single(t => t.USER_CD == USER.USER_CD);
            USER.ACTIVE = true;
            Db_gsj.Entry(USER).State = EntityState.Modified;
            Db_gsj.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}