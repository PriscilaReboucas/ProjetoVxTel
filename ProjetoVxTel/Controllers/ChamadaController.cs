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
    public class ChamadaController : Controller
    {
        private FaleMaisContexto db = new FaleMaisContexto();

        // GET: Chamada
        public ActionResult Index()
        {
            return View(db.Chamadas.ToList());
        }

        // GET: Chamada/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chamada chamada = db.Chamadas.Find(id);
            if (chamada == null)
            {
                return HttpNotFound();
            }
            return View(chamada);
        }

    }
}
