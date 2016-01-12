using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WortenTrocas.Models
{
    public class ResumoTrocaDiferente
    {
        [Key]
        [ForeignKey("TrocaDiferente")]
        public int TrocaDiferenteID { get; set; }

        public TrocaDiferente TrocaDiferente { get; set; }
    }
}