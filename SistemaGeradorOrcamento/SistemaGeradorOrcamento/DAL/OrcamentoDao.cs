using SistemaGeradorOrcamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGeradorOrcamento.DAL
{
    class OrcamentoDao
    {
        private static Context ctx = SingletonContext.GetInstance();

        private static List<Orcamento> orcamento = new List<Orcamento>();

        public static void CadastrarMaterial(List<Material> mat) {

            
           
        }

        public static bool CadastrarOrcamento(Orcamento orcamento)
        {
           ctx.Orcamentos.Add(orcamento);
           ctx.SaveChanges();
           return true;
                     
        }
    }
}
