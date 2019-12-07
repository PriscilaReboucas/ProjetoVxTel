using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoVxTel.Models
{
    public class SimulacaoPlano
    {
        public Plano Plano { get; set; }
        public Chamada Chamada { get; set; }
        public int Tempo { get; set; }
        public decimal? ValorComFaleMais { get; set; }
        public decimal? ValorSemFaleMais { get; set; }
    }
}