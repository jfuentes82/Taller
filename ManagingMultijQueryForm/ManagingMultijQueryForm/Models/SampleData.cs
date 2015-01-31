using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagingMultijQueryForm.Models
{
    public class SampleData
    {
        public List<Product> productList;
        public List<SubCategory> productSubCategoryList;
        public List<Category> productCategoryList;

        public SampleData()
        {
            productCategoryList = GetCategories();
            productSubCategoryList = GetSubCategories();
            productList = GetProducts();
        }

        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { ProductID = 1, Name = "Wheat", Description = "Wheat", SubCategoryID = 1, SubCategory = productSubCategoryList.Find(m => m.SubCategoryID == 1) },
                new Product { ProductID = 2, Name = "Apple", Description = "Apple", SubCategoryID = 2, SubCategory = productSubCategoryList.Find(m => m.SubCategoryID == 2) },
                new Product { ProductID = 3, Name = "Desktop", Description = "Desktop", SubCategoryID = 3, SubCategory = productSubCategoryList.Find(m => m.SubCategoryID == 3) },
                new Product { ProductID = 4, Name = "LG", Description = "LG", SubCategoryID = 4, SubCategory = productSubCategoryList.Find(m => m.SubCategoryID == 4) },
                new Product { ProductID = 5, Name = "Sprite", Description = "Sprite", SubCategoryID = 5, SubCategory = productSubCategoryList.Find(m => m.SubCategoryID == 5) },
                new Product { ProductID = 6, Name = "Kingfisher", Description = "Kingfisher", SubCategoryID = 6, SubCategory = productSubCategoryList.Find(m => m.SubCategoryID == 6) },
            };
        }

        public List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category { CategoryID = 1, Name = "Food" },
                new Category { CategoryID = 2, Name = "Electronics" },
                new Category { CategoryID = 3, Name = "Beverages" }
            };
        }

        public List<SubCategory> GetSubCategories()
        {
            return new List<SubCategory>
            {
                new SubCategory { SubCategoryID = 1, CategoryID = 1, Name = "Vegetables", Category = productCategoryList.Find(m => m.CategoryID == 1) },
                new SubCategory { SubCategoryID = 2, CategoryID = 1, Name = "Fruits", Category = productCategoryList.Find(m => m.CategoryID == 1) },
                new SubCategory { SubCategoryID = 3, CategoryID = 2, Name = "Computer", Category = productCategoryList.Find(m => m.CategoryID == 2) },
                new SubCategory { SubCategoryID = 4, CategoryID = 2, Name = "Television", Category = productCategoryList.Find(m => m.CategoryID == 2) },
                new SubCategory { SubCategoryID = 5, CategoryID = 3, Name = "Cold Drinks", Category = productCategoryList.Find(m => m.CategoryID == 3) },
                new SubCategory { SubCategoryID = 6, CategoryID = 3, Name = "Beer", Category = productCategoryList.Find(m => m.CategoryID == 3) },
            };
        }

    }
}