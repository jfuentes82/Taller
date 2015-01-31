namespace Cascada_Drop.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Cascada_Drop.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Cascada_Drop.Models.Cascada_DropContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Cascada_Drop.Models.Cascada_DropContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            List<Categoria> categories = new List<Categoria>
            {
                new Categoria { Nombre = "Comida", Descripcion="Comida" },
                new Categoria { Nombre = "Electronico",Descripcion="Electronico" },
                new Categoria { Nombre = "Hogar",Descripcion="Hogar" }
            };

            List<SubCategoria> subcategories = new List<SubCategoria>
            {
                new SubCategoria { Nombre = "Vegetales", Categoria = categories.Find(m => m.Nombre.Equals("Comida")) },
                new SubCategoria { Nombre = "Frutas", Categoria = categories.Find(m => m.Nombre.Equals("Comida")) },
                new SubCategoria { Nombre = "Computador", Categoria = categories.Find(m => m.Nombre.Equals("Electronico")) },
                new SubCategoria { Nombre = "Television", Categoria = categories.Find(m => m.Nombre.Equals("Electronico")) },
                new SubCategoria { Nombre = "Camas", Categoria = categories.Find(m => m.Nombre.Equals("Hogar")) },
                new SubCategoria { Nombre = "Cuadros", Categoria = categories.Find(m => m.Nombre.Equals("Hogar")) },
            };

            List<Producto> products = new List<Producto>
            {
                new Producto { Nombre = "Lechuga",  Descripcion = "Lechuga", SubCategoria = subcategories.Find(m => m.Nombre.Equals("Vegetales")) },
                new Producto { Nombre = "Manzana", Descripcion = "Manzana", SubCategoria = subcategories.Find(m => m.Nombre.Equals("Frutas")) },
                new Producto { Nombre = "PC-1", Descripcion = "Desktop", SubCategoria = subcategories.Find(m => m.Nombre.Equals("Computador")) },
                new Producto { Nombre = "LG", Descripcion = "LG", SubCategoria = subcategories.Find(m => m.Nombre.Equals("Television")) },
                new Producto { Nombre = "BOX", Descripcion = "BOX", SubCategoria = subcategories.Find(m => m.Nombre.Equals("Camas")) },
                new Producto { Nombre = "Mona Lisa", Descripcion = "Mona Lisa", SubCategoria = subcategories.Find(m => m.Nombre.Equals("Cuadros")) },
            };

            categories.ForEach(m => context.Categorias.Add(m));
            subcategories.ForEach(m => context.SubCategorias.Add(m));
            products.ForEach(m => context.Productos.Add(m));

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
