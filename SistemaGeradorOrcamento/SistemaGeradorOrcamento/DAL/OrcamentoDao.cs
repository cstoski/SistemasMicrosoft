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

        private static Orcamento orcamento1 = new Orcamento();

        public static void CadastrarMaterial(ItensMaterial listamaterial)
        {
            orcamento1.material.Add(listamaterial);
        }

        public static void CadastrarServico(ItensServico listaServico)
        {
            orcamento1.servico.Add(listaServico);
        }

        public static bool CadastrarOrcamento(Projeto projeto)
        {
            itensOrcamento io = new itensOrcamento
            {
                orcamento = orcamento1
            };
            
            projeto.listaOrcamento.Add(io);
            ctx.Projetos.Add(projeto);
            //ctx.Entry(projeto).State = EntityState.Modified;
            ctx.SaveChanges();
                                    
            return true;
                     
        }
    }
}
