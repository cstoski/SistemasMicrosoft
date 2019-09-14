using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGeradorOrcamento.Models
{
    [Table("Projetos")]
    class Projeto
    {
        //Construtor da Classe
     public Projeto()
        {
            CriadoEm = DateTime.Now;
        }
        [Key] //Define chave primária 
        public int ProjetoId { get; set; }
        public DateTime CriadoEm { get; set; }

        public String NumeroProjeto { get; set; }
        public String NomeProjeto { get; set; }
        public String Cliente { get; set; }
        public enum status
        {
          [Description("Em Execução")] emExecucao,
          [Description("Aguardando Documentação")] aguardadoDocumentacao,
          [Description("Enviado ao Cliente")] enviadoAoCliente,
          [Description("Fechado")] fechado,
          [Description("Suspenso")] suspenso,
          [Description("Cancelado")] cancelado
        }
        //public List<Orcamento> listaOrcamento { get; set; }

    }
}
