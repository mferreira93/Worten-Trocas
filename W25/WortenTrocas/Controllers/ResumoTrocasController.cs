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
    public class ResumoTrocasController : ApplicationBaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ResumoTrocas
        public ActionResult Index()
        {
            var resumoTrocas = db.ResumoTrocas.Include(r => r.Entrega);
            return View(resumoTrocas.ToList());
        }

        // GET: ResumoTrocas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResumoTroca resumoTroca = db.ResumoTrocas.Find(id);
            if (resumoTroca == null)
            {
                return HttpNotFound();
            }
            return View(resumoTroca);
        }

        // GET: ResumoTrocas/Create
        public ActionResult Create()
        {
            ViewBag.ResumoTrocaID = new SelectList(db.Entregas, "EntregaID", "LocalEntrega");
            return View();
        }

        // POST: ResumoTrocas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResumoTrocaID")] ResumoTroca resumoTroca)
        {
            if (ModelState.IsValid)
            {
                db.ResumoTrocas.Add(resumoTroca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ResumoTrocaID = new SelectList(db.Entregas, "EntregaID", "LocalEntrega", resumoTroca.ResumoTrocaID);
            return View(resumoTroca);
        }

        // GET: ResumoTrocas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResumoTroca resumoTroca = db.ResumoTrocas.Find(id);
            if (resumoTroca == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResumoTrocaID = new SelectList(db.Entregas, "EntregaID", "LocalEntrega", resumoTroca.ResumoTrocaID);
            return View(resumoTroca);
        }

        // POST: ResumoTrocas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResumoTrocaID")] ResumoTroca resumoTroca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resumoTroca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResumoTrocaID = new SelectList(db.Entregas, "EntregaID", "LocalEntrega", resumoTroca.ResumoTrocaID);
            return View(resumoTroca);
        }

        // GET: ResumoTrocas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResumoTroca resumoTroca = db.ResumoTrocas.Find(id);
            if (resumoTroca == null)
            {
                return HttpNotFound();
            }
            return View(resumoTroca);
        }

        // POST: ResumoTrocas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResumoTroca resumoTroca = db.ResumoTrocas.Find(id);
            db.ResumoTrocas.Remove(resumoTroca);
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

        public ActionResult Resumo()
        {
            var EID = Url.RequestContext.RouteData.Values["EntregaID"];
            var currentE = db.Entregas.Find(Convert.ToInt32(EID));

            var currentUserID = db.Users.Find(User.Identity.GetUserId()).Id;
            var produtoUtilizadors = db.ProdutoUtilizadors.Include(p => p.RazaoTroca).Include(p => p.User).Where(p => p.UserID == currentUserID);
            var pAvariado = produtoUtilizadors.Where(p => p.puID == currentE.EntregaID);

            var pA = pAvariado.SingleOrDefault();
            var produto = db.Produtoes.Where(p => p.Referencia == pA.Referência);

            var data = db.Entregas.Where(p => p.EntregaID == currentE.EntregaID);

            var viewModel = new ViewModelResumoTroca()
            {
                Produto = new List<Produto>(produto.ToList()) { },
                ProdutoUtilizador = new List<ProdutoUtilizador>(pAvariado.ToList()) { },
                Entrega = new List<Entrega>(data.ToList()) { }
            };
            return View(viewModel);
        }

        public ActionResult EstadoTroca()
        {
            var currentUserID = db.Users.Find(User.Identity.GetUserId()).Id;
            var produtoUtilizadors = db.ProdutoUtilizadors.Where(p => p.UserID == currentUserID);
            var viewModel = new ViewModelResumoTroca()
            {

                ProdutoUtilizador = new List<ProdutoUtilizador>(produtoUtilizadors.ToList()) { }
            };
            return View(viewModel);
        }
    }
}
