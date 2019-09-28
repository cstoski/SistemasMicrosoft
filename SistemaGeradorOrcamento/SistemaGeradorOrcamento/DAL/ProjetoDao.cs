using SistemaGeradorOrcamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGeradorOrcamento.DAL
{
    class ProjetoDao
    {
        private static Context ctx = new Context();

        public static bool CadastrarProjeto(Projeto p)
        {
            if (BuscarProjetoPorNumero(p) == null)
            {
                ctx.Projetos.Add(p);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

       
        public static Projeto BuscarProjetoPorNome(Projeto p)
        {
            return ctx.Projetos.FirstOrDefault
                (x => x.NomeProjeto.Equals(p.NomeProjeto));
        }

        public static Projeto BuscarProjetoPorNumero(Projeto p)
        {
            return ctx.Projetos.FirstOrDefault
                (x => x.NumeroProjeto.Equals(p.NumeroProjeto));
        }

    }
}
