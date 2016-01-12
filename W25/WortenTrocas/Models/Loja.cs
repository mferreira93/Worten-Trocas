using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WortenTrocas.Models
{
    public class Loja
    {
        public int LojaID { get; set; }
        
        [Required]
        public string Worten { get; set; }

        [Required]
        public string Morada { get; set; }

        [Required]
        public double latitude { get; set; }

        [Required]
        public double longitude { get; set; }
    }
}