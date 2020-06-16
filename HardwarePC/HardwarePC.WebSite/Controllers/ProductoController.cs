using HardwarePC.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HardwarePC.WebSite.Controllers
{
    public class ProductoController : Controller
    {
        private IProductoData db;

        public ProductoController()
        {
            db = new InMemoryProductoData();
        }
        
        // GET: Producto
        public ActionResult Index()
        {
            var list = db.GetAll();
            return View(list);
        }
    }
}