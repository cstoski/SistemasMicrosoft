using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGeradorOrcamento.Models
{
    
    [Table("Clientes")]
    class Cliente
    {
        public Cliente()
        {
            CriadoEm = DateTime.Now;
        }

        [Key] //Define chave primária 
        public int ClienteId { get; set; }
        public DateTime CriadoEm { get; set; }
        public String NomeCliente { get; set; }
        public String Contato { get; set; }
        public String Telefone { get; set; }

        
       
    }
}
