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
        private BaseDataService<Producto> db;

        public ProductoController()
        {
            db = new BaseDataService<Producto>();
        }
        
        // GET: Producto
        public ActionResult Index()
        {
            var list = db.Get();
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
            //Fecha y hora actual
            DateTime localDate = DateTime.Now;

            //Instancio un nuevo producto
            var objProd = new Producto();

            //Guardo en el objeto producto los valores ingresados en cada campo del formulario
            objProd.Id = Convert.ToInt32(form["codigo"]);
            objProd.Title = form["title"];
            objProd.Description = form["description"];
            objProd.MarcaId = Convert.ToInt32(form["marcaid"]);
            objProd.Image = form["image"];
            objProd.Price = Convert.ToDouble(form["price"]);
            objProd.AvgStars = Convert.ToDouble(form["AvgStars"]);
            objProd.CreatedOn = localDate;
            objProd.CreatedBy = "SROM";
            objProd.ChangedOn = localDate;
            objProd.ChangedBy = "SROM";

            db.Create(objProd);

            var list = db.Get();

            return RedirectToAction("Index");
        }
    }
}