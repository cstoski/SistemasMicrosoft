using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGeradorOrcamento.Models
{
    [Table("ListaDeMateriais")]
    class ItensMaterial
    {
        public ItensMaterial()
        {
            criadoEm = DateTime.Now;
            material = new Material();
        }
        [Key] //Define chave primária 
        public int ItensMateriaisId { get; set; }
        public Material material { get; set; }
        public double preco { get; set; }
        public int quantidade { get; set; }
        public DateTime criadoEm { get; set; }

    }
}

