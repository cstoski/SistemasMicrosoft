using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGeradorOrcamento.Models
{
    [Table("ListaDeOrcamentos")]
    class itensOrcamento
    {
        public itensOrcamento()
        {
            criadoEm = DateTime.Now;
            orcamento = new Orcamento();                        
        }

        [Key] //Define chave primária 
        public int ItensOrcamentoId {get; set;}
        public Orcamento orcamento {get; set;}       
        public DateTime criadoEm {get; set;}

    }
}
