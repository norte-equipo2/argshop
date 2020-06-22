using HardwarePC.Data.Model;
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

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //ActionResult para el botón Grabar del formulario de producto
        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            //Instancio un nuevo producto
            var objProd = new Producto();

            //Guardo en el objeto producto los valores ingresados en cada campo del formulario
            objProd.Id = Convert.ToInt32(form["codigo"]);
            objProd.Name = form["nombre"];
            objProd.Category = form["categoria"];

            db.Insert(objProd);

            var list = db.GetAll();

            return RedirectToAction("Index");
        }
    }
}