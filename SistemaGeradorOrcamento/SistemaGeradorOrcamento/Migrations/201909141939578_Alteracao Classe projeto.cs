namespace SistemaGeradorOrcamento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteracaoClasseprojeto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projetos", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projetos", "Status");
        }
    }
}
