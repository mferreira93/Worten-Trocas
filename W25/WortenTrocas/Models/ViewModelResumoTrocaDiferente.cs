using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WortenTrocas.Models
{
    public class ViewModelResumoTrocaDiferente
    {
        public List<ProdutoUtilizador> ProdutoUtilizador { get; set; }

        public List<TrocaDiferente> TrocaDiferente { get; set; }
    }
}