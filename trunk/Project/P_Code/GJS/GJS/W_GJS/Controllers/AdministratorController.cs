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
    public class AdministratorController : Controller
    {
        //
        // GET: /BRANCH/
        public GJSEntities Db_gsj;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult FormSample()
        {
            return View();
        }
	}
}