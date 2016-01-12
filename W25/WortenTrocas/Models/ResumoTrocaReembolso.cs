using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WortenTrocas.Models
{
    public class ResumoTrocaReembolso
    {
        [Key]
        [ForeignKey("EntregaReembolso")]
        public int EntregaReembolsoID { get; set; }

        public EntregaReembolso EntregaReembolso { get; set; }
    }
}