namespace SistemaGeradorOrcamento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualização : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projetos", "Cliente_ClienteId", c => c.Int());
            CreateIndex("dbo.Projetos", "Cliente_ClienteId");
            AddForeignKey("dbo.Projetos", "Cliente_ClienteId", "dbo.Clientes", "ClienteId");
            DropColumn("dbo.Projetos", "Cliente");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projetos", "Cliente", c => c.String());
            DropForeignKey("dbo.Projetos", "Cliente_ClienteId", "dbo.Clientes");
            DropIndex("dbo.Projetos", new[] { "Cliente_ClienteId" });
            DropColumn("dbo.Projetos", "Cliente_ClienteId");
        }
    }
}
