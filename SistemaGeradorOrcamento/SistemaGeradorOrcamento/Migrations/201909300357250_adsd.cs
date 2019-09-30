namespace SistemaGeradorOrcamento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adsd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        CriadoEm = c.DateTime(nullable: false),
                        NomeCliente = c.String(),
                        Contato = c.String(),
                        Telefone = c.String(),
                    })
                .PrimaryKey(t => t.ClienteId);
            
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
                "dbo.Materiais",
                c => new
                    {
                        MaterialId = c.Int(nullable: false, identity: true),
                        CriadoEm = c.DateTime(nullable: false),
                        Nome = c.String(),
                        Codigo = c.String(),
                        Descricao = c.String(),
                        Fabricante = c.String(),
                        Valor = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.MaterialId);
            
            CreateTable(
                "dbo.ListaDeServicos",
                c => new
                    {
                        ItensServicosId = c.Int(nullable: false, identity: true),
                        preco = c.Double(nullable: false),
                        quantidade = c.Int(nullable: false),
                        criadoEm = c.DateTime(nullable: false),
                        orcamento_OrcamentoId = c.Int(),
                        servico_ServicolId = c.Int(),
                    })
                .PrimaryKey(t => t.ItensServicosId)
                .ForeignKey("dbo.Orcamentos", t => t.orcamento_OrcamentoId)
                .ForeignKey("dbo.Servicos", t => t.servico_ServicolId)
                .Index(t => t.orcamento_OrcamentoId)
                .Index(t => t.servico_ServicolId);
            
            CreateTable(
                "dbo.Orcamentos",
                c => new
                    {
                        OrcamentoId = c.Int(nullable: false, identity: true),
                        versao = c.Int(nullable: false),
                        criadoEm = c.DateTime(nullable: false),
                        projeto_ProjetoId = c.Int(),
                        usuario_UsuarioId = c.Int(),
                    })
                .PrimaryKey(t => t.OrcamentoId)
                .ForeignKey("dbo.Projetos", t => t.projeto_ProjetoId)
                .ForeignKey("dbo.Usuarios", t => t.usuario_UsuarioId)
                .Index(t => t.projeto_ProjetoId)
                .Index(t => t.usuario_UsuarioId);
            
            CreateTable(
                "dbo.Projetos",
                c => new
                    {
                        ProjetoId = c.Int(nullable: false, identity: true),
                        CriadoEm = c.DateTime(nullable: false),
                        NumeroProjeto = c.String(),
                        NomeProjeto = c.String(),
                        Status = c.String(),
                        Cliente_ClienteId = c.Int(),
                    })
                .PrimaryKey(t => t.ProjetoId)
                .ForeignKey("dbo.Clientes", t => t.Cliente_ClienteId)
                .Index(t => t.Cliente_ClienteId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        CriadoEm = c.DateTime(nullable: false),
                        Nome = c.String(),
                        Email = c.String(),
                        Matricula = c.String(),
                        Departamento = c.String(),
                        Senha = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Servicos",
                c => new
                    {
                        ServicolId = c.Int(nullable: false, identity: true),
                        CriadoEm = c.DateTime(nullable: false),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Valor = c.Double(nullable: false),
                        Tipo = c.String(),
                    })
                .PrimaryKey(t => t.ServicolId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ListaDeServicos", "servico_ServicolId", "dbo.Servicos");
            DropForeignKey("dbo.Orcamentos", "usuario_UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.ListaDeServicos", "orcamento_OrcamentoId", "dbo.Orcamentos");
            DropForeignKey("dbo.Orcamentos", "projeto_ProjetoId", "dbo.Projetos");
            DropForeignKey("dbo.Projetos", "Cliente_ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.ListaDeMateriais", "Orcamento_OrcamentoId", "dbo.Orcamentos");
            DropForeignKey("dbo.ListaDeMateriais", "material_MaterialId", "dbo.Materiais");
            DropIndex("dbo.Projetos", new[] { "Cliente_ClienteId" });
            DropIndex("dbo.Orcamentos", new[] { "usuario_UsuarioId" });
            DropIndex("dbo.Orcamentos", new[] { "projeto_ProjetoId" });
            DropIndex("dbo.ListaDeServicos", new[] { "servico_ServicolId" });
            DropIndex("dbo.ListaDeServicos", new[] { "orcamento_OrcamentoId" });
            DropIndex("dbo.ListaDeMateriais", new[] { "Orcamento_OrcamentoId" });
            DropIndex("dbo.ListaDeMateriais", new[] { "material_MaterialId" });
            DropTable("dbo.Servicos");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Projetos");
            DropTable("dbo.Orcamentos");
            DropTable("dbo.ListaDeServicos");
            DropTable("dbo.Materiais");
            DropTable("dbo.ListaDeMateriais");
            DropTable("dbo.Clientes");
        }
    }
}
