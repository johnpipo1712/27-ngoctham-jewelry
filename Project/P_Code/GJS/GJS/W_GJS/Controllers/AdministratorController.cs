using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using W_GJS.General;
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
            return View(new JsonResultLoginModel());
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            Db_gsj = new GJSEntities();

            JsonResultLoginModel jsonModel = LoginModel.Login(username, password, true);
            if (jsonModel.RoleOrFailed == 1) // admin logined
            {
                //store session if succeed
                Session[SessionConstants.LOGINED_ADMIN_KEY] = username;
                return RedirectToAction("Index");
            }

            return View(jsonModel);
        }

        public ActionResult FormSample()
        {
            return View();
        }
	}
}