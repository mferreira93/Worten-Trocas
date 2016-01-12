using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WortenTrocas.Models
{
    public class TrocaSemelhante
    {
        [Key]
        [ForeignKey("ProdutoATrocar")]
        public int TrocaSemelhanteID { get; set; }

        public virtual ProdutoUtilizador ProdutoATrocar { get; set; }

        public int? ResumoTrocaSemelhanteID { get; set; }

        [ForeignKey("ResumoTrocaSemelhanteID")]
        public virtual ResumoTrocaSemelhante ResumoTrocaSemelhante { get; set; }

        [Required, Display(Name = "Data da Troca")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataDaTrocaLojaSemelhante { get; set; }

        public String HoraDeEntregaSemelhante { get; set; }

        public String LojaWortenSemelhante { get; set; }

        public String TipoTrocaSemelhante { get; set; }
    }
}