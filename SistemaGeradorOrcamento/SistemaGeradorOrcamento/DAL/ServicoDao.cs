using SistemaGeradorOrcamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGeradorOrcamento.DAL
{
    class ServicoDao
    {
        private static Context ctx = new Context();

        public static bool CadastrarServico(Servico s)
        {
            if (BuscarServicoPorNome(s) == null)
            {
                ctx.Servicos.Add(s);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public static Material BuscarServicoPorNome(Servico s)
        {
            return ctx.Materiais.FirstOrDefault
                (x => x.Nome.Equals(s.Nome));
        }
    }
}
