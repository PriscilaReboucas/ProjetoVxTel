using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoVxTel.Models
{
    public class Plano
    {
        [Key]
        public int? Id { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeMinuto { get; set; }
    }
}