using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WortenTrocas.Models
{
    public class EntregaReembolso
    {
        [Key]
        [ForeignKey("ProdutoATrocar")]
        public int EntregaReembolsoID { get; set; }

        public virtual ProdutoUtilizador ProdutoATrocar { get; set; }

        public int? ResumoTrocaReembolsoID { get; set; }

        [ForeignKey("ResumoTrocaReembolsoID")]
        public virtual ResumoTrocaReembolso ResumoTrocaReembolso { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataDaTrocaLojaReembolso { get; set; }

        public String MetodoPagamentoIBAN { get; set; }

        public String MetodoPagamentoCR { get; set; }

        public String HoraDeEntregaReembolso { get; set; }

        public String LojaWortenReembolso { get; set; }

        public String IBAN { get; set; }

        public String Morada { get; set; }

        public String CPostal { get; set; }
    }
}