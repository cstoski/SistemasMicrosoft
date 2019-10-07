using SistemaGeradorOrcamento.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGeradorOrcamento.DAL
{
    class ProjetoDao
    {
        private static Context ctx = SingletonContext.GetInstance();

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
            return ctx.Projetos.Include("Cliente").Include("listaOrcamento").FirstOrDefault
                (x => x.NumeroProjeto.Equals(p.NumeroProjeto));
        }

        public static Projeto BuscarProjetoPorNumeroString(string p)
        {
            return ctx.Projetos.FirstOrDefault
                (x => x.NumeroProjeto.Equals(p));
        }

        public static bool AlterarProjeto(Projeto p)
        {
            if (BuscarProjetoPorNumero(p) != null)
            {
                ctx.Entry(p).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public static Orcamento BuscaOrcamentoProjeto(Projeto p)
        {
            //Busca o Projeto
            p = BuscarProjetoPorNumero(p);
            
            Orcamento orcamento = ctx.Orcamentos.Include("servico.Servico").Include("material.Material").FirstOrDefault
                (x => x.OrcamentoId.Equals(p.ProjetoId));

            return orcamento;

        }

        public static List<Projeto> ListarTodosProjetos() => ctx.Projetos.Include("Cliente").ToList();
        
        public static string GerarNumeroProjeto(Projeto projeto)
        {
            string nSequencial = "";
            string numeroProjeto = "";
            StringBuilder sb = new StringBuilder();
            String letrasIniciais = "ADS-";

            //Extração de Data e Hora
            string ano = (DateTime.Now.Year).ToString().Substring(2,2);
            string mes = (DateTime.Now.Month).ToString("D2");
            
            //Quantidade de Registros +1
            nSequencial = (ctx.Projetos.Count() + 1).ToString("D3");

            //Concatena todos os dados (ADS-YYMMSSS)
            sb.Append(letrasIniciais);
            sb.Append(ano);
            sb.Append(mes);
            sb.Append(nSequencial);
            
            numeroProjeto = sb.ToString();
                
            return numeroProjeto;
        }

    }
}
