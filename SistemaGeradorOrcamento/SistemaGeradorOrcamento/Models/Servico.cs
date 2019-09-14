using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGeradorOrcamento.Models
{

    [Table("Servicos")]
    class Servico
    {
        public Servico()
        {
            CriadoEm = DateTime.Now;
        }

        [Key] //Define chave primária 
        public int ServicolId { get; set; }
        public DateTime CriadoEm { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public double Valor { get; set; }
        public String Tipo { get; set; }
    }
}
