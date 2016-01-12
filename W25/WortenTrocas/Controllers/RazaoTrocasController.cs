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
    public class RazaoTrocasController : ApplicationBaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RazaoTrocas
        public ActionResult Index()
        {
            var razaoTrocas = db.RazaoTrocas.Include(r => r.Entrega).Include(r => r.ProdutoATrocar);
            return View(razaoTrocas.ToList());
        }

        // GET: RazaoTrocas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RazaoTroca razaoTroca = db.RazaoTrocas.Find(id);
            if (razaoTroca == null)
            {
                return HttpNotFound();
            }
            return View(razaoTroca);
        }

        // GET: RazaoTrocas/Create
        public ActionResult Create()
        {
            ViewBag.RazaoTrocaID = new SelectList(db.Entregas, "EntregaID", "LocalEntrega");
            ViewBag.RazaoTrocaID = new SelectList(db.ProdutoUtilizadors, "puID", "UserID");
            return View();
        }

        // POST: RazaoTrocas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RazaoTrocaID,EntregaID,MotivoAvaria,OutroMotivo")] RazaoTroca razaoTroca)
        {
            if (ModelState.IsValid)
            {
                var CUID = Url.RequestContext.RouteData.Values["puID"];
                var currentPU = db.ProdutoUtilizadors.Find(Convert.ToInt32(CUID));

                razaoTroca.ProdutoATrocar = currentPU;

                db.RazaoTrocas.Add(razaoTroca);
                currentPU.RazaoTrocaID = razaoTroca.RazaoTrocaID;
                db.SaveChanges();
                return RedirectToAction("Entregas/Create", new { id = razaoTroca.RazaoTrocaID });
            }

            ViewBag.RazaoTrocaID = new SelectList(db.Entregas, "EntregaID", "LocalEntrega", razaoTroca.RazaoTrocaID);
            ViewBag.RazaoTrocaID = new SelectList(db.ProdutoUtilizadors, "puID", "UserID", razaoTroca.RazaoTrocaID);
            return View(razaoTroca);
        }

        // GET: RazaoTrocas/TriagemAvariado
        public ActionResult TriagemAvariado()
        {
            ViewBag.RazaoTrocaID = new SelectList(db.Entregas, "EntregaID", "LocalEntrega");
            ViewBag.RazaoTrocaID = new SelectList(db.ProdutoUtilizadors, "puID", "UserID");
            return View();
        }

        // POST: RazaoTrocas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TriagemAvariado([Bind(Include = "RazaoTrocaID,EntregaID,MotivoAvaria,OutroMotivo")] RazaoTroca razaoTroca)
        {
            if (ModelState.IsValid)
            {
                var CUID = Url.RequestContext.RouteData.Values["puID"];
                var currentPU = db.ProdutoUtilizadors.Find(Convert.ToInt32(CUID));

                razaoTroca.ProdutoATrocar = currentPU;

                db.RazaoTrocas.Add(razaoTroca);
                currentPU.RazaoTrocaID = razaoTroca.RazaoTrocaID;
                db.SaveChanges();
                return RedirectToAction("Entregas/Create", new { id = razaoTroca.RazaoTrocaID });
            }

            ViewBag.RazaoTrocaID = new SelectList(db.Entregas, "EntregaID", "LocalEntrega", razaoTroca.RazaoTrocaID);
            ViewBag.RazaoTrocaID = new SelectList(db.ProdutoUtilizadors, "puID", "UserID", razaoTroca.RazaoTrocaID);
            return View(razaoTroca);
        }

        // GET: RazaoTrocas/Create
        public ActionResult TriagemProdutoSemelhante()
        {
            ViewBag.RazaoTrocaID = new SelectList(db.Entregas, "EntregaID", "LocalEntrega");
            ViewBag.RazaoTrocaID = new SelectList(db.ProdutoUtilizadors, "puID", "UserID");
            return View();
        }

        // POST: RazaoTrocas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TriagemProdutoSemelhante([Bind(Include = "RazaoTrocaID,EntregaID,MotivoAvaria,OutroMotivo")] RazaoTroca razaoTroca)
        {
            if (ModelState.IsValid)
            {
                var CUID = Url.RequestContext.RouteData.Values["puID"];
                var currentPU = db.ProdutoUtilizadors.Find(Convert.ToInt32(CUID));

                razaoTroca.ProdutoATrocar = currentPU;

                db.RazaoTrocas.Add(razaoTroca);
                currentPU.RazaoTrocaID = razaoTroca.RazaoTrocaID;
                db.SaveChanges();
                return RedirectToAction("Entregas/Create", new { id = razaoTroca.RazaoTrocaID });
            }

            ViewBag.RazaoTrocaID = new SelectList(db.Entregas, "EntregaID", "LocalEntrega", razaoTroca.RazaoTrocaID);
            ViewBag.RazaoTrocaID = new SelectList(db.ProdutoUtilizadors, "puID", "UserID", razaoTroca.RazaoTrocaID);
            return View(razaoTroca);
        }

        // GET: RazaoTrocas/Create
        public ActionResult OutroMotivo()
        {
            ViewBag.RazaoTrocaID = new SelectList(db.Entregas, "EntregaID", "LocalEntrega");
            ViewBag.RazaoTrocaID = new SelectList(db.ProdutoUtilizadors, "puID", "UserID");
            return View();
        }

        // POST: RazaoTrocas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OutroMotivo([Bind(Include = "RazaoTrocaID,EntregaID,MotivoAvaria,OutroMotivo")] RazaoTroca razaoTroca)
        {
            if (ModelState.IsValid)
            {
                var CUID = Url.RequestContext.RouteData.Values["puID"];
                var currentPU = db.ProdutoUtilizadors.Find(Convert.ToInt32(CUID));

                razaoTroca.ProdutoATrocar = currentPU;

                db.RazaoTrocas.Add(razaoTroca);
                currentPU.RazaoTrocaID = razaoTroca.RazaoTrocaID;
                db.SaveChanges();
                return RedirectToAction("Entregas/Create", new { id = razaoTroca.RazaoTrocaID });
            }

            ViewBag.RazaoTrocaID = new SelectList(db.Entregas, "EntregaID", "LocalEntrega", razaoTroca.RazaoTrocaID);
            ViewBag.RazaoTrocaID = new SelectList(db.ProdutoUtilizadors, "puID", "UserID", razaoTroca.RazaoTrocaID);
            return View(razaoTroca);
        }

        public ActionResult ProblemaNaoListado()
        {

            var CUID = Url.RequestContext.RouteData.Values["puID"];
            var currentPU = db.ProdutoUtilizadors.Find(Convert.ToInt32(CUID));

            return RedirectToAction("RazaoTrocas/OutroMotivo", new { id = currentPU.puID });    

        }

        // GET: RazaoTrocas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RazaoTroca razaoTroca = db.RazaoTrocas.Find(id);
            if (razaoTroca == null)
            {
                return HttpNotFound();
            }
            ViewBag.RazaoTrocaID = new SelectList(db.Entregas, "EntregaID", "LocalEntrega", razaoTroca.RazaoTrocaID);
            ViewBag.RazaoTrocaID = new SelectList(db.ProdutoUtilizadors, "puID", "UserID", razaoTroca.RazaoTrocaID);
            return View(razaoTroca);
        }

        // POST: RazaoTrocas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RazaoTrocaID,EntregaID,MotivoAvaria,OutroMotivo")] RazaoTroca razaoTroca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(razaoTroca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RazaoTrocaID = new SelectList(db.Entregas, "EntregaID", "LocalEntrega", razaoTroca.RazaoTrocaID);
            ViewBag.RazaoTrocaID = new SelectList(db.ProdutoUtilizadors, "puID", "UserID", razaoTroca.RazaoTrocaID);
            return View(razaoTroca);
        }

        // GET: RazaoTrocas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RazaoTroca razaoTroca = db.RazaoTrocas.Find(id);
            if (razaoTroca == null)
            {
                return HttpNotFound();
            }
            return View(razaoTroca);
        }

        // POST: RazaoTrocas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RazaoTroca razaoTroca = db.RazaoTrocas.Find(id);
            db.RazaoTrocas.Remove(razaoTroca);
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
