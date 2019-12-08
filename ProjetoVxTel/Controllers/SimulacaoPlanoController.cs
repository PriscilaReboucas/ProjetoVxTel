using ProjetoVxTel.Acesso;
using ProjetoVxTel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoVxTel.Controllers
{
    public class SimulacaoPlanoController : Controller
    {
        private FaleMaisContexto db = new FaleMaisContexto();
        // GET: SimulacaoChamada
        [HttpGet]
        public ActionResult Index()
        {
            DropDownListPlanos();
            DropDownListDDDs();

            return View();
        }
       

        private void DropDownListPlanos()

        {
            var planos =
                (from item in
                     new PlanoDados().ListarPlano()
                 select new SelectListItem
                 {
                     Value = item.Id.ToString(),
                     Text = item.Descricao
                 }).ToList();

            planos.Insert(0, new SelectListItem { Value = "", Text = "Selecione" });

            ViewBag.Planos = planos;
        }

        private void DropDownListDDDs()
        {
            var dddsOrigem =
                (from item in
                     new ChamadaDados().ListarDDDs()
                 select new SelectListItem
                 {
                     Value = item.Codigo.ToString(),
                     Text = $"0{item.Codigo.ToString()}"
                 }).ToList();

            dddsOrigem.Insert(0, new SelectListItem { Value = "", Text = "Selecione" });

            ViewBag.DDsOrigem = dddsOrigem;


            var dddsDestino =
               (from item in
                      new ChamadaDados().ListarDDDs()
                select new SelectListItem
                {
                    Value = item.Codigo.ToString(),
                    Text = $"0{item.Codigo.ToString()}"
                }).ToList();

            dddsDestino.Insert(0, new SelectListItem { Value = "", Text = "Selecione" });

            ViewBag.DDsDestino = dddsDestino;
        }


        public JsonResult ObterSimulacaoPlano(int codigo_origem, int codigo_destino, int id_plano, int tempo)
        {
            var simulacaoPlano = new SimulacaoPlano();
            simulacaoPlano.Tempo = tempo;
            simulacaoPlano.Chamada = new Chamada() { DDDOrigem = new DDD() { Codigo = codigo_origem }, DDDDestino = new DDD() { Codigo = codigo_destino } };

            try
            {
                var chamada = new ChamadaDados().ConsultarChamada(codigo_origem, codigo_destino);
                var plano = new PlanoDados().ConsultarPlano(id_plano);
                if (plano!= null)
                {
                    simulacaoPlano.Plano = new Plano() { Descricao = plano.Descricao };
                }

                if (chamada != null && plano != null)
                {  
                    if (tempo > plano.QuantidadeMinuto)
                    {
                        var minutosExcedente = tempo - plano.QuantidadeMinuto;
                        decimal valorminutototal = CalculoValorMinutoTotal(chamada);

                        simulacaoPlano.ValorComFaleMais = valorminutototal * minutosExcedente;
                        simulacaoPlano.ValorSemFaleMais = chamada.ValorMinuto * simulacaoPlano.Tempo;
                    }
                    else
                    {
                        simulacaoPlano.ValorComFaleMais = 0;
                        simulacaoPlano.ValorSemFaleMais = chamada.ValorMinuto * simulacaoPlano.Tempo;
                    }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return Json(simulacaoPlano, JsonRequestBehavior.AllowGet); ;
        }

        private decimal CalculoValorMinutoTotal(Chamada chamada)
        {
            var percentualExcedente = 10.0 / 100.0;
            var valorminutototal = chamada.ValorMinuto + (chamada.ValorMinuto * decimal.Parse(percentualExcedente.ToString()));
            return valorminutototal;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
