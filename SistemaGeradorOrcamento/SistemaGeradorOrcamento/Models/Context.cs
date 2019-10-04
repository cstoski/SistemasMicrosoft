using System.Data.Entity;

namespace SistemaGeradorOrcamento.Models
{
    class Context : DbContext
    {
        public Context() : base("SistemaOrcamento") { }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Material> Materiais { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Orcamento> Orcamentos {get; set;}
        
    }
}
