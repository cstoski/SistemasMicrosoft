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
        private static Context ctx = SingletonContext.GetInstance();




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

        public static Servico BuscarServicoPorNome(Servico s)
        {
             return ctx.Servicos.FirstOrDefault
             (x => x.Nome.Equals(s.Nome));
          
            
        }

        public static List<Servico> ListarServicos()
        {
            return ctx.Servicos.ToList();
        }
    }
}
