using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGeradorOrcamento.Models
{
    class ItensServico
    {
        public ItensServico()
        {
            criadoEm = DateTime.Now;
            servico = new Servico();
        }

        public Servico servico { get; set; }
        public double preco { get; set; }
        public int quantidade { get; set; }
        public DateTime criadoEm { get; set; }
    }
}
