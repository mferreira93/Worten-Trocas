using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WortenTrocas.Models
{
    public class ViewModelResumoTrocaReembolso
    {
        public List<ProdutoUtilizador> ProdutoUtilizador { get; set; }

        public List<EntregaReembolso> EntregaReembolso { get; set; }
    }
}