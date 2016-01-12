using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WortenTrocas.Models
{
    public class ProdutoUtilizador
    {
        [Key]
        public int puID { get; set; }

        public string UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        public int? RazaoTrocaID { get; set; }

        [ForeignKey("RazaoTrocaID")]
        public virtual RazaoTroca RazaoTroca { get; set; }

        public int? TrocaSemelhanteID { get; set; }

        [ForeignKey("TrocaSemelhanteID")]
        public virtual TrocaSemelhante TrocaSemelhante { get; set; }

        public int? EspecificacaoTLMTABLETPUID { get; set; }

        [ForeignKey("EspecificacaoTLMTABLETPUID")]
        public virtual EspecificacaoTLMTABLETPU EspecificacaoTLMTABLETPU { get; set; }

        public int? TrocaDiferenteID { get; set; }

        [ForeignKey("TrocaDiferenteID")]
        public virtual TrocaDiferente TrocaDiferente { get; set; }

        public int? EntregaReembolsoID { get; set; }

        [ForeignKey("EntregaReembolsoID")]
        public virtual EntregaReembolso EntregaReembolso { get; set; }

        [Required]
        public int Referência { get; set; }

        [Required, Display(Name = "Modelo")]
        public string nomeProdutoU { get; set; }

        public String DetalhesPU { get; set; }

        [Required, Display(Name = "Data de Compra")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataDeCompra { get; set; }

        public int DiasRestantes { get; set; }

        [Required, Display(Name = "Adquirido na Worten")]
        public String LocalDeCompra { get; set; }

        public String EstadoDaTroca { get; set; }

        public String Manual { get; set; }

        public String Video1 { get; set; }

        public String Video2 { get; set; }

        public String ImagePath { get; set; }

        public String RandomGeneratedNumber { get; set; }

        public virtual ICollection<FileUtilizador> Files { get; set; }
    }
}