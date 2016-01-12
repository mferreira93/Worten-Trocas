using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WortenTrocas.Models;

namespace WortenTrocas.Controllers
{
    public class FileUtilizadorController : ApplicationBaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //
        // GET: /FileUtilizadors/
        public ActionResult Index(int id)
        {
            var fileToRetrieve = db.FileUtilizadors.Find(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}