using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WortenTrocas.Models
{
    public class Email
    {
        [Required, Display(Name = "Nome:")]
        public string FromName { get; set; }
        [Required, Display(Name = "Email:"), EmailAddress]
        public string FromEmail { get; set; }
        [Required, Display(Name = "Assunto:")]
        public string Subject { get; set; }
        [Required, Display(Name = "Mensagem:")]
        public string Message { get; set; }
    }
}