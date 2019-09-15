using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGeradorOrcamento.Models
{
    class Orcamento
    {
        public Orcamento()
        {
            criadoEm = DateTime.Now;
            material = new List<ItensMaterial>();
            servico = new List<ItensServico>();
            usuario = new Usuario();
        }

        public Cliente cliente { get; set;}
        public Usuario usuario { get; set;}
        public List<ItensMaterial> material { get; set;}
        public List<ItensServico> servico { get; set;}
        public DateTime criadoEm { get; set;}
    }
}
