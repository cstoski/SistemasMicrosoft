namespace SistemaGeradorOrcamento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtuazçãoMatriai : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ListaDeMateriais", "preco", c => c.Double(nullable: false));
            AddColumn("dbo.ListaDeServicos", "preco", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ListaDeServicos", "preco");
            DropColumn("dbo.ListaDeMateriais", "preco");
        }
    }
}
