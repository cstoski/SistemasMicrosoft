using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGeradorOrcamento.Models
{
    //teste
    /// <summary>
    /// 
    /// </summary>
    [Table("Clientes")]
    class Cliente
    {
        [Key] //Define chave primária 
        public int clienteId { get; set; }
        public DateTime CriadoEm { get; set; }
        public String nomeCliente { get; set; }
        public String contato { get; set; }
        public String telefone { get; set; }

        //Comentários
       
    }
}
