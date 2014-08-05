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
    public class BranchController : Controller
    {
        //
        // GET: /Branch/
        public GJSEntities Db_gsj;
        public ActionResult Index()
        {
            Db_gsj = new GJSEntities();
            return View(Db_gsj.O_BRANCH);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(O_BRANCH branch)
        {
            if (ModelState.IsValid)
            {
                Db_gsj = new GJSEntities();
                branch.ACTIVE = true;
                branch.STATUS = 0;
                branch.CREATEDATE= DateTime.Now;
                Db_gsj.Entry(branch).State = EntityState.Added;
                Db_gsj.SaveChanges();
                return RedirectToAction("Index");
     
            }
            else
            {
                return View(branch);
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
            O_BRANCH branch_edit = Db_gsj.O_BRANCH.Single(t => t.BRANCH_CD == BRANCH_CD);
            if (branch_edit == null)
                return HttpNotFound();
            return View(branch_edit);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(O_BRANCH branch)
        {
            if (ModelState.IsValid)
            {
                Db_gsj = new GJSEntities();
                O_BRANCH branch_edit = Db_gsj.O_BRANCH.Single(t => t.BRANCH_CD == branch.BRANCH_CD);
                branch_edit.BRANCH_CODE = branch.BRANCH_CODE;
                branch_edit.BRANCH_NAME = branch.BRANCH_NAME;
                branch_edit.CITIES_CD = branch.CITIES_CD;
                branch_edit.ADDRESS = branch.ADDRESS;
                branch_edit.LATITUDE = branch.LATITUDE;
                branch_edit.LONGITUDE = branch.LONGITUDE;
                branch_edit.PHONE = branch.PHONE;
                Db_gsj.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return View(branch);
            }
        }


        public ActionResult Deactive([Bind(Include = "BRANCH_CD")]O_BRANCH branch)
        {
            if (branch == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Db_gsj = new GJSEntities();
            branch = Db_gsj.O_BRANCH.Single(t => t.BRANCH_CD == branch.BRANCH_CD);
            branch.ACTIVE = false;
            Db_gsj.Entry(branch).State = EntityState.Modified;
            Db_gsj.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Active([Bind(Include = "BRANCH_CD")]O_BRANCH branch)
        {
            if (branch == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Db_gsj = new GJSEntities();
            branch = Db_gsj.O_BRANCH.Single(t => t.BRANCH_CD == branch.BRANCH_CD);
            branch.ACTIVE = true;
            Db_gsj.Entry(branch).State = EntityState.Modified;
            Db_gsj.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}