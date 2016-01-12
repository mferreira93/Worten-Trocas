using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WortenTrocas.Models
{
    public class Entrega
    {
        [Key]
        [ForeignKey("RazaoTroca")]
        public int EntregaID { get; set; }

        public RazaoTroca RazaoTroca { get; set; }

        public String Morada { get; set; }

        public String CPostal { get; set; }

        public String Cidade { get; set; }

        public String Pais { get; set; }

        public String NTelemovel { get; set; }

        public int? ResumoTrocaID { get; set; }

        [ForeignKey("ResumoTrocaID")]
        public virtual ResumoTroca ResumoTroca { get; set; }

        [Required, Display(Name = "Data do Pedido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataDoPedido { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataDaTrocaCasa { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataDaTrocaLoja { get; set; }

        public String HoraDeEntrega { get; set; }

        public String LojaWorten { get; set; }
    }
}