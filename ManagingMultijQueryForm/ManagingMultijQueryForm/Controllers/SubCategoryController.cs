using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManagingMultijQueryForm.Models;

namespace ManagingMultijQueryForm.Controllers
{
    public class SubCategoryController : Controller
    {
        ProductDbContext db = new ProductDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Get(int id)
        {
            var subcategory  = db.SubCategory.Find(id);

            return Json(new { Id = subcategory.SubCategoryID, Name = subcategory.Name }, "application/json", JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult List()
        {
            return PartialView("_SubCategoryList", db.SubCategory.ToList());
        }

        [HttpPost]
        public PartialViewResult List(string s)
        {
            return PartialView("_SubCategoryList", db.SubCategory.Where(m => m.Name.Contains(s) || m.Category.Name.Contains(s)).ToList());
        }

        public PartialViewResult Add()
        {
            return PartialView("_SubCategory");
        }

        [HttpPost, ValidationActionFilter]
        public PartialViewResult Add(SubCategory model)
        {
            db.SubCategory.Add(model);
            db.SaveChanges();

            return Add();
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var subcategory = db.SubCategory.Find(id);

            db.SubCategory.Remove(subcategory);
            db.SaveChanges();

            return Json(new { success = true, message = "Record deleted successfully!" }, "application/json", JsonRequestBehavior.AllowGet);
        }
    }
}
