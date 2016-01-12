using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WortenTrocas.Models
{
    public class ResumoTrocaSemelhante
    {
        [Key]
        [ForeignKey("TrocaSemelhante")]
        public int ResumoTrocaSemelhanteID { get; set; }

        public TrocaSemelhante TrocaSemelhante { get; set; }
    }
}