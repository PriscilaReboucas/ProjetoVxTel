using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoVxTel.Acesso;
using ProjetoVxTel.Models;

namespace ProjetoVxTel.Controllers
{
    public class PlanoController : Controller
    {
        private FaleMaisContexto db = new FaleMaisContexto();


        private Plano ConsultarPlano (int? id)
        {
            var plano = new Plano();

            if (id!= null)
            {
               plano = db.Planos.Find(id);
            }

            return plano;
        }




        // GET: Plano
        public ActionResult Index()
        {
            return View(db.Planos.ToList());
        }

        // GET: Plano/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plano plano = db.Planos.Find(id);
            if (plano == null)
            {
                return HttpNotFound();
            }
            return View(plano);
        }

        // GET: Plano/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plano/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao,QuantidadeMinuto")] Plano plano)
        {
            if (ModelState.IsValid)
            {
                db.Planos.Add(plano);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plano);
        }

        // GET: Plano/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plano plano = db.Planos.Find(id);
            if (plano == null)
            {
                return HttpNotFound();
            }
            return View(plano);
        }

        // POST: Plano/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao,QuantidadeMinuto")] Plano plano)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plano).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plano);
        }

        // GET: Plano/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plano plano = db.Planos.Find(id);
            if (plano == null)
            {
                return HttpNotFound();
            }
            return View(plano);
        }

        // POST: Plano/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plano plano = db.Planos.Find(id);
            db.Planos.Remove(plano);
            db.SaveChanges();
            return RedirectToAction("Index");
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
