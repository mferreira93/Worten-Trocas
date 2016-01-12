using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WortenTrocas.Models
{
    public class Produto
    {
        [Key]
        public int ProdutoID { get; set; }

        public int? EspecificacaoTLMTABLETID { get; set; }

        [ForeignKey("EspecificacaoTLMTABLETID")]
        public virtual EspecificacaoTLMTABLET EspecificacaoTLMTABLET { get; set; }

        public String NomeP { get; set; }

        public int Referencia { get; set; }

        public String Marca { get; set; }

        public int Stock { get; set; }

        public String TipoProduto {get; set;}

        public double Price { get; set; }
        
        public String Cor { get; set; }

        public int MemoriaInterna { get; set; }
        
        public String InformacaoBas { get; set; }

        public String ImagePath { get; set; }

        public virtual ICollection<File> Files { get; set; }
               
    }
}