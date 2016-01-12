using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WortenTrocas.Models
{
    public class RazaoTroca
    {
        [Key]
        [ForeignKey("ProdutoATrocar")]
        public int RazaoTrocaID { get; set; }

        public int? EntregaID { get; set; }

        [ForeignKey("EntregaID")]
        public virtual Entrega Entrega { get; set; }

        public virtual ProdutoUtilizador ProdutoATrocar { get; set; }

        public string MotivoAvaria { get; set; }

        [DataType(DataType.MultilineText)]
        public string OutroMotivo { get; set; }

    }
}