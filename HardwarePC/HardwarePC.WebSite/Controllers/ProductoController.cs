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
        BaseDataService<Producto> db;

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

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var producto = db.GetById(id.Value);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        [HttpPost]
        public ActionResult Edit(Producto producto)
        {
            this.CheckAuditPattern(producto);
            var listModel = db.ValidateModel(producto);
            if (ModelIsValid(listModel))
                return View(producto);
            try
            {
                db.Update(producto);
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
            var producto = db.GetById(id.Value);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        [HttpPost]
        public ActionResult Delete(Producto producto)
        {
            try
            {
                db.Delete(producto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(producto);
            }
        }


        //ActionResult para el botón Grabar del formulario de producto
        [HttpPost]
        public ActionResult Create(Producto producto)
        {
            this.CheckAuditPattern(producto, true);
            var listModel = db.ValidateModel(producto);
            if (ModelIsValid(listModel))
                return View(producto);
            try
            {
                db.Create(producto);
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
