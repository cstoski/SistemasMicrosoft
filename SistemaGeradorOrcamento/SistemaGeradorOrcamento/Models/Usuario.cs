using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGeradorOrcamento.Models
{
    [Table("Usuarios")]
    class Usuario
    {
        public Usuario()
        {
            CriadoEm = DateTime.Now;
        }

        [Key] //Define chave primária 
        public int UsuarioId { get; set; }
        public DateTime CriadoEm { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Matricula { get; set; }
        public String Departamento { get; set; }
        public String Senha { get; set; }

    }
}
