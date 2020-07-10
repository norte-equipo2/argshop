using HardwarePC.Data.Model;
using HardwarePC.Data.Services;
using HardwarePC.WebSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HardwarePC.WebSite.Controllers
{
    [Authorize]
    public class  ProductoController : BaseController
    {

        private readonly BaseDataService<Product> MyContext = new BaseDataService<Product>();
        private readonly ArtShopDbContext db = new ArtShopDbContext();

        public ProductoController()
        {

        }

        // GET: Producto
        public ActionResult Index()
        {
            var products = MyContext.Get(null, null, "Artist");
            return View(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(db.Artist, "Id", "FullName");
            return View();
        }

        //ActionResult para el botón Grabar del formulario de producto
        [HttpPost]
        public ActionResult Create(Product producto)
        {
            this.CheckAuditPattern(producto, true);
            var listModel = MyContext.ValidateModel(producto);
            if (ModelIsValid(listModel))
                return View(producto);
            try
            {
                MyContext.Create(producto);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(producto);
            }
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var producto = MyContext.GetById(id.Value);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        [HttpPost]
        public ActionResult Edit(Product producto)
        {
            this.CheckAuditPattern(producto);
            var listModel = MyContext.ValidateModel(producto);
            if (ModelIsValid(listModel))
                return View(producto);
            try
            {
                MyContext.Update(producto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(producto);
            }
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var producto = MyContext.GetById(id.Value);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        [HttpPost]
        public ActionResult Delete(Product producto)
        {
            try
            {
                MyContext.Delete(producto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(producto);
            }
        }
    }
}
