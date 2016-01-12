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
    public class EspecificacaoTLMTABLETController : ApplicationBaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EspecificacaoTLMTABLET
        public ActionResult Index()
        {
            var especificacaoTLMTABLETs = db.EspecificacaoTLMTABLETs.Include(e => e.Produto);
            return View(especificacaoTLMTABLETs.ToList());
        }

        // GET: EspecificacaoTLMTABLET/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EspecificacaoTLMTABLET especificacaoTLMTABLET = db.EspecificacaoTLMTABLETs.Find(id);
            if (especificacaoTLMTABLET == null)
            {
                return HttpNotFound();
            }
            return View(especificacaoTLMTABLET);
        }

        // GET: EspecificacaoTLMTABLET/Create
        public ActionResult Create()
        {
            ViewBag.EspecificacaoTLMTABLETID = new SelectList(db.Produtoes, "ProdutoID", "NomeP");
            return View();
        }

        // POST: EspecificacaoTLMTABLET/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EspecificacaoTLMTABLETID,Marca,Ecra,SistemaOperativo,TamanhoEcra,Processador,VelocidadeProcessador,Camara,ResCamara,CanaraSecundaria,ResCamaraSecundaria,MemoriaInterna,MemoriaExterna,Bateria,Bluetooth,GPS,WiFi,Acelerometro,Bussola,SensorProximidade,Cor,Peso,Altura,Largura,Rede,BloqueadoRede,BloqueRede,AudioJack,AudioJackType,CarregadorWireless")] EspecificacaoTLMTABLET especificacaoTLMTABLET)
        {
            if (ModelState.IsValid)
            {
                var ProID = Url.RequestContext.RouteData.Values["ProdutoID"];
                var currentPro = db.Produtoes.Find(Convert.ToInt32(ProID));

                especificacaoTLMTABLET.Produto = currentPro;

                db.EspecificacaoTLMTABLETs.Add(especificacaoTLMTABLET);
                currentPro.EspecificacaoTLMTABLETID = especificacaoTLMTABLET.EspecificacaoTLMTABLETID;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EspecificacaoTLMTABLETID = new SelectList(db.Produtoes, "ProdutoID", "NomeP", especificacaoTLMTABLET.EspecificacaoTLMTABLETID);
            return View(especificacaoTLMTABLET);
        }

        // GET: EspecificacaoTLMTABLET/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EspecificacaoTLMTABLET especificacaoTLMTABLET = db.EspecificacaoTLMTABLETs.Find(id);
            if (especificacaoTLMTABLET == null)
            {
                return HttpNotFound();
            }
            ViewBag.EspecificacaoTLMTABLETID = new SelectList(db.Produtoes, "ProdutoID", "NomeP", especificacaoTLMTABLET.EspecificacaoTLMTABLETID);
            return View(especificacaoTLMTABLET);
        }

        // POST: EspecificacaoTLMTABLET/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EspecificacaoTLMTABLETID,Marca,Ecra,SistemaOperativo,TamanhoEcra,Processador,VelocidadeProcessador,Camara,ResCamara,CanaraSecundaria,ResCamaraSecundaria,MemoriaInterna,MemoriaExterna,Bateria,Bluetooth,GPS,WiFi,Acelerometro,Bussola,SensorProximidade,Cor,Peso,Altura,Largura,Rede,BloqueadoRede,BloqueRede,AudioJack,AudioJackType,CarregadorWireless")] EspecificacaoTLMTABLET especificacaoTLMTABLET)
        {
            if (ModelState.IsValid)
            {
                db.Entry(especificacaoTLMTABLET).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EspecificacaoTLMTABLETID = new SelectList(db.Produtoes, "ProdutoID", "NomeP", especificacaoTLMTABLET.EspecificacaoTLMTABLETID);
            return View(especificacaoTLMTABLET);
        }

        // GET: EspecificacaoTLMTABLET/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EspecificacaoTLMTABLET especificacaoTLMTABLET = db.EspecificacaoTLMTABLETs.Find(id);
            if (especificacaoTLMTABLET == null)
            {
                return HttpNotFound();
            }
            return View(especificacaoTLMTABLET);
        }

        // POST: EspecificacaoTLMTABLET/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EspecificacaoTLMTABLET especificacaoTLMTABLET = db.EspecificacaoTLMTABLETs.Find(id);
            db.EspecificacaoTLMTABLETs.Remove(especificacaoTLMTABLET);
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
