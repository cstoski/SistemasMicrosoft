using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGeradorOrcamento.Models
{
    [Table("Orcamentos")]
    class Orcamento
    {
        
        public Orcamento()
        {
            criadoEm = DateTime.Now;
            material = new List<ItensMaterial>();
            servico = new List<ItensServico>();
            usuario = new Usuario();
            versao = 0;
        }
        [Key] //Define chave primária 
        public int OrcamentoId { get; set; }
        public int versao { get; set; }
        public Cliente cliente { get; set;}
        public Usuario usuario { get; set;}
        public List<ItensMaterial> material { get; set;}
        public List<ItensServico> servico { get; set;}
        public DateTime criadoEm { get; set;}
    }
}
