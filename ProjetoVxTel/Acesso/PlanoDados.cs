using ProjetoVxTel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoVxTel.Acesso
{
    public class PlanoDados
    {
        private FaleMaisContexto db = new FaleMaisContexto();

        public Plano ConsultarPlano(int? id)
        {
            var plano = new Plano();

            if (id != null)
            {
                plano = db.Planos.Find(id);
            }

            return plano;
        }


        public List<Plano> ListarPlano()
        {       
            return           
            db.Planos.ToList();           
           
        }      

    }
}