using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGeradorOrcamento.Models
{
    [Table("Projetos")]
    class Projeto
    {
        //Construtor da Classe
     public Projeto()
        {
            CriadoEm = DateTime.Now;
            listaOrcamento = new List<itensOrcamento>();
        }
        [Key] //Define chave primária 
        public int ProjetoId { get; set; }
        public DateTime CriadoEm { get; set; }
        public String NumeroProjeto { get; set; }
        public String NomeProjeto { get; set; }
        public Cliente Cliente { get; set; }
        public String Status { get; set; }
        public List<itensOrcamento> listaOrcamento { get; set; }
        

    }
}
