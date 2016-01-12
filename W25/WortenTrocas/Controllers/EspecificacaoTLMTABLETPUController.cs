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
    public class EspecificacaoTLMTABLETPUController : ApplicationBaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EspecificacaoTLMTABLETPU
        public ActionResult Index()
        {
            var especificacaoTLMTABLETPUs = db.EspecificacaoTLMTABLETPUs.Include(e => e.ProdutoUtilizador);
            return View(especificacaoTLMTABLETPUs.ToList());
        }

        // GET: EspecificacaoTLMTABLETPU/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EspecificacaoTLMTABLETPU especificacaoTLMTABLETPU = db.EspecificacaoTLMTABLETPUs.Find(id);
            if (especificacaoTLMTABLETPU == null)
            {
                return HttpNotFound();
            }
            return View(especificacaoTLMTABLETPU);
        }

        // GET: EspecificacaoTLMTABLETPU/Create
        public ActionResult Create()
        {
            ViewBag.EspecificacaoTLMTABLETPUID = new SelectList(db.ProdutoUtilizadors, "puID", "UserID");
            return View();
        }

        // POST: EspecificacaoTLMTABLETPU/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EspecificacaoTLMTABLETPUID,Marca,Ecra,SistemaOperativo,TamanhoEcra,Processador,VelocidadeProcessador,Camara,ResCamara,CanaraSecundaria,ResCamaraSecundaria,MemoriaInterna,MemoriaExterna,Bateria,Bluetooth,GPS,WiFi,Acelerometro,Bussola,SensorProximidade,Cor,Peso,Altura,Largura,Rede,BloqueadoRede,BloqueRede,AudioJack,AudioJackType,CarregadorWireless")] EspecificacaoTLMTABLETPU especificacaoTLMTABLETPU)
        {
            if (ModelState.IsValid)
            {
                var CUID = Url.RequestContext.RouteData.Values["puID"];
                var currentPU = db.ProdutoUtilizadors.Find(Convert.ToInt32(CUID));

                especificacaoTLMTABLETPU.ProdutoUtilizador = currentPU;

                db.EspecificacaoTLMTABLETPUs.Add(especificacaoTLMTABLETPU);
                currentPU.EspecificacaoTLMTABLETPUID = especificacaoTLMTABLETPU.EspecificacaoTLMTABLETPUID;
                db.SaveChanges();
                return RedirectToAction("../ProdutosUtilizador/Index");
            }

            ViewBag.EspecificacaoTLMTABLETPUID = new SelectList(db.ProdutoUtilizadors, "puID", "UserID", especificacaoTLMTABLETPU.EspecificacaoTLMTABLETPUID);
            return View(especificacaoTLMTABLETPU);
        }

        // GET: EspecificacaoTLMTABLETPU/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EspecificacaoTLMTABLETPU especificacaoTLMTABLETPU = db.EspecificacaoTLMTABLETPUs.Find(id);
            if (especificacaoTLMTABLETPU == null)
            {
                return HttpNotFound();
            }
            ViewBag.EspecificacaoTLMTABLETPUID = new SelectList(db.ProdutoUtilizadors, "puID", "UserID", especificacaoTLMTABLETPU.EspecificacaoTLMTABLETPUID);
            return View(especificacaoTLMTABLETPU);
        }

        // POST: EspecificacaoTLMTABLETPU/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EspecificacaoTLMTABLETPUID,Marca,Ecra,SistemaOperativo,TamanhoEcra,Processador,VelocidadeProcessador,Camara,ResCamara,CanaraSecundaria,ResCamaraSecundaria,MemoriaInterna,MemoriaExterna,Bateria,Bluetooth,GPS,WiFi,Acelerometro,Bussola,SensorProximidade,Cor,Peso,Altura,Largura,Rede,BloqueadoRede,BloqueRede,AudioJack,AudioJackType,CarregadorWireless")] EspecificacaoTLMTABLETPU especificacaoTLMTABLETPU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(especificacaoTLMTABLETPU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EspecificacaoTLMTABLETPUID = new SelectList(db.ProdutoUtilizadors, "puID", "UserID", especificacaoTLMTABLETPU.EspecificacaoTLMTABLETPUID);
            return View(especificacaoTLMTABLETPU);
        }

        // GET: EspecificacaoTLMTABLETPU/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EspecificacaoTLMTABLETPU especificacaoTLMTABLETPU = db.EspecificacaoTLMTABLETPUs.Find(id);
            if (especificacaoTLMTABLETPU == null)
            {
                return HttpNotFound();
            }
            return View(especificacaoTLMTABLETPU);
        }

        // POST: EspecificacaoTLMTABLETPU/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EspecificacaoTLMTABLETPU especificacaoTLMTABLETPU = db.EspecificacaoTLMTABLETPUs.Find(id);
            db.EspecificacaoTLMTABLETPUs.Remove(especificacaoTLMTABLETPU);
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
