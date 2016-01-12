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
    public class EntregasController : ApplicationBaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Entregas
        public ActionResult Index()
        {
            var entregas = db.Entregas.Include(e => e.RazaoTroca).Include(e => e.ResumoTroca);
            return View(entregas.ToList());
        }

        // GET: Entregas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrega entrega = db.Entregas.Find(id);
            if (entrega == null)
            {
                return HttpNotFound();
            }
            return View(entrega);
        }

        // GET: Entregas/Create
        public ActionResult Create()
        {
            ViewBag.EntregaID = new SelectList(db.RazaoTrocas, "RazaoTrocaID", "MotivoAvaria");
            ViewBag.EntregaID = new SelectList(db.ResumoTrocas, "ResumoTrocaID", "ResumoTrocaID");
            return View();
        }

        // POST: Entregas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntregaID,Morada,CPostal,Cidade,Pais,NTelemovel,ResumoTrocaID,DataDoPedido,DataDaTrocaCasa,DataDaTrocaLoja,HoraDeEntrega,LojaWorten")] Entrega entrega)
        {
            if (ModelState.IsValid)
            {
                var RTID = Url.RequestContext.RouteData.Values["RazaoTrocaID"];
                var currentTT = db.RazaoTrocas.Find(Convert.ToInt32(RTID));

                entrega.RazaoTroca = currentTT;

                entrega.RazaoTroca.ProdutoATrocar.EstadoDaTroca = "Troca em processamento";

                entrega.DataDoPedido = DateTime.Now;
                db.Entregas.Add(entrega);
                currentTT.EntregaID = entrega.EntregaID;
                db.SaveChanges();
                return RedirectToAction("ResumoTroca/Resumo", new { id = entrega.EntregaID });
            }

            ViewBag.EntregaID = new SelectList(db.RazaoTrocas, "RazaoTrocaID", "MotivoAvaria", entrega.EntregaID);
            ViewBag.EntregaID = new SelectList(db.ResumoTrocas, "ResumoTrocaID", "ResumoTrocaID", entrega.EntregaID);
            return View(entrega);
        }

        // GET: Entregas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrega entrega = db.Entregas.Find(id);
            if (entrega == null)
            {
                return HttpNotFound();
            }
            ViewBag.EntregaID = new SelectList(db.RazaoTrocas, "RazaoTrocaID", "MotivoAvaria", entrega.EntregaID);
            ViewBag.EntregaID = new SelectList(db.ResumoTrocas, "ResumoTrocaID", "ResumoTrocaID", entrega.EntregaID);
            return View(entrega);
        }

        // POST: Entregas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntregaID,Morada,CPostal,Cidade,Pais,NTelemovel,ResumoTrocaID,DataDoPedido,DataDaTrocaCasa,DataDaTrocaLoja,HoraDeEntrega,LojaWorten")] Entrega entrega)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entrega).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EntregaID = new SelectList(db.RazaoTrocas, "RazaoTrocaID", "MotivoAvaria", entrega.EntregaID);
            ViewBag.EntregaID = new SelectList(db.ResumoTrocas, "ResumoTrocaID", "ResumoTrocaID", entrega.EntregaID);
            return View(entrega);
        }

        // GET: Entregas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrega entrega = db.Entregas.Find(id);
            if (entrega == null)
            {
                return HttpNotFound();
            }
            return View(entrega);
        }

        // POST: Entregas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entrega entrega = db.Entregas.Find(id);
            db.Entregas.Remove(entrega);
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
