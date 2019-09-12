using SistemaGeradorOrcamento.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFVendas.Model
{
    class Context : DbContext
    {
        public Context() : base("SistemaOrcamento") { }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
