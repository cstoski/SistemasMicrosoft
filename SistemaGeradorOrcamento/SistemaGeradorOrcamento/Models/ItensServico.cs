using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGeradorOrcamento.Models
{
    [Table("ListaDeServicos")]
    class ItensServico
    {
        public ItensServico(){
                criadoEm = DateTime.Now;
                servico = new Servico();
        }

        [Key] //Define chave primária 
        public int ItensServicosId { get; set; }
        public Servico servico { get; set; }
        public double preco { get; set; }
        public int quantidade { get; set; }
        public DateTime criadoEm { get; set; }
    }
}
