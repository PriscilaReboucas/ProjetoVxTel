﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoVxTel.Acesso;
using ProjetoVxTel.Models;

namespace UnitTestProjetoVxTel
{
    [TestClass]
    public class SimulacaoTest
    {
        [TestMethod]
        public void CalcularValorMinutoTotal()
        {
            var percentualExcedente = 10.0 / 100.0;
            var valorMinutoChamada = 1.90;

            var valorminutototal = valorMinutoChamada + (valorMinutoChamada * percentualExcedente);

            Assert.AreEqual(2.09, valorminutototal);
        }

        [TestMethod]
        public void CalcularPlanoComFaleMais()
        {
            var chamada = ConsultarChamada(11, 16);
            var planoQuantidadeMinuto = 30;
            var tempoMinuto = 40;
            var minutosExcedente = tempoMinuto - planoQuantidadeMinuto;
            var percentualExcedente = 10.0 / 100.0;
            var valorminutototal = chamada.ValorMinuto + (chamada.ValorMinuto * decimal.Parse(percentualExcedente.ToString()));

            var valorComFaleMais = valorminutototal * minutosExcedente;

            Assert.AreEqual(20.90, double.Parse(valorComFaleMais.ToString()));
        }

        [TestMethod]
        public void CalcularPlanoSemFaleMais()
        {
            var chamada = ConsultarChamada(11, 16);

            var tempoMinuto = 20;

            var valorSemFaleMais = chamada.ValorMinuto * tempoMinuto;
            Assert.AreEqual(38.00, double.Parse(valorSemFaleMais.ToString()));
            Assert.AreNotEqual(38.10, double.Parse(valorSemFaleMais.ToString()));
        }


        [TestMethod]
        public void  ListarPlano()
        {
            var listaplano = new PlanoDados().ListarPlano();
            Assert.IsNotNull(listaplano);
        }

        [TestMethod]
        public void ListarDDD()
        {
            var listaddd = new ChamadaDados().ListarDDDs();
            Assert.IsNotNull(listaddd);
        }

       
        public Chamada ConsultarChamada(int codigoOrigem, int codigoDestino)
        {
            return new ChamadaDados().ConsultarChamada(codigoOrigem, codigoDestino);

        }
    }
}
