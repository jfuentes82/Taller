using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManagingMultijQueryForm.Models;

namespace ManagingMultijQueryForm.Controllers
{
    public class CategoryController : Controller
    {
        ProductDbContext db = new ProductDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Get(int id)
        {
            var category = db.Category.Find(id);

            return Json(new { Id = category.CategoryID, Name = category.Name }, "application/json", JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult List()
        {
            return PartialView("_CategoryList", db.Category.ToList());
        }

        [HttpPost]
        public PartialViewResult List(string s)
        {
            return PartialView("_CategoryList", db.Category.Where(m => m.Name.Contains(s)).ToList());
        }

        public PartialViewResult Add()
        {
            return PartialView("_Category");
        }

        [HttpPost, ValidationActionFilter]
        public PartialViewResult Add(Category model)
        {
            db.Category.Add(model);
            db.SaveChanges();

            return Add();
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var category = db.Category.Find(id);

            db.Category.Remove(category);
            db.SaveChanges();

            return Json(new { success = true, message = "Record deleted successfully!" }, "application/json", JsonRequestBehavior.AllowGet);
        }
    }
}
