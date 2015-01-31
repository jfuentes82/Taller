namespace Cascada_Drop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelo_01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categorias", "Descripcion", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categorias", "Descripcion");
        }
    }
}
