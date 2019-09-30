namespace SistemaGeradorOrcamento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ass : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ListaDeServicos", new[] { "orcamento_OrcamentoId" });
            DropIndex("dbo.Orcamentos", new[] { "projeto_ProjetoId" });
            CreateIndex("dbo.ListaDeServicos", "Orcamento_OrcamentoId");
            CreateIndex("dbo.Orcamentos", "Projeto_ProjetoId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Orcamentos", new[] { "Projeto_ProjetoId" });
            DropIndex("dbo.ListaDeServicos", new[] { "Orcamento_OrcamentoId" });
            CreateIndex("dbo.Orcamentos", "projeto_ProjetoId");
            CreateIndex("dbo.ListaDeServicos", "orcamento_OrcamentoId");
        }
    }
}
