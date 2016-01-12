using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WortenTrocas.Models
{
    public class EspecificacaoTLMTABLETPU
    {
        [Key]
        [ForeignKey("ProdutoUtilizador")]
        public int EspecificacaoTLMTABLETPUID { get; set; }

        public virtual ProdutoUtilizador ProdutoUtilizador { get; set; }

        public String Marca { get; set; }

        public String Ecra { get; set; }

        public String SistemaOperativo { get; set; }

        public double TamanhoEcra { get; set; }

        public String Processador { get; set; }

        public String VelocidadeProcessador { get; set; }

        public bool Camara { get; set; }

        public String ResCamara { get; set; }

        public bool CanaraSecundaria { get; set; }

        public String ResCamaraSecundaria { get; set; }

        public String MemoriaInterna { get; set; }

        public bool MemoriaExterna { get; set; }

        public String Bateria { get; set; }

        public bool Bluetooth { get; set; }

        public bool GPS { get; set; }

        public bool WiFi { get; set; }

        public bool Acelerometro { get; set; }

        public bool Bussola { get; set; }

        public bool SensorProximidade { get; set; }

        public String Cor { get; set; }

        public String Peso { get; set; }

        public String Altura { get; set; }

        public String Largura { get; set; }

        public String Rede { get; set; }

        public bool BloqueadoRede { get; set; }

        public String BloqueRede { get; set; }

        public bool AudioJack { get; set; }

        public String AudioJackType { get; set; }

        public bool CarregadorWireless { get; set; }
    }
}