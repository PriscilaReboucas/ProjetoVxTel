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

        // GET: SimulacaoChamada
        [HttpGet]
        public ActionResult Index()
        {
            DropDownListPlanos();
            DropDownListDDDs();

            return View();
        }

        [HttpPost]
        public ActionResult Index(int? codigoPlano, int? codigoOrigem, int? codigoDestino, int? tempo, SimulacaoPlano simulacaoPlano)
        {
            DropDownListPlanos();
            DropDownListDDDs();

            if (simulacaoPlano != null)
            {
                var plano = new Plano() { Id = codigoPlano };
                var chamada = new Chamada() { DDDOrigem = new DDD() { Codigo = codigoOrigem }, DDDDestino = new DDD() { Codigo = codigoDestino } };
                plano = new PlanoDados().ConsultarPlano(plano.Id);

                chamada = new ChamadaDados().ConsultarChamada(chamada.DDDOrigem.Codigo, chamada.DDDDestino.Codigo);

                if (plano != null && chamada != null)
                {
                    if (simulacaoPlano.Tempo > plano.QuantidadeMinuto)
                    {
                        var minutosExcedente = simulacaoPlano.Tempo - plano.QuantidadeMinuto;
                        var percentualExcedente = 0.10;

                        simulacaoPlano.ValorComFaleMais = (chamada.ValorMinuto * decimal.Parse(percentualExcedente.ToString())) * minutosExcedente;
                        simulacaoPlano.ValorSemFaleMais = chamada.ValorMinuto * simulacaoPlano.Tempo;
                    }
                    else
                        simulacaoPlano.ValorComFaleMais = 0;
                }
            }

            return View(simulacaoPlano);
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

            try
            {
                //var chamada = new ChamadaDados().ConsultarChamada(codigo_origem, codigo_destino);
                var chamada = new Chamada() { ValorMinuto = 1 };
                var plano = new PlanoDados().ConsultarPlano(id_plano);

                if (chamada != null && plano != null)
                {
                    simulacaoPlano.Plano = new Plano() { Descricao = plano.Descricao };
                    simulacaoPlano.Tempo = tempo;
                    simulacaoPlano.Chamada = new Chamada() { DDDOrigem = new DDD() { Codigo = codigo_origem }, DDDDestino = new DDD() { Codigo = codigo_destino } };

                    if (tempo > plano.QuantidadeMinuto)
                    {
                        var minutosExcedente = tempo - plano.QuantidadeMinuto;
                        var percentualExcedente = 0.10;

                        simulacaoPlano.ValorComFaleMais = (chamada.ValorMinuto * decimal.Parse(percentualExcedente.ToString())) * minutosExcedente;
                        simulacaoPlano.ValorSemFaleMais = chamada.ValorMinuto * simulacaoPlano.Tempo;
                    }
                    else
                    {
                        simulacaoPlano.ValorComFaleMais = 0;
                        simulacaoPlano.ValorSemFaleMais = chamada.ValorMinuto * simulacaoPlano.Tempo;
                    }
                }
            }
            catch(Exception ex)
            {
                throw (ex);
            }

            return Json(simulacaoPlano, JsonRequestBehavior.AllowGet); ;
        }

    }
}
