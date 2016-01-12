using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WortenTrocas.Models;
using Microsoft.AspNet.Identity;

namespace WortenTrocas.Controllers
{
    public class ResumoTrocaReembolsosController : ApplicationBaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ResumoTrocaReembolsos
        public ActionResult Index()
        {
            var resumoTrocaReembolsoes = db.ResumoTrocaReembolsoes.Include(r => r.EntregaReembolso);
            return View(resumoTrocaReembolsoes.ToList());
        }

        // GET: ResumoTrocaReembolsos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResumoTrocaReembolso resumoTrocaReembolso = db.ResumoTrocaReembolsoes.Find(id);
            if (resumoTrocaReembolso == null)
            {
                return HttpNotFound();
            }
            return View(resumoTrocaReembolso);
        }

        // GET: ResumoTrocaReembolsos/Create
        public ActionResult Create()
        {
            ViewBag.EntregaReembolsoID = new SelectList(db.EntregaReembolsoes, "EntregaReembolsoID", "RandomGeneratedNumber");
            return View();
        }

        // POST: ResumoTrocaReembolsos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntregaReembolsoID")] ResumoTrocaReembolso resumoTrocaReembolso)
        {
            if (ModelState.IsValid)
            {
                db.ResumoTrocaReembolsoes.Add(resumoTrocaReembolso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EntregaReembolsoID = new SelectList(db.EntregaReembolsoes, "EntregaReembolsoID", "RandomGeneratedNumber", resumoTrocaReembolso.EntregaReembolsoID);
            return View(resumoTrocaReembolso);
        }

        // GET: ResumoTrocaReembolsos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResumoTrocaReembolso resumoTrocaReembolso = db.ResumoTrocaReembolsoes.Find(id);
            if (resumoTrocaReembolso == null)
            {
                return HttpNotFound();
            }
            ViewBag.EntregaReembolsoID = new SelectList(db.EntregaReembolsoes, "EntregaReembolsoID", "RandomGeneratedNumber", resumoTrocaReembolso.EntregaReembolsoID);
            return View(resumoTrocaReembolso);
        }

        // POST: ResumoTrocaReembolsos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntregaReembolsoID")] ResumoTrocaReembolso resumoTrocaReembolso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resumoTrocaReembolso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EntregaReembolsoID = new SelectList(db.EntregaReembolsoes, "EntregaReembolsoID", "RandomGeneratedNumber", resumoTrocaReembolso.EntregaReembolsoID);
            return View(resumoTrocaReembolso);
        }

        // GET: ResumoTrocaReembolsos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResumoTrocaReembolso resumoTrocaReembolso = db.ResumoTrocaReembolsoes.Find(id);
            if (resumoTrocaReembolso == null)
            {
                return HttpNotFound();
            }
            return View(resumoTrocaReembolso);
        }

        // POST: ResumoTrocaReembolsos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResumoTrocaReembolso resumoTrocaReembolso = db.ResumoTrocaReembolsoes.Find(id);
            db.ResumoTrocaReembolsoes.Remove(resumoTrocaReembolso);
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

        public ActionResult ResumoReembolso()
        {
            var ERID = Url.RequestContext.RouteData.Values["EntregaReembolsoID"];
            var currentER = db.EntregaReembolsoes.Find(Convert.ToInt32(ERID));

            var currentUserID = db.Users.Find(User.Identity.GetUserId()).Id;
            var produtoUtilizadors = db.ProdutoUtilizadors.Include(p => p.TrocaDiferente).Include(p => p.User).Where(p => p.UserID == currentUserID);
            var pAvariado = produtoUtilizadors.Where(p => p.puID == currentER.EntregaReembolsoID);

            var data = db.EntregaReembolsoes.Where(p => p.EntregaReembolsoID == currentER.EntregaReembolsoID);


            var viewModel = new ViewModelResumoTrocaReembolso()
            {
                ProdutoUtilizador = new List<ProdutoUtilizador>(pAvariado.ToList()) { },
                EntregaReembolso = new List<EntregaReembolso>(data.ToList()) { }
            };
            return View(viewModel);
        }
    }
}
