using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGeradorOrcamento.Models
{
    class ItensMaterial
    {
        public ItensMaterial()
        {
            criadoEm = DateTime.Now;
            material = new Material();
        }

        public Material material { get; set; }
        public double preco { get; set; }
        public int quantidade { get; set; }
        public DateTime criadoEm { get; set; }

    }
}

