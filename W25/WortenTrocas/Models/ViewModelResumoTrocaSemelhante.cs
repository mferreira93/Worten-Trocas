using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WortenTrocas.Models
{
    public class ViewModelResumoTrocaSemelhante
    {
        public List<ProdutoUtilizador> ProdutoUtilizador { get; set; }

        public List<TrocaSemelhante> TrocaSemelhante { get; set; }
    }
}