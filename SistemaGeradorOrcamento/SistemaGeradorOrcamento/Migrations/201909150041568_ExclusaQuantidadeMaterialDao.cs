namespace SistemaGeradorOrcamento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExclusaQuantidadeMaterialDao : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Materiais", "Quantidade");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Materiais", "Quantidade", c => c.Int(nullable: false));
        }
    }
}
