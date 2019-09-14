namespace SistemaGeradorOrcamento.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InlusaoClassesc : DbMigration
    {
        public override void Up()
        {
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
                        Quantidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaterialId);
            
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
            DropTable("dbo.Servicos");
            DropTable("dbo.Materiais");
        }
    }
}
