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
    public class TrocaSemelhantesController : ApplicationBaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TrocaSemelhantes
        public ActionResult Index()
        {
            var trocaSemelhantes = db.TrocaSemelhantes.Include(t => t.ProdutoATrocar).Include(t => t.ResumoTrocaSemelhante);
            return View(trocaSemelhantes.ToList());
        }

        // GET: TrocaSemelhantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrocaSemelhante trocaSemelhante = db.TrocaSemelhantes.Find(id);
            if (trocaSemelhante == null)
            {
                return HttpNotFound();
            }
            return View(trocaSemelhante);
        }

        // GET: TrocaSemelhantes/Create
        public ActionResult Create()
        {
            ViewBag.TrocaSemelhanteID = new SelectList(db.ProdutoUtilizadors, "puID", "UserID");
            ViewBag.TrocaSemelhanteID = new SelectList(db.ResumoTrocaSemelhantes, "ResumoTrocaSemelhanteID", "ResumoTrocaSemelhanteID");
            return View();
        }

        // POST: TrocaSemelhantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrocaSemelhanteID,ResumoTrocaSemelhanteID,DataDaTrocaLojaSemelhante,HoraDeEntregaSemelhante,LojaWortenSemelhante,TipoTrocaSemelhante")] TrocaSemelhante trocaSemelhante)
        {
            if (ModelState.IsValid)
            {
                var CUID = Url.RequestContext.RouteData.Values["puID"];
                var currentPU = db.ProdutoUtilizadors.Find(Convert.ToInt32(CUID));

                trocaSemelhante.ProdutoATrocar = currentPU;

                trocaSemelhante.ProdutoATrocar.EstadoDaTroca = "Troca em processamento";

                trocaSemelhante.TipoTrocaSemelhante = "Troca por Produto Semelhante";

                db.TrocaSemelhantes.Add(trocaSemelhante);
                currentPU.TrocaSemelhanteID = trocaSemelhante.TrocaSemelhanteID;
                db.SaveChanges();
                return RedirectToAction("ResumoTrocaSemelhantes/ResumoSemelhante", new { id = trocaSemelhante.TrocaSemelhanteID });
            }

            ViewBag.TrocaSemelhanteID = new SelectList(db.ProdutoUtilizadors, "puID", "UserID", trocaSemelhante.TrocaSemelhanteID);
            ViewBag.TrocaSemelhanteID = new SelectList(db.ResumoTrocaSemelhantes, "ResumoTrocaSemelhanteID", "ResumoTrocaSemelhanteID", trocaSemelhante.TrocaSemelhanteID);
            return View(trocaSemelhante);
        }

        // GET: TrocaSemelhantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrocaSemelhante trocaSemelhante = db.TrocaSemelhantes.Find(id);
            if (trocaSemelhante == null)
            {
                return HttpNotFound();
            }
            ViewBag.TrocaSemelhanteID = new SelectList(db.ProdutoUtilizadors, "puID", "UserID", trocaSemelhante.TrocaSemelhanteID);
            ViewBag.TrocaSemelhanteID = new SelectList(db.ResumoTrocaSemelhantes, "ResumoTrocaSemelhanteID", "ResumoTrocaSemelhanteID", trocaSemelhante.TrocaSemelhanteID);
            return View(trocaSemelhante);
        }

        // POST: TrocaSemelhantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrocaSemelhanteID,ResumoTrocaSemelhanteID,DataDaTrocaLojaSemelhante,HoraDeEntregaSemelhante,LojaWortenSemelhante,TipoTrocaSemelhante")] TrocaSemelhante trocaSemelhante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trocaSemelhante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TrocaSemelhanteID = new SelectList(db.ProdutoUtilizadors, "puID", "UserID", trocaSemelhante.TrocaSemelhanteID);
            ViewBag.TrocaSemelhanteID = new SelectList(db.ResumoTrocaSemelhantes, "ResumoTrocaSemelhanteID", "ResumoTrocaSemelhanteID", trocaSemelhante.TrocaSemelhanteID);
            return View(trocaSemelhante);
        }

        // GET: TrocaSemelhantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrocaSemelhante trocaSemelhante = db.TrocaSemelhantes.Find(id);
            if (trocaSemelhante == null)
            {
                return HttpNotFound();
            }
            return View(trocaSemelhante);
        }

        // POST: TrocaSemelhantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrocaSemelhante trocaSemelhante = db.TrocaSemelhantes.Find(id);
            db.TrocaSemelhantes.Remove(trocaSemelhante);
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
