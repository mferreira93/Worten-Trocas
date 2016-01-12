using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WortenTrocas.Models
{
    public class ResumoTroca
    {
        [Key]
        [ForeignKey("Entrega")]
        public int ResumoTrocaID { get; set; }

        public Entrega Entrega { get; set; }
                
    }
}