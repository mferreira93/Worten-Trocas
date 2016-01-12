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
    public class ResumoTrocaSemelhantesController : ApplicationBaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ResumoTrocaSemelhantes
        public ActionResult Index()
        {
            var resumoTrocaSemelhantes = db.ResumoTrocaSemelhantes.Include(r => r.TrocaSemelhante);
            return View(resumoTrocaSemelhantes.ToList());
        }

        // GET: ResumoTrocaSemelhantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResumoTrocaSemelhante resumoTrocaSemelhante = db.ResumoTrocaSemelhantes.Find(id);
            if (resumoTrocaSemelhante == null)
            {
                return HttpNotFound();
            }
            return View(resumoTrocaSemelhante);
        }

        // GET: ResumoTrocaSemelhantes/Create
        public ActionResult Create()
        {
            ViewBag.ResumoTrocaSemelhanteID = new SelectList(db.TrocaSemelhantes, "TrocaSemelhanteID", "HoraDeEntregaSemelhante");
            return View();
        }

        // POST: ResumoTrocaSemelhantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResumoTrocaSemelhanteID")] ResumoTrocaSemelhante resumoTrocaSemelhante)
        {
            if (ModelState.IsValid)
            {
                db.ResumoTrocaSemelhantes.Add(resumoTrocaSemelhante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ResumoTrocaSemelhanteID = new SelectList(db.TrocaSemelhantes, "TrocaSemelhanteID", "HoraDeEntregaSemelhante", resumoTrocaSemelhante.ResumoTrocaSemelhanteID);
            return View(resumoTrocaSemelhante);
        }

        // GET: ResumoTrocaSemelhantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResumoTrocaSemelhante resumoTrocaSemelhante = db.ResumoTrocaSemelhantes.Find(id);
            if (resumoTrocaSemelhante == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResumoTrocaSemelhanteID = new SelectList(db.TrocaSemelhantes, "TrocaSemelhanteID", "HoraDeEntregaSemelhante", resumoTrocaSemelhante.ResumoTrocaSemelhanteID);
            return View(resumoTrocaSemelhante);
        }

        // POST: ResumoTrocaSemelhantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResumoTrocaSemelhanteID")] ResumoTrocaSemelhante resumoTrocaSemelhante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resumoTrocaSemelhante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResumoTrocaSemelhanteID = new SelectList(db.TrocaSemelhantes, "TrocaSemelhanteID", "HoraDeEntregaSemelhante", resumoTrocaSemelhante.ResumoTrocaSemelhanteID);
            return View(resumoTrocaSemelhante);
        }

        // GET: ResumoTrocaSemelhantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResumoTrocaSemelhante resumoTrocaSemelhante = db.ResumoTrocaSemelhantes.Find(id);
            if (resumoTrocaSemelhante == null)
            {
                return HttpNotFound();
            }
            return View(resumoTrocaSemelhante);
        }

        // POST: ResumoTrocaSemelhantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResumoTrocaSemelhante resumoTrocaSemelhante = db.ResumoTrocaSemelhantes.Find(id);
            db.ResumoTrocaSemelhantes.Remove(resumoTrocaSemelhante);
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

        public ActionResult ResumoSemelhante()
        {
            var TSID = Url.RequestContext.RouteData.Values["TrocaSemelhanteID"];
            var currentTS = db.TrocaSemelhantes.Find(Convert.ToInt32(TSID));

            var currentUserID = db.Users.Find(User.Identity.GetUserId()).Id;
            var produtoUtilizadors = db.ProdutoUtilizadors.Include(p => p.TrocaSemelhante).Include(p => p.User).Where(p => p.UserID == currentUserID);
            var pAvariado = produtoUtilizadors.Where(p => p.puID == currentTS.TrocaSemelhanteID);

            var data = db.TrocaSemelhantes.Where(p => p.TrocaSemelhanteID == currentTS.TrocaSemelhanteID);


            var viewModel = new ViewModelResumoTrocaSemelhante()
            {
                ProdutoUtilizador = new List<ProdutoUtilizador>(pAvariado.ToList()) { },
                TrocaSemelhante = new List<TrocaSemelhante>(data.ToList()) { }
            };
            return View(viewModel);
        }
    }
}
