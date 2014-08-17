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
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/
        public GJSEntities Db_gsj;
        public ActionResult Index()
        {
            Db_gsj = new GJSEntities();
            return View(Db_gsj.O_CUSTOMER);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(O_CUSTOMER CUSTOMER)
        {

            if (ModelState.IsValid)
            {
                Db_gsj = new GJSEntities();
                CUSTOMER.ACTIVE = true;
                CUSTOMER.STATUS = 0;
                CUSTOMER.CREATEDATE = DateTime.Now;
                Db_gsj.Entry(CUSTOMER).State = EntityState.Added;
                Db_gsj.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return View(CUSTOMER);
            }
        }
        [HttpGet]
        public ActionResult Edit(int? CUSTOMER_CD)
        {
            if (CUSTOMER_CD == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Db_gsj = new GJSEntities();
            O_CUSTOMER CUSTOMER_edit = Db_gsj.O_CUSTOMER.Single(t => t.CUSTOMER_CD == CUSTOMER_CD);
            if (CUSTOMER_edit == null)
                return HttpNotFound();
            return View(CUSTOMER_edit);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(O_CUSTOMER CUSTOMER)
        {
            if (ModelState.IsValid)
            {
                Db_gsj = new GJSEntities();
                O_CUSTOMER CUSTOMER_edit = Db_gsj.O_CUSTOMER.Single(t => t.CUSTOMER_CD == CUSTOMER.CUSTOMER_CD);
                CUSTOMER_edit.CUSTOMER_CODE = CUSTOMER.CUSTOMER_CODE;
                CUSTOMER_edit.CUSTOMER_NAME = CUSTOMER.CUSTOMER_NAME;
                Db_gsj.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return View(CUSTOMER);
            }
        }


        public ActionResult Deactive([Bind(Include = "CUSTOMER_CD")]O_CUSTOMER CUSTOMER)
        {
            if (CUSTOMER == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Db_gsj = new GJSEntities();
            CUSTOMER = Db_gsj.O_CUSTOMER.Single(t => t.CUSTOMER_CD == CUSTOMER.CUSTOMER_CD);
            CUSTOMER.ACTIVE = false;
            Db_gsj.Entry(CUSTOMER).State = EntityState.Modified;
            Db_gsj.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Active([Bind(Include = "CUSTOMER_CD")]O_CUSTOMER CUSTOMER)
        {
            if (CUSTOMER == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Db_gsj = new GJSEntities();
            CUSTOMER = Db_gsj.O_CUSTOMER.Single(t => t.CUSTOMER_CD == CUSTOMER.CUSTOMER_CD);
            CUSTOMER.ACTIVE = true;
            Db_gsj.Entry(CUSTOMER).State = EntityState.Modified;
            Db_gsj.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}