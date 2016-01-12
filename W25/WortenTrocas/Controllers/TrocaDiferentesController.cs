using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WortenTrocas.Models;

namespace WortenTrocas.Controllers
{
    public class TrocaDiferentesController : ApplicationBaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TrocaDiferentes
        public ActionResult Index()
        {
            var trocaDiferentes = db.TrocaDiferentes.Include(t => t.ProdutoATrocar).Include(t => t.ResumoTrocaDiferente);
            return View(trocaDiferentes.ToList());
        }

        // GET: TrocaDiferentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrocaDiferente trocaDiferente = db.TrocaDiferentes.Find(id);
            if (trocaDiferente == null)
            {
                return HttpNotFound();
            }
            return View(trocaDiferente);
        }

        // GET: TrocaDiferentes/Create
        public ActionResult Create()
        {
            ViewBag.TrocaDiferenteID = new SelectList(db.ProdutoUtilizadors, "puID", "UserID");
            ViewBag.TrocaDiferenteID = new SelectList(db.ResumoTrocaDiferentes, "TrocaDiferenteID", "TrocaDiferenteID");
            return View();
        }

        // POST: TrocaDiferentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrocaDiferenteID,ResumoTrocaDiferenteID,DataDaTrocaLojaDiferente,HoraDeEntregaDiferente,LojaWortenDiferente,TipoTrocaDiferente")] TrocaDiferente trocaDiferente)
        {
            if (ModelState.IsValid)
            {
                var CUID = Url.RequestContext.RouteData.Values["puID"];
                var currentPU = db.ProdutoUtilizadors.Find(Convert.ToInt32(CUID));

                trocaDiferente.ProdutoATrocar = currentPU;

                trocaDiferente.ProdutoATrocar.EstadoDaTroca = "Troca em processamento";

                trocaDiferente.TipoTrocaDiferente = "Troca por Produto Diferente";

                db.TrocaDiferentes.Add(trocaDiferente);
                currentPU.TrocaDiferenteID = trocaDiferente.TrocaDiferenteID;
                db.SaveChanges();
                return RedirectToAction("ResumoTrocaDiferentes/ResumoDiferente", new { id = trocaDiferente.TrocaDiferenteID });
            }

            ViewBag.TrocaDiferenteID = new SelectList(db.ProdutoUtilizadors, "puID", "UserID", trocaDiferente.TrocaDiferenteID);
            ViewBag.TrocaDiferenteID = new SelectList(db.ResumoTrocaDiferentes, "TrocaDiferenteID", "TrocaDiferenteID", trocaDiferente.TrocaDiferenteID);
            return View(trocaDiferente);
        }

        // GET: TrocaDiferentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrocaDiferente trocaDiferente = db.TrocaDiferentes.Find(id);
            if (trocaDiferente == null)
            {
                return HttpNotFound();
            }
            ViewBag.TrocaDiferenteID = new SelectList(db.ProdutoUtilizadors, "puID", "UserID", trocaDiferente.TrocaDiferenteID);
            ViewBag.TrocaDiferenteID = new SelectList(db.ResumoTrocaDiferentes, "TrocaDiferenteID", "TrocaDiferenteID", trocaDiferente.TrocaDiferenteID);
            return View(trocaDiferente);
        }

        // POST: TrocaDiferentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrocaDiferenteID,ResumoTrocaDiferenteID,DataDaTrocaLojaDiferente,HoraDeEntregaDiferente,LojaWortenDiferente,TipoTrocaDiferente")] TrocaDiferente trocaDiferente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trocaDiferente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TrocaDiferenteID = new SelectList(db.ProdutoUtilizadors, "puID", "UserID", trocaDiferente.TrocaDiferenteID);
            ViewBag.TrocaDiferenteID = new SelectList(db.ResumoTrocaDiferentes, "TrocaDiferenteID", "TrocaDiferenteID", trocaDiferente.TrocaDiferenteID);
            return View(trocaDiferente);
        }

        // GET: TrocaDiferentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrocaDiferente trocaDiferente = db.TrocaDiferentes.Find(id);
            if (trocaDiferente == null)
            {
                return HttpNotFound();
            }
            return View(trocaDiferente);
        }

        // POST: TrocaDiferentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrocaDiferente trocaDiferente = db.TrocaDiferentes.Find(id);
            db.TrocaDiferentes.Remove(trocaDiferente);
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
