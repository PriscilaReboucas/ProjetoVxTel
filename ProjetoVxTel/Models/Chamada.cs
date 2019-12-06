﻿using System;
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
        [Column("CodigoDDDOrigem")]
        public DDD DDDOrigem { get; set; }
        [Column("CodigoDDDDestino")]
        public DDD DDDDestino { get; set; }
        public Decimal ValorMinuto { get; set; }
    }
}