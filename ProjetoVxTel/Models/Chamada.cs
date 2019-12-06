using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoVxTel.Models
{
    public class Chamada
    {
        [Key]
        public int Id { get; set; }       
        public int CodigoDDDOrigem { get; set; }
        public DDD DDDOrigem { get; set; }      
        public int CodigoDDDDestino { get; set; }
        public DDD DDDDestino { get; set; }
        public Decimal ValorMinuto { get; set; }
    }
}
