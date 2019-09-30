using SistemaGeradorOrcamento.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGeradorOrcamento.DAL
{
    class OrcamentoDao
    {
        private static Context ctx = SingletonContext.GetInstance();

        private static List<Orcamento> orcamentos = new List<Orcamento>();

        private static Orcamento o = new Orcamento();

        public static void CadastrarMaterial(List<Material> mat)
        {

        }

        public static void CadastrarServico(ItensServico servico)
        {
            o.servico.Add(servico);
            
        }

        public static bool CadastrarOrcamento(Projeto projeto)
        {
           
            projeto.listaOrcamento.Add(o);
            ctx.Entry(projeto).State = EntityState.Modified;
            ctx.SaveChanges();
            
                        
            return true;
                     
        }
    }
}
