using System.Data.Entity;

namespace Cascada_Drop.Models
{
    public class Cascada_DropContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<Cascada_Drop.Models.Cascada_DropContext>());

        public Cascada_DropContext() : base("name=Cascada_DropContext")
        {
          
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<SubCategoria> SubCategorias { get; set; }
    }
}
