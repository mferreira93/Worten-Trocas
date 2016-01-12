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
    public class ResumoTrocaDiferentesController : ApplicationBaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ResumoTrocaDiferentes
        public ActionResult Index()
        {
            var resumoTrocaDiferentes = db.ResumoTrocaDiferentes.Include(r => r.TrocaDiferente);
            return View(resumoTrocaDiferentes.ToList());
        }

        // GET: ResumoTrocaDiferentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResumoTrocaDiferente resumoTrocaDiferente = db.ResumoTrocaDiferentes.Find(id);
            if (resumoTrocaDiferente == null)
            {
                return HttpNotFound();
            }
            return View(resumoTrocaDiferente);
        }

        // GET: ResumoTrocaDiferentes/Create
        public ActionResult Create()
        {
            ViewBag.TrocaDiferenteID = new SelectList(db.TrocaDiferentes, "TrocaDiferenteID", "HoraDeEntregaDiferente");
            return View();
        }

        // POST: ResumoTrocaDiferentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrocaDiferenteID")] ResumoTrocaDiferente resumoTrocaDiferente)
        {
            if (ModelState.IsValid)
            {
                db.ResumoTrocaDiferentes.Add(resumoTrocaDiferente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TrocaDiferenteID = new SelectList(db.TrocaDiferentes, "TrocaDiferenteID", "HoraDeEntregaDiferente", resumoTrocaDiferente.TrocaDiferenteID);
            return View(resumoTrocaDiferente);
        }

        // GET: ResumoTrocaDiferentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResumoTrocaDiferente resumoTrocaDiferente = db.ResumoTrocaDiferentes.Find(id);
            if (resumoTrocaDiferente == null)
            {
                return HttpNotFound();
            }
            ViewBag.TrocaDiferenteID = new SelectList(db.TrocaDiferentes, "TrocaDiferenteID", "HoraDeEntregaDiferente", resumoTrocaDiferente.TrocaDiferenteID);
            return View(resumoTrocaDiferente);
        }

        // POST: ResumoTrocaDiferentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrocaDiferenteID")] ResumoTrocaDiferente resumoTrocaDiferente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resumoTrocaDiferente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TrocaDiferenteID = new SelectList(db.TrocaDiferentes, "TrocaDiferenteID", "HoraDeEntregaDiferente", resumoTrocaDiferente.TrocaDiferenteID);
            return View(resumoTrocaDiferente);
        }

        // GET: ResumoTrocaDiferentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResumoTrocaDiferente resumoTrocaDiferente = db.ResumoTrocaDiferentes.Find(id);
            if (resumoTrocaDiferente == null)
            {
                return HttpNotFound();
            }
            return View(resumoTrocaDiferente);
        }

        // POST: ResumoTrocaDiferentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResumoTrocaDiferente resumoTrocaDiferente = db.ResumoTrocaDiferentes.Find(id);
            db.ResumoTrocaDiferentes.Remove(resumoTrocaDiferente);
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

        public ActionResult ResumoDiferente()
        {
            var TDID = Url.RequestContext.RouteData.Values["TrocaDiferenteID"];
            var currentTD = db.TrocaDiferentes.Find(Convert.ToInt32(TDID));

            var currentUserID = db.Users.Find(User.Identity.GetUserId()).Id;
            var produtoUtilizadors = db.ProdutoUtilizadors.Include(p => p.TrocaDiferente).Include(p => p.User).Where(p => p.UserID == currentUserID);
            var pAvariado = produtoUtilizadors.Where(p => p.puID == currentTD.TrocaDiferenteID);

            var data = db.TrocaDiferentes.Where(p => p.TrocaDiferenteID == currentTD.TrocaDiferenteID);


            var viewModel = new ViewModelResumoTrocaDiferente()
            {
                ProdutoUtilizador = new List<ProdutoUtilizador>(pAvariado.ToList()) { },
                TrocaDiferente = new List<TrocaDiferente>(data.ToList()) { }
            };
            return View(viewModel);
        }

    }
}
