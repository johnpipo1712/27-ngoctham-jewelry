using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using W_GJS.Models;
namespace W_GJS.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        public GJSEntities Db_gsj;
        public ActionResult Index()
        {
            Db_gsj = new GJSEntities();
            return View(Db_gsj.O_ORDER);
        }
	}
}