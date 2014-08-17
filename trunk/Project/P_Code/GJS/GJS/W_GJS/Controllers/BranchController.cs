﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using W_GJS.Models;
namespace W_GJS.Controllers
{
    public class BRANCHController : Controller
    {
        //
        // GET: /BRANCH/
        public GJSEntities Db_gsj;
        public ActionResult Index()
        {
            Db_gsj = new GJSEntities();
            return View(Db_gsj.O_BRANCH);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Db_gsj = new GJSEntities();
            var query = Db_gsj.O_CITIES.Select(t => new { t.CITIES_CD, t.CITIES_NAME }).ToList();
            ViewBag.Cities = new SelectList(query.AsEnumerable(), "CITIES_CD", "CITIES_NAME", 1);
            var queryD = Db_gsj.D_CITIES_DETAIL.Where(t => t.CITIES_CD == 1).ToList();
            ViewBag.DCities = new SelectList(queryD.AsEnumerable(), "CITIES_DETAIL_CD", "CITIES_DETAIL_NAME", 1);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(O_BRANCH BRANCH)
        {
            if (ModelState.IsValid)
            {
                Db_gsj = new GJSEntities();
                BRANCH.ACTIVE = true;
                BRANCH.STATUS = 0;
                BRANCH.CREATEDATE= DateTime.Now;
                Db_gsj.Entry(BRANCH).State = EntityState.Added;
                Db_gsj.SaveChanges();
                return RedirectToAction("Index");
     
            }
            else
            {
                return View(BRANCH);
            }
        }
        [HttpGet]
        public ActionResult Edit(int? BRANCH_CD)
        {
            if (BRANCH_CD == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Db_gsj = new GJSEntities();
            O_BRANCH BRANCH_edit = Db_gsj.O_BRANCH.Single(t => t.BRANCH_CD == BRANCH_CD);
            if (BRANCH_edit == null)
                return HttpNotFound();
            return View(BRANCH_edit);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(O_BRANCH BRANCH)
        {
            if (ModelState.IsValid)
            {
                Db_gsj = new GJSEntities();
                O_BRANCH BRANCH_edit = Db_gsj.O_BRANCH.Single(t => t.BRANCH_CD == BRANCH.BRANCH_CD);
                BRANCH_edit.BRANCH_CODE = BRANCH.BRANCH_CODE;
                BRANCH_edit.BRANCH_NAME = BRANCH.BRANCH_NAME;
                BRANCH_edit.CITIES_CD = BRANCH.CITIES_CD;
                BRANCH_edit.ADDRESS = BRANCH.ADDRESS;
                BRANCH_edit.LATITUDE = BRANCH.LATITUDE;
                BRANCH_edit.LONGITUDE = BRANCH.LONGITUDE;
                BRANCH_edit.PHONE = BRANCH.PHONE;
                Db_gsj.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return View(BRANCH);
            }
        }


        public ActionResult Deactive([Bind(Include = "BRANCH_CD")]O_BRANCH BRANCH)
        {
            if (BRANCH == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Db_gsj = new GJSEntities();
            BRANCH = Db_gsj.O_BRANCH.Single(t => t.BRANCH_CD == BRANCH.BRANCH_CD);
            BRANCH.ACTIVE = false;
            Db_gsj.Entry(BRANCH).State = EntityState.Modified;
            Db_gsj.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Active([Bind(Include = "BRANCH_CD")]O_BRANCH BRANCH)
        {
            if (BRANCH == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Db_gsj = new GJSEntities();
            BRANCH = Db_gsj.O_BRANCH.Single(t => t.BRANCH_CD == BRANCH.BRANCH_CD);
            BRANCH.ACTIVE = true;
            Db_gsj.Entry(BRANCH).State = EntityState.Modified;
            Db_gsj.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]

        public JsonResult GetDetailByCityAJAX(long? CITIES_CD)
        {
            Db_gsj = new GJSEntities();
            return Json(Db_gsj.D_CITIES_DETAIL.Where(t => t.CITIES_CD == CITIES_CD).ToList().Select(t => new { t.CITIES_DETAIL_CD, t.CITIES_DETAIL_NAME }).ToArray());

        }
	}
}