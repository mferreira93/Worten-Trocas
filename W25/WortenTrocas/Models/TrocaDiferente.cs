using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WortenTrocas.Models
{
    public class TrocaDiferente
    {
        [Key]
        [ForeignKey("ProdutoATrocar")]
        public int TrocaDiferenteID { get; set; }

        public virtual ProdutoUtilizador ProdutoATrocar { get; set; }

        public int? ResumoTrocaDiferenteID { get; set; }

        [ForeignKey("ResumoTrocaDiferenteID")]
        public virtual ResumoTrocaDiferente ResumoTrocaDiferente { get; set; }

        [Required, Display(Name = "Data da Troca")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataDaTrocaLojaDiferente { get; set; }

        public String HoraDeEntregaDiferente { get; set; }

        public String LojaWortenDiferente { get; set; }

        public String TipoTrocaDiferente { get; set; }
    }
}