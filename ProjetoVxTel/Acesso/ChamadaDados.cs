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

            try
            {
                if (CodigoDDDOrigem != null && CodigoDDDDestino != null)
                {
                    chamada = db.Chamadas.Where(x => x.CodigoDDDOrigem == CodigoDDDOrigem && x.CodigoDDDDestino == CodigoDDDDestino).FirstOrDefault();
                }

                return chamada;

            }
            catch (Exception ex)
            {

                throw ex;
            }           
        }

        public List<DDD> ListarDDDs()
        {
            var listaddds = new List<DDD>();
            listaddds = db.DDDs.ToList();

            return listaddds;
        }        
    }
}