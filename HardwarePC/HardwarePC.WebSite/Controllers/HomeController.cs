using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HardwarePC.WebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Covid_19()
        {
            ViewBag.Message = "COVID-19";

            return View();
        }

        public ActionResult Politica_garantia()
        {
            ViewBag.Message = "Nuestra Política de Garantía";

            return View();
        }
    }
}