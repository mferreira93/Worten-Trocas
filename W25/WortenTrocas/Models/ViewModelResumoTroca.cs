using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WortenTrocas.Models
{
    public class ViewModelResumoTroca
    {
        public List<ProdutoUtilizador> ProdutoUtilizador { get; set; }

        public List<Produto> Produto { get; set; }

        public List<Entrega> Entrega { get; set; }
    }
}