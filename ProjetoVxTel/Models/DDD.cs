using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoVxTel.Models
{
    public class DDD
    {
        [Key]
        public int? Codigo { get; set; }
        public string Nome { get; set; }
    }
}