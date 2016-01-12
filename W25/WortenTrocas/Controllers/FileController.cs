using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Data.Entity;
using System.Net;

using WortenTrocas.Models;
using Microsoft.AspNet.Identity;

namespace WortenTrocas.Controllers
{
    public class FileController : ApplicationBaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //
        // GET: /File/
        public ActionResult Index(int id)
        {
            var fileToRetrieve = db.Files.Find(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}