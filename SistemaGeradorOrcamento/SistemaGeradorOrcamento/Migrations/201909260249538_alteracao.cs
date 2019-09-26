﻿namespace SistemaGeradorOrcamento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteracao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orcamentos",
                c => new
                    {
                        OrcamentoId = c.Int(nullable: false, identity: true),
                        criadoEm = c.DateTime(nullable: false),
                        cliente_ClienteId = c.Int(),
                        usuario_UsuarioId = c.Int(),
                        Projeto_ProjetoId = c.Int(),
                    })
                .PrimaryKey(t => t.OrcamentoId)
                .ForeignKey("dbo.Clientes", t => t.cliente_ClienteId)
                .ForeignKey("dbo.Usuarios", t => t.usuario_UsuarioId)
                .ForeignKey("dbo.Projetos", t => t.Projeto_ProjetoId)
                .Index(t => t.cliente_ClienteId)
                .Index(t => t.usuario_UsuarioId)
                .Index(t => t.Projeto_ProjetoId);
            
            CreateTable(
                "dbo.ListaDeMateriais",
                c => new
                    {
                        ItensMateriaisId = c.Int(nullable: false, identity: true),
                        preco = c.Double(nullable: false),
                        quantidade = c.Int(nullable: false),
                        criadoEm = c.DateTime(nullable: false),
                        material_MaterialId = c.Int(),
                        Orcamento_OrcamentoId = c.Int(),
                    })
                .PrimaryKey(t => t.ItensMateriaisId)
                .ForeignKey("dbo.Materiais", t => t.material_MaterialId)
                .ForeignKey("dbo.Orcamentos", t => t.Orcamento_OrcamentoId)
                .Index(t => t.material_MaterialId)
                .Index(t => t.Orcamento_OrcamentoId);
            
            CreateTable(
                "dbo.ListaDeServicos",
                c => new
                    {
                        ItensServicosId = c.Int(nullable: false, identity: true),
                        preco = c.Double(nullable: false),
                        quantidade = c.Int(nullable: false),
                        criadoEm = c.DateTime(nullable: false),
                        servico_ServicolId = c.Int(),
                        Orcamento_OrcamentoId = c.Int(),
                    })
                .PrimaryKey(t => t.ItensServicosId)
                .ForeignKey("dbo.Servicos", t => t.servico_ServicolId)
                .ForeignKey("dbo.Orcamentos", t => t.Orcamento_OrcamentoId)
                .Index(t => t.servico_ServicolId)
                .Index(t => t.Orcamento_OrcamentoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orcamentos", "Projeto_ProjetoId", "dbo.Projetos");
            DropForeignKey("dbo.Orcamentos", "usuario_UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.ListaDeServicos", "Orcamento_OrcamentoId", "dbo.Orcamentos");
            DropForeignKey("dbo.ListaDeServicos", "servico_ServicolId", "dbo.Servicos");
            DropForeignKey("dbo.ListaDeMateriais", "Orcamento_OrcamentoId", "dbo.Orcamentos");
            DropForeignKey("dbo.ListaDeMateriais", "material_MaterialId", "dbo.Materiais");
            DropForeignKey("dbo.Orcamentos", "cliente_ClienteId", "dbo.Clientes");
            DropIndex("dbo.ListaDeServicos", new[] { "Orcamento_OrcamentoId" });
            DropIndex("dbo.ListaDeServicos", new[] { "servico_ServicolId" });
            DropIndex("dbo.ListaDeMateriais", new[] { "Orcamento_OrcamentoId" });
            DropIndex("dbo.ListaDeMateriais", new[] { "material_MaterialId" });
            DropIndex("dbo.Orcamentos", new[] { "Projeto_ProjetoId" });
            DropIndex("dbo.Orcamentos", new[] { "usuario_UsuarioId" });
            DropIndex("dbo.Orcamentos", new[] { "cliente_ClienteId" });
            DropTable("dbo.ListaDeServicos");
            DropTable("dbo.ListaDeMateriais");
            DropTable("dbo.Orcamentos");
        }
    }
}
