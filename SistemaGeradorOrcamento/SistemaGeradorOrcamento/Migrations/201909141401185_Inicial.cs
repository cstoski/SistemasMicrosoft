namespace SistemaGeradorOrcamento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        clienteId = c.Int(nullable: false, identity: true),
                        CriadoEm = c.DateTime(nullable: false),
                        nomeCliente = c.String(),
                        contato = c.String(),
                        telefone = c.String(),
                    })
                .PrimaryKey(t => t.clienteId);
            
            CreateTable(
                "dbo.Projetos",
                c => new
                    {
                        projetoId = c.Int(nullable: false, identity: true),
                        CriadoEm = c.DateTime(nullable: false),
                        numeroProjeto = c.String(),
                        nomeProjeto = c.String(),
                        cliente = c.String(),
                    })
                .PrimaryKey(t => t.projetoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Projetos");
            DropTable("dbo.Clientes");
        }
    }
}
