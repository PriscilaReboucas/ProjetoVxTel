using ProjetoVxTel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoVxTel.Acesso
{
    public class ChamadaDados
    {
        private FaleMaisContexto db = new FaleMaisContexto();

        public Chamada ConsultarChamada(int? CodigoDDDOrigem, int? CodigoDDDDestino)
        {
            var chamada = new Chamada();

            if (CodigoDDDOrigem != null && CodigoDDDDestino != null)
            {
                chamada = db.Chamadas.Where(x => x.DDDOrigem.Codigo == CodigoDDDOrigem && x.DDDDestino.Codigo == CodigoDDDDestino).FirstOrDefault();
            }

            return chamada;
        }

        public List<DDD> ListarDDDs()
        {
            var listaddds = new List<DDD>();
            listaddds = db.DDDs.ToList();

            return listaddds;
        }


    }
}