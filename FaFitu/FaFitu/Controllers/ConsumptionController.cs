using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FaFitu.Controllers
{
    public class ConsumptionController : Controller
    {
        //
        // GET: /Consumption/

        public ActionResult Index()
        {
            if (false /*user filled in their weight etc*/)
                return View();
            else
                return RedirectToAction("Index", "UserPanel");
        }

    }
}
