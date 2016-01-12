using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WortenTrocas.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WortenTrocas.Controllers
{
    public class HomeController : ApplicationBaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Suporte()
        {
             return View();
        }

        public ActionResult Logado()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("ProdutosUtilizador/Index");
            }

            return RedirectToAction("Account/Login");

        }

        public ActionResult Logado2()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("ProdutosUtilizador/IndexEstadoTroca");
            }

            return RedirectToAction("Account/Login");

        }



        public ActionResult EmailEnviado()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Suporte(Email model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>De: {0} ({1})</p><p>Assunto: {2}</p><p>Messagem:</p><p>{3}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("wortentrocas@gmail.com"));
                message.From = new MailAddress("sender@outlook.com");
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Subject, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "wortentrocas@gmail.com",
                        Password = "pimstt2015"
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("EmailEnviado");
                }
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            return View();
        }
    }
}