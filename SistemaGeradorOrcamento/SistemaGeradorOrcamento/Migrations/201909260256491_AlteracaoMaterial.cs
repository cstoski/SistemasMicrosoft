namespace SistemaGeradorOrcamento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteracaoMaterial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orcamentos", "versao", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orcamentos", "versao");
        }
    }
}
