using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cascada_Drop.Models;

namespace Cascada_Drop.Controllers
{
    public class ProductoController : Controller
    {
        private Cascada_DropContext db = new Cascada_DropContext();

        //
        // GET: /Producto/

        public ActionResult Index()
        {
            //var productos = db.Productos.Include(p => p.SubCategoria);
            return View();
        }

        public ActionResult ListaProductos()
        {

            return PartialView("_ListaProducto", db.Productos.ToList());
        }



        public PartialViewResult AgregarProducto()
        {
            return PartialView("_Producto");
        }

        [HttpPost]
        public PartialViewResult AgregarProducto(Producto model,FormCollection form=null)
        {
            db.Productos.Add(model);
            db.SaveChanges();

            return AgregarProducto();
        }






        //
        // GET: /Producto/Details/5

        //public ActionResult Details(int id = 0)
        //{
        //    Producto producto = db.Productos.Find(id);
        //    if (producto == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(producto);
        //}

        ////
        //// GET: /Producto/Create

        //public ActionResult Create()
        //{
        //    ViewBag.SubCategoriaID = new SelectList(db.SubCategorias, "SubCategoriaID", "Nombre");
        //    return View();
        //}

        ////
        //// POST: /Producto/Create

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Producto producto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Productos.Add(producto);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.SubCategoriaID = new SelectList(db.SubCategorias, "SubCategoriaID", "Nombre", producto.SubCategoriaID);
        //    return View(producto);
        //}

        ////
        //// GET: /Producto/Edit/5

        //public ActionResult Edit(int id = 0)
        //{
        //    Producto producto = db.Productos.Find(id);
        //    if (producto == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.SubCategoriaID = new SelectList(db.SubCategorias, "SubCategoriaID", "Nombre", producto.SubCategoriaID);
        //    return View(producto);
        //}

        ////
        //// POST: /Producto/Edit/5

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Producto producto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(producto).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.SubCategoriaID = new SelectList(db.SubCategorias, "SubCategoriaID", "Nombre", producto.SubCategoriaID);
        //    return View(producto);
        //}

        ////
        //// GET: /Producto/Delete/5

        //public ActionResult Delete(int id = 0)
        //{
        //    Producto producto = db.Productos.Find(id);
        //    if (producto == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(producto);
        //}

        ////
        //// POST: /Producto/Delete/5

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Producto producto = db.Productos.Find(id);
        //    db.Productos.Remove(producto);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}