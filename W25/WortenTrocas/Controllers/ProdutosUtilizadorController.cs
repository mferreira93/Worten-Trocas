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
using System.Text.RegularExpressions;

namespace WortenTrocas.Controllers
{
    public class ProdutosUtilizadorController : ApplicationBaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProdutosUtilizador
        public ActionResult Index()
        {
            var currentUserID = db.Users.Find(User.Identity.GetUserId()).Id;
            var produtoUtilizadors = db.ProdutoUtilizadors.Include(p => p.EntregaReembolso).Include(p => p.EspecificacaoTLMTABLETPU).Include(p => p.RazaoTroca).Include(p => p.TrocaDiferente).Include(p => p.TrocaSemelhante).Include(p => p.User).Where(p => p.UserID == currentUserID);
            return View(produtoUtilizadors.ToList());
        }

        // GET: ProdutosUtilizador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoUtilizador produtoUtilizador = db.ProdutoUtilizadors.Find(id);
            if (produtoUtilizador == null)
            {
                return HttpNotFound();
            }
            return View(produtoUtilizador);
        }

        // GET: ProdutosUtilizador/Create
        public ActionResult Create()
        {
            ViewBag.puID = new SelectList(db.EntregaReembolsoes, "EntregaReembolsoID", "MetodoPagamentoIBAN");
            ViewBag.puID = new SelectList(db.EspecificacaoTLMTABLETPUs, "EspecificacaoTLMTABLETPUID", "Marca");
            ViewBag.puID = new SelectList(db.RazaoTrocas, "RazaoTrocaID", "MotivoAvaria");
            ViewBag.puID = new SelectList(db.TrocaDiferentes, "TrocaDiferenteID", "HoraDeEntregaDiferente");
            ViewBag.puID = new SelectList(db.TrocaSemelhantes, "TrocaSemelhanteID", "HoraDeEntregaSemelhante");
            ViewBag.UserID = new SelectList(db.Users, "Id", "NResolve");
            return View();
        }

        // POST: ProdutosUtilizador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "puID,UserID,RazaoTrocaID,TrocaSemelhanteID,EspecificacaoTLMTABLETPUID,TrocaDiferenteID,EntregaReembolsoID,Referência,nomeProdutoU,DetalhesPU,DataDeCompra,DiasRestantes,LocalDeCompra,EstadoDaTroca,Manual,Video1,Video2,ImagePath,RandomGeneratedNumber")] ProdutoUtilizador produtoUtilizador)
        {
            if (ModelState.IsValid)
            {
                var currentUser = db.Users.Find(User.Identity.GetUserId());
                produtoUtilizador.User = currentUser;

                var ONE_DAY = 1000 * 60 * 60 * 24;

                string newPassword = System.Web.Security.Membership.GeneratePassword(12, 0);
                Random rnd = new Random();
                newPassword = Regex.Replace(newPassword, @"[^a-zA-Z0-9]", m => rnd.Next(0, 9).ToString());

                produtoUtilizador.RandomGeneratedNumber = newPassword;

                db.ProdutoUtilizadors.Add(produtoUtilizador);
                var difference_ms = Math.Abs((DateTime.Now - produtoUtilizador.DataDeCompra).TotalMilliseconds);
                var x = Math.Round(difference_ms / ONE_DAY);
                var f = 30.00 - x;
                produtoUtilizador.DiasRestantes = Convert.ToInt32(f + 0.50);
                db.SaveChanges();
                return RedirectToAction("EspecificacaoTLMTABLETPU/Create", new { id = produtoUtilizador.puID });
            }

            ViewBag.puID = new SelectList(db.EntregaReembolsoes, "EntregaReembolsoID", "MetodoPagamentoIBAN", produtoUtilizador.puID);
            ViewBag.puID = new SelectList(db.EspecificacaoTLMTABLETPUs, "EspecificacaoTLMTABLETPUID", "Marca", produtoUtilizador.puID);
            ViewBag.puID = new SelectList(db.RazaoTrocas, "RazaoTrocaID", "MotivoAvaria", produtoUtilizador.puID);
            ViewBag.puID = new SelectList(db.TrocaDiferentes, "TrocaDiferenteID", "HoraDeEntregaDiferente", produtoUtilizador.puID);
            ViewBag.puID = new SelectList(db.TrocaSemelhantes, "TrocaSemelhanteID", "HoraDeEntregaSemelhante", produtoUtilizador.puID);
            ViewBag.UserID = new SelectList(db.Users, "Id", "NResolve", produtoUtilizador.UserID);
            return View(produtoUtilizador);
        }

        // GET: ProdutosUtilizador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoUtilizador produtoUtilizador = db.ProdutoUtilizadors.Find(id);
            if (produtoUtilizador == null)
            {
                return HttpNotFound();
            }
            ViewBag.puID = new SelectList(db.EntregaReembolsoes, "EntregaReembolsoID", "MetodoPagamentoIBAN", produtoUtilizador.puID);
            ViewBag.puID = new SelectList(db.EspecificacaoTLMTABLETPUs, "EspecificacaoTLMTABLETPUID", "Marca", produtoUtilizador.puID);
            ViewBag.puID = new SelectList(db.RazaoTrocas, "RazaoTrocaID", "MotivoAvaria", produtoUtilizador.puID);
            ViewBag.puID = new SelectList(db.TrocaDiferentes, "TrocaDiferenteID", "HoraDeEntregaDiferente", produtoUtilizador.puID);
            ViewBag.puID = new SelectList(db.TrocaSemelhantes, "TrocaSemelhanteID", "HoraDeEntregaSemelhante", produtoUtilizador.puID);
            ViewBag.UserID = new SelectList(db.Users, "Id", "NResolve", produtoUtilizador.UserID);
            return View(produtoUtilizador);
        }

        // POST: ProdutosUtilizador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "puID,UserID,RazaoTrocaID,TrocaSemelhanteID,EspecificacaoTLMTABLETPUID,TrocaDiferenteID,EntregaReembolsoID,Referência,nomeProdutoU,DetalhesPU,DataDeCompra,DiasRestantes,LocalDeCompra,EstadoDaTroca,Manual,Video1,Video2,ImagePath,RandomGeneratedNumber")] ProdutoUtilizador produtoUtilizador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produtoUtilizador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.puID = new SelectList(db.EntregaReembolsoes, "EntregaReembolsoID", "MetodoPagamentoIBAN", produtoUtilizador.puID);
            ViewBag.puID = new SelectList(db.EspecificacaoTLMTABLETPUs, "EspecificacaoTLMTABLETPUID", "Marca", produtoUtilizador.puID);
            ViewBag.puID = new SelectList(db.RazaoTrocas, "RazaoTrocaID", "MotivoAvaria", produtoUtilizador.puID);
            ViewBag.puID = new SelectList(db.TrocaDiferentes, "TrocaDiferenteID", "HoraDeEntregaDiferente", produtoUtilizador.puID);
            ViewBag.puID = new SelectList(db.TrocaSemelhantes, "TrocaSemelhanteID", "HoraDeEntregaSemelhante", produtoUtilizador.puID);
            ViewBag.UserID = new SelectList(db.Users, "Id", "NResolve", produtoUtilizador.UserID);
            return View(produtoUtilizador);
        }

        // GET: ProdutosUtilizador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoUtilizador produtoUtilizador = db.ProdutoUtilizadors.Find(id);
            if (produtoUtilizador == null)
            {
                return HttpNotFound();
            }
            return View(produtoUtilizador);
        }

        // POST: ProdutosUtilizador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProdutoUtilizador produtoUtilizador = db.ProdutoUtilizadors.Find(id);
            db.ProdutoUtilizadors.Remove(produtoUtilizador);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Concluido()
        {
            var CUID = Url.RequestContext.RouteData.Values["puID"];
            var currentPU = db.ProdutoUtilizadors.Find(Convert.ToInt32(CUID));

            if (CUID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoUtilizador produtoUtilizador = currentPU;
            if (produtoUtilizador == null)
            {
                return HttpNotFound();
            }
            return View(produtoUtilizador);
        }

        public ActionResult IndexEstadoTroca()
        {
            var currentUserID = db.Users.Find(User.Identity.GetUserId()).Id;
            var produtoUtilizadors = db.ProdutoUtilizadors.Include(p => p.EntregaReembolso).Include(p => p.EspecificacaoTLMTABLETPU).Include(p => p.RazaoTroca).Include(p => p.TrocaDiferente).Include(p => p.TrocaSemelhante).Include(p => p.User).Where(p => p.UserID == currentUserID);
            return View(produtoUtilizadors.ToList());  
        }


        public ActionResult EscolherTipoTroca(int? id)
        {
           var currentPU = db.ProdutoUtilizadors.Find(Convert.ToInt32(id));

           if (currentPU.TrocaSemelhanteID != null)
           {

               return RedirectToAction("EstadoTrocaSemelhante", new { id = currentPU.puID });

           }
           
            if (currentPU.TrocaDiferenteID != null)
           {

               return RedirectToAction("EstadoTrocaDiferente", new { id = currentPU.puID });

           }
          
           if (currentPU.EntregaReembolsoID != null)
           {

               return RedirectToAction("EstadoTrocaReembolso", new { id = currentPU.puID });

           }


           if (currentPU.RazaoTroca.EntregaID != null)
           {
               return RedirectToAction("EstadoTrocaAvaria", new { id = currentPU.puID });

           }
           return View();
            

        }

        public ActionResult EstadoTrocaAvaria()
        {
            var CUID = Url.RequestContext.RouteData.Values["puID"];
            var currentPU = db.ProdutoUtilizadors.Find(Convert.ToInt32(CUID));

            var currentUserID = db.Users.Find(User.Identity.GetUserId()).Id;
            var produtoUtilizadors = db.ProdutoUtilizadors.Include(p => p.RazaoTroca).Include(p => p.User).Where(p => p.UserID == currentUserID);
            var pAvariado = produtoUtilizadors.Where(p => p.puID == currentPU.RazaoTroca.EntregaID);

            var currentProd = (from Produtoes in db.Produtoes
                               where Produtoes.Referencia == currentPU.Referência
                               select Produtoes.Referencia).FirstOrDefault();

            var data = db.Entregas.Where(p => p.EntregaID == currentPU.RazaoTroca.EntregaID);

            var viewModel = new ViewModelResumoTroca()
            {
                Produto = new List<Produto>(db.Produtoes.Where(p => p.Referencia == currentProd).ToList()) { },
                ProdutoUtilizador = new List<ProdutoUtilizador>(pAvariado.ToList()) { },
                Entrega = new List<Entrega>(data.ToList()) { }
            };
            return View(viewModel);
        }

        public ActionResult EstadoTrocaSemelhante()
        {
            var CUID = Url.RequestContext.RouteData.Values["puID"];
            var currentPU = db.ProdutoUtilizadors.Find(Convert.ToInt32(CUID));

            var currentUserID = db.Users.Find(User.Identity.GetUserId()).Id;
            var produtoUtilizadors = db.ProdutoUtilizadors.Include(p => p.TrocaSemelhante).Include(p => p.User).Where(p => p.UserID == currentUserID);
            var pAvariado = produtoUtilizadors.Where(p => p.puID == currentPU.TrocaSemelhanteID);

            var data = db.TrocaSemelhantes.Where(p => p.TrocaSemelhanteID == currentPU.TrocaSemelhanteID);


            var viewModel = new ViewModelResumoTrocaSemelhante()
            {
                ProdutoUtilizador = new List<ProdutoUtilizador>(pAvariado.ToList()) { },
                TrocaSemelhante = new List<TrocaSemelhante>(data.ToList()) { }
            };
            return View(viewModel);
        }

        public ActionResult EstadoTrocaDiferente()
        {
            var CUID = Url.RequestContext.RouteData.Values["puID"];
            var currentPU = db.ProdutoUtilizadors.Find(Convert.ToInt32(CUID));

            var currentUserID = db.Users.Find(User.Identity.GetUserId()).Id;
            var produtoUtilizadors = db.ProdutoUtilizadors.Include(p => p.TrocaDiferente).Include(p => p.User).Where(p => p.UserID == currentUserID);
            var pAvariado = produtoUtilizadors.Where(p => p.puID == currentPU.TrocaDiferenteID);

            var data = db.TrocaDiferentes.Where(p => p.TrocaDiferenteID == currentPU.TrocaDiferenteID);


            var viewModel = new ViewModelResumoTrocaDiferente()
            {
                ProdutoUtilizador = new List<ProdutoUtilizador>(pAvariado.ToList()) { },
                TrocaDiferente = new List<TrocaDiferente>(data.ToList()) { }
            };
            return View(viewModel);
        }

        public ActionResult EstadoTrocaReembolso()
        {
            var CUID = Url.RequestContext.RouteData.Values["puID"];
            var currentPU = db.ProdutoUtilizadors.Find(Convert.ToInt32(CUID));

            var currentUserID = db.Users.Find(User.Identity.GetUserId()).Id;
            var produtoUtilizadors = db.ProdutoUtilizadors.Include(p => p.TrocaDiferente).Include(p => p.User).Where(p => p.UserID == currentUserID);
            var pAvariado = produtoUtilizadors.Where(p => p.puID == currentPU.EntregaReembolsoID);

            var data = db.EntregaReembolsoes.Where(p => p.EntregaReembolsoID == currentPU.EntregaReembolsoID);


            var viewModel = new ViewModelResumoTrocaReembolso()
            {
                ProdutoUtilizador = new List<ProdutoUtilizador>(pAvariado.ToList()) { },
                EntregaReembolso = new List<EntregaReembolso>(data.ToList()) { }
            };
            return View(viewModel);
        }

        // GET: ProdutosUtilizador/Create
        public ActionResult CreateAdmin()
        {
            ViewBag.puID = new SelectList(db.EntregaReembolsoes, "EntregaReembolsoID", "MetodoPagamentoIBAN");
            ViewBag.puID = new SelectList(db.EspecificacaoTLMTABLETPUs, "EspecificacaoTLMTABLETPUID", "Marca");
            ViewBag.puID = new SelectList(db.RazaoTrocas, "RazaoTrocaID", "MotivoAvaria");
            ViewBag.puID = new SelectList(db.TrocaDiferentes, "TrocaDiferenteID", "HoraDeEntregaDiferente");
            ViewBag.UserID = new SelectList(db.Users, "Id", "NResolve");
            return View();
        }

        // POST: ProdutosUtilizador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAdmin([Bind(Include = "puID,UserID,RazaoTrocaID,ProdSemID,EspecificacaoTLMTABLETPUID,TrocaDiferenteID,EntregaReembolsoID,Referência,nomeProdutoU,DetalhesPU,DataDeCompra,DiasRestantes,LocalDeCompra,EstadoDaTroca,Manual,Video1,Video2,ImagePath,RandomGeneratedNumber")] ProdutoUtilizador produtoUtilizador)
        {
            if (ModelState.IsValid)
            {
                //var currentUser = db.Users.Find(User.Identity.GetUserId());
                //produtoUtilizador.User = currentUser;

                var ONE_DAY = 1000 * 60 * 60 * 24;

                string newPassword = System.Web.Security.Membership.GeneratePassword(12, 0);
                Random rnd = new Random();
                newPassword = Regex.Replace(newPassword, @"[^a-zA-Z0-9]", m => rnd.Next(0, 9).ToString());

                produtoUtilizador.RandomGeneratedNumber = newPassword;

                db.ProdutoUtilizadors.Add(produtoUtilizador);
                var difference_ms = Math.Abs((DateTime.Now - produtoUtilizador.DataDeCompra).TotalMilliseconds);
                var x = Math.Round(difference_ms / ONE_DAY);
                var f = 30.00 - x;
                produtoUtilizador.DiasRestantes = Convert.ToInt32(f + 0.50);
                db.SaveChanges();
                return RedirectToAction("EspecificacaoTLMTABLETPU/Create", new { id = produtoUtilizador.puID });
            }

            ViewBag.puID = new SelectList(db.EntregaReembolsoes, "EntregaReembolsoID", "MetodoPagamentoIBAN", produtoUtilizador.puID);
            ViewBag.puID = new SelectList(db.EspecificacaoTLMTABLETPUs, "EspecificacaoTLMTABLETPUID", "Marca", produtoUtilizador.puID);
            ViewBag.puID = new SelectList(db.RazaoTrocas, "RazaoTrocaID", "MotivoAvaria", produtoUtilizador.puID);
            ViewBag.puID = new SelectList(db.TrocaDiferentes, "TrocaDiferenteID", "HoraDeEntregaDiferente", produtoUtilizador.puID);
            ViewBag.UserID = new SelectList(db.Users, "Id", "NResolve", produtoUtilizador.UserID);
            return View(produtoUtilizador);
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
