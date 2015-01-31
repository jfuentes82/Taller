using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManagingMultijQueryForm.Models;

namespace ManagingMultijQueryForm.Controllers
{
    public class ProductController : Controller
    {
        ProductDbContext db = new ProductDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return PartialView("_ProductList", db.Product.ToList());
        }

        public ActionResult Chao()
        {
            return View();
        }



        public PartialViewResult Add()
        {
            return PartialView("_Product");
        }

        [HttpPost, ValidationActionFilter]
        public PartialViewResult Add(Product model,FormCollection form=null)
        {
            db.Product.Add(model);
            db.SaveChanges();

            return Add();
        }

        public PartialViewResult Edit(int id)
        {
            return PartialView("_Product", db.Product.Find(id));
        }

        [HttpPost, ValidationActionFilter]
        public PartialViewResult Edit(Product model)
        {
            var product = db.Product.Find(model.ProductID);

            db.Entry(product).CurrentValues.SetValues(model);
            db.SaveChanges();

            return Add();
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var product = db.Product.Find(id);

            db.Product.Remove(product);
            db.SaveChanges();

            return Json(new { success = true, message = "Record deleted successfully!" }, "application/json", JsonRequestBehavior.AllowGet);
        }
    }
}
