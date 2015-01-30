using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ManagingMultijQueryForm.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }

        public virtual SubCategory SubCategory { get; set; }

        [Display(Name = "Sub Category")]
        public int SubCategoryID { get; set; }
    }

    public class Category
    {
        public int CategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }

    public class SubCategory
    {
        public int SubCategoryID { get; set; }

        public virtual Category Category { get; set; }

        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }

    public class ProductDbContext : DbContext
    {
        public ProductDbContext()
            : base(nameOrConnectionString: "Data Source=PCI7-JFUENTES\\SQL_JF;Initial Catalog=Taller;Integrated Security=true;")
        {
            Database.SetInitializer(new ProductDbContextInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Use singular table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
    }

    public class ProductDbContextInitializer : DropCreateDatabaseIfModelChanges<ProductDbContext>
    {
        protected override void Seed(ProductDbContext context)
        {
            List<Category> categories = new List<Category>
            {
                new Category { Name = "Food" },
                new Category { Name = "Electronics" },
                new Category { Name = "Beverages" }
            };

            List<SubCategory> subcategories = new List<SubCategory>
            {
                new SubCategory { Name = "Vegetables", Category = categories.Find(m => m.Name.Equals("Food")) },
                new SubCategory { Name = "Fruits", Category = categories.Find(m => m.Name.Equals("Food")) },
                new SubCategory { Name = "Computer", Category = categories.Find(m => m.Name.Equals("Electronics")) },
                new SubCategory { Name = "Television", Category = categories.Find(m => m.Name.Equals("Electronics")) },
                new SubCategory { Name = "Cold Drinks", Category = categories.Find(m => m.Name.Equals("Beverages")) },
                new SubCategory { Name = "Beer", Category = categories.Find(m => m.Name.Equals("Beverages")) },
            };

            List<Product> products = new List<Product>
            {
                new Product { Name = "Wheat", Description = "Wheat", SubCategory = subcategories.Find(m => m.Name.Equals("Vegetables")) },
                new Product { Name = "Apple", Description = "Apple", SubCategory = subcategories.Find(m => m.Name.Equals("Fruits")) },
                new Product { Name = "Desktop", Description = "Desktop", SubCategory = subcategories.Find(m => m.Name.Equals("Computer")) },
                new Product { Name = "LG", Description = "LG", SubCategory = subcategories.Find(m => m.Name.Equals("Television")) },
                new Product { Name = "Sprite", Description = "Sprite", SubCategory = subcategories.Find(m => m.Name.Equals("Cold Drinks")) },
                new Product { Name = "Kingfisher", Description = "Kingfisher", SubCategory = subcategories.Find(m => m.Name.Equals("Beer")) },
            };

            categories.ForEach(m => context.Category.Add(m));
            subcategories.ForEach(m => context.SubCategory.Add(m));
            products.ForEach(m => context.Product.Add(m));

            context.SaveChanges();

            base.Seed(context);
        }
    }
}