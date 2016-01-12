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
    public class EntregasReembolsoController : ApplicationBaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EntregasReembolso
        public ActionResult Index()
        {
            var entregaReembolsoes = db.EntregaReembolsoes.Include(e => e.ProdutoATrocar).Include(e => e.ResumoTrocaReembolso);
            return View(entregaReembolsoes.ToList());
        }

        // GET: EntregasReembolso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntregaReembolso entregaReembolso = db.EntregaReembolsoes.Find(id);
            if (entregaReembolso == null)
            {
                return HttpNotFound();
            }
            return View(entregaReembolso);
        }

        // GET: EntregasReembolso/Create
        public ActionResult Create()
        {
            ViewBag.EntregaReembolsoID = new SelectList(db.ProdutoUtilizadors, "puID", "UserID");
            ViewBag.EntregaReembolsoID = new SelectList(db.ResumoTrocaReembolsoes, "EntregaReembolsoID", "EntregaReembolsoID");
            return View();
        }

        // POST: EntregasReembolso/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntregaReembolsoID,ResumoTrocaReembolsoID,DataDaTrocaLojaReembolso,MetodoPagamentoIBAN,MetodoPagamentoCR,HoraDeEntregaReembolso,LojaWortenReembolso,IBAN,Morada,CPostal")] EntregaReembolso entregaReembolso)
        {
            if (ModelState.IsValid)
            {
                var CUID = Url.RequestContext.RouteData.Values["puID"];
                var currentPU = db.ProdutoUtilizadors.Find(Convert.ToInt32(CUID));

                entregaReembolso.ProdutoATrocar = currentPU;

                entregaReembolso.ProdutoATrocar.EstadoDaTroca = "Troca em processamento";

                db.EntregaReembolsoes.Add(entregaReembolso);
                currentPU.EntregaReembolsoID = entregaReembolso.EntregaReembolsoID;
                db.SaveChanges();
                return RedirectToAction("ResumoTrocaReembolsos/ResumoReembolso", new { id = entregaReembolso.EntregaReembolsoID });
            }

            ViewBag.EntregaReembolsoID = new SelectList(db.ProdutoUtilizadors, "puID", "UserID", entregaReembolso.EntregaReembolsoID);
            ViewBag.EntregaReembolsoID = new SelectList(db.ResumoTrocaReembolsoes, "EntregaReembolsoID", "EntregaReembolsoID", entregaReembolso.EntregaReembolsoID);
            return View(entregaReembolso);
        }

        // GET: EntregasReembolso/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntregaReembolso entregaReembolso = db.EntregaReembolsoes.Find(id);
            if (entregaReembolso == null)
            {
                return HttpNotFound();
            }
            ViewBag.EntregaReembolsoID = new SelectList(db.ProdutoUtilizadors, "puID", "UserID", entregaReembolso.EntregaReembolsoID);
            ViewBag.EntregaReembolsoID = new SelectList(db.ResumoTrocaReembolsoes, "EntregaReembolsoID", "EntregaReembolsoID", entregaReembolso.EntregaReembolsoID);
            return View(entregaReembolso);
        }

        // POST: EntregasReembolso/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntregaReembolsoID,ResumoTrocaReembolsoID,DataDaTrocaLojaReembolso,MetodoPagamentoIBAN,MetodoPagamentoCR,HoraDeEntregaReembolso,LojaWortenReembolso,IBAN,Morada,CPostal")] EntregaReembolso entregaReembolso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entregaReembolso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EntregaReembolsoID = new SelectList(db.ProdutoUtilizadors, "puID", "UserID", entregaReembolso.EntregaReembolsoID);
            ViewBag.EntregaReembolsoID = new SelectList(db.ResumoTrocaReembolsoes, "EntregaReembolsoID", "EntregaReembolsoID", entregaReembolso.EntregaReembolsoID);
            return View(entregaReembolso);
        }

        // GET: EntregasReembolso/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntregaReembolso entregaReembolso = db.EntregaReembolsoes.Find(id);
            if (entregaReembolso == null)
            {
                return HttpNotFound();
            }
            return View(entregaReembolso);
        }

        // POST: EntregasReembolso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EntregaReembolso entregaReembolso = db.EntregaReembolsoes.Find(id);
            db.EntregaReembolsoes.Remove(entregaReembolso);
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
