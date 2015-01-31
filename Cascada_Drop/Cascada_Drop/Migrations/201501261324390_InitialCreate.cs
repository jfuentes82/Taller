namespace Cascada_Drop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(nullable: false, maxLength: 250),
                        SubCategoriaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.SubCategorias", t => t.SubCategoriaID, cascadeDelete: true)
                .Index(t => t.SubCategoriaID);
            
            CreateTable(
                "dbo.SubCategorias",
                c => new
                    {
                        SubCategoriaID = c.Int(nullable: false, identity: true),
                        CategoriaID = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.SubCategoriaID)
                .ForeignKey("dbo.Categorias", t => t.CategoriaID, cascadeDelete: true)
                .Index(t => t.CategoriaID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.SubCategorias", new[] { "CategoriaID" });
            DropIndex("dbo.Productoes", new[] { "SubCategoriaID" });
            DropForeignKey("dbo.SubCategorias", "CategoriaID", "dbo.Categorias");
            DropForeignKey("dbo.Productoes", "SubCategoriaID", "dbo.SubCategorias");
            DropTable("dbo.SubCategorias");
            DropTable("dbo.Productoes");
            DropTable("dbo.Categorias");
        }
    }
}
