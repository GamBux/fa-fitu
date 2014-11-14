using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FaFitu.Controllers
{
    public class FoodController : Controller
    {
        //
        // GET: /Food/
        public ActionResult Index()
        {
            return RedirectToAction("Dishes");
        }

        // GET: /Food/Dishes
        public ActionResult Dishes()
        {
            return View();
        }

        // GET: /Food/Ingredients
        public ActionResult Ingredients()
        {
            return View();
        }
    }
}
