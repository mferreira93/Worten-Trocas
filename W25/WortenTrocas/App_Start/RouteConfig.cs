using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WortenTrocas
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "RentalPropertyUnit",
                url: "ProdutosUtilizador/RazaoTrocas/Create/{puID}",
                defaults: new { controller = "RazaoTrocas", action = "Create", }
            );

            //routes.MapRoute(
            //    name: "RentalPropertyUnit1",
            //    url: "RazaoTrocas/Avarias/Create/{RazaoTrocaID}",
            //    defaults: new { controller = "Avarias", action = "Create", }
            //);

            routes.MapRoute(
                name: "RentalPropertyUnit2",
                url: "RazaoTrocas/Entregas/Create/{RazaoTrocaID}",
                defaults: new { controller = "Entregas", action = "Create", }
            );

            routes.MapRoute(
                name: "RentalPropertyUnit4",
                url: "Produtos/EspecificacaoTLMTABLET/Create/{ProdutoID}",
                defaults: new { controller = "EspecificacaoTLMTABLET", action = "Create", }
            );

            routes.MapRoute(
               name: "RentalPropertyUnit5",
               url: "ProdutosUtilizador/RazaoTrocas/OutroMotivo/{puID}",
               defaults: new { controller = "RazaoTrocas", action = "OutroMotivo", }
           );

            routes.MapRoute(
                name: "RentalPropertyUnit6",
                url: "ProdutosUtilizador/RazaoTrocas/TriagemProdutoSemelhante/{puID}",
                defaults: new { controller = "RazaoTrocas", action = "TriagemProdutoSemelhante", }
            );

            routes.MapRoute(
                name: "RentalPropertyUnit7",
                url: "ProdutosUtilizador/RazaoTrocas/TriagemAvariado/{puID}",
                defaults: new { controller = "RazaoTrocas", action = "TriagemAvariado", }
            );

            routes.MapRoute(
              name: "RentalPropertyUnit8",
              url: "Home/Account/Login",
              defaults: new { controller = "Account", action = "Login", }
            );

            routes.MapRoute(
              name: "RentalPropertyUnit9",
              url: "Home/ProdutosUtilizador/Index",
              defaults: new { controller = "ProdutosUtilizador", action = "Index", }
            );

            routes.MapRoute(
             name: "RentalPropertyUnit10",
             url: "RazaoTrocas/EspecificacaoTipoProblemas/ProbBateria",
             defaults: new { controller = "EspecificacaoTipoProblemas", action = "ProbBateria", }
           );

            routes.MapRoute(
             name: "RentalPropertyUnit11",
             url: "EspecificacaoTipoProblemas/ResolucaoProbs/NaoCarrega",
             defaults: new { controller = "ResolucaoProbs", action = "NaoCarrega", }
            );

            routes.MapRoute(
             name: "RentalPropertyUnit12",
             url: "EspecificacaoTipoProblemas/ResolucaoProbs/ConsomeDemBat",
             defaults: new { controller = "ResolucaoProbs", action = "ConsomeDemBat", }
            );

            routes.MapRoute(
             name: "RentalPropertyUnit13",
             url: "EspecificacaoTipoProblemas/ResolucaoProbs/AparelhoNaoLiga",
             defaults: new { controller = "ResolucaoProbs", action = "AparelhoNaoLiga", }
            );

            routes.MapRoute(
              name: "RentalPropertyUnit14",
              url: "RazaoTrocas/EspecificacaoTipoProblemas/ProbConectividade",
              defaults: new { controller = "EspecificacaoTipoProblemas", action = "ProbConectividade", }
             );

            routes.MapRoute(
             name: "RentalPropertyUnit15",
             url: "EspecificacaoTipoProblemas/ResolucaoProbs/ConectRedeWiFi",
             defaults: new { controller = "ResolucaoProbs", action = "ConectRedeWiFi", }
            );

            routes.MapRoute(
             name: "RentalPropertyUnit16",
             url: "EspecificacaoTipoProblemas/ResolucaoProbs/NaoDetectaWiFi",
             defaults: new { controller = "ResolucaoProbs", action = "NaoDetectaWiFi", }
            );

            routes.MapRoute(
             name: "RentalPropertyUnit17",
             url: "EspecificacaoTipoProblemas/ResolucaoProbs/NaoEmparelhaBluetooth",
             defaults: new { controller = "ResolucaoProbs", action = "NaoEmparelhaBluetooth", }
            );

            routes.MapRoute(
             name: "RentalPropertyUnit18",
             url: "EspecificacaoTipoProblemas/ResolucaoProbs/NaoDetectaBluetooth",
             defaults: new { controller = "ResolucaoProbs", action = "NaoDetectaBluetooth", }
            );

            routes.MapRoute(
             name: "RentalPropertyUnit19",
             url: "EspecificacaoTipoProblemas/ResolucaoProbs/NaoApanhaRedeCorrecta",
             defaults: new { controller = "ResolucaoProbs", action = "NaoApanhaRedeCorrecta", }
            );

            routes.MapRoute(
             name: "RentalPropertyUnit20",
             url: "EspecificacaoTipoProblemas/ResolucaoProbs/NaoTemRedeMovel",
             defaults: new { controller = "ResolucaoProbs", action = "NaoTemRedeMovel", }
            );

            routes.MapRoute(
             name: "RentalPropertyUnit21",
             url: "RazaoTrocas/EspecificacaoTipoProblemas/ProbEcra",
             defaults: new { controller = "EspecificacaoTipoProblemas", action = "ProbEcra", }
            );

            routes.MapRoute(
            name: "RentalPropertyUnit22",
            url: "EspecificacaoTipoProblemas/ResolucaoProbs/NaoLigaEcra",
            defaults: new { controller = "ResolucaoProbs", action = "NaoLigaEcra", }
            );

            routes.MapRoute(
            name: "RentalPropertyUnit23",
            url: "EspecificacaoTipoProblemas/ResolucaoProbs/LuminosidadeFraca",
            defaults: new { controller = "ResolucaoProbs", action = "LuminosidadeFraca", }
            );

            routes.MapRoute(
            name: "RentalPropertyUnit24",
            url: "EspecificacaoTipoProblemas/ResolucaoProbs/TonalidadeDiferente",
            defaults: new { controller = "ResolucaoProbs", action = "TonalidadeDiferente", }
            );

            routes.MapRoute(
            name: "RentalPropertyUnit25",
            url: "EspecificacaoTipoProblemas/ResolucaoProbs/NaoRespondeTouch",
            defaults: new { controller = "ResolucaoProbs", action = "NaoRespondeTouch", }
            );

            routes.MapRoute(
            name: "RentalPropertyUnit26",
            url: "EspecificacaoTipoProblemas/ResolucaoProbs/PixelMorto",
            defaults: new { controller = "ResolucaoProbs", action = "PixelMorto", }
            );

            routes.MapRoute(
             name: "RentalPropertyUnit27",
             url: "RazaoTrocas/EspecificacaoTipoProblemas/ProbSom",
             defaults: new { controller = "EspecificacaoTipoProblemas", action = "ProbSom", }
            );

            routes.MapRoute(
            name: "RentalPropertyUnit28",
            url: "RazaoTrocas/EspecificacaoTipoProblemas/ProbCâmara",
            defaults: new { controller = "EspecificacaoTipoProblemas", action = "ProbCâmara", }
           );

            routes.MapRoute(
             name: "RentalPropertyUnit29",
             url: "RazaoTrocas/EspecificacaoTipoProblemas/ProbHardware",
             defaults: new { controller = "EspecificacaoTipoProblemas", action = "ProbHardware", }
            );

            routes.MapRoute(
            name: "RentalPropertyUnit30",
            url: "EspecificacaoTipoProblemas/ResolucaoProbs/BotaoEncravado",
            defaults: new { controller = "ResolucaoProbs", action = "BotaoEncravado", }
            );

            routes.MapRoute(
            name: "RentalPropertyUnit31",
            url: "EspecificacaoTipoProblemas/ResolucaoProbs/EntradaAuricularObst",
            defaults: new { controller = "ResolucaoProbs", action = "EntradaAuricularObst", }
            );

            routes.MapRoute(
            name: "RentalPropertyUnit32",
            url: "EspecificacaoTipoProblemas/ResolucaoProbs/CarregamentoIncompatível",
            defaults: new { controller = "ResolucaoProbs", action = "CarregamentoIncompatível", }
            );

            routes.MapRoute(
            name: "RentalPropertyUnit33",
            url: "EspecificacaoTipoProblemas/ResolucaoProbs/CartãoMemóriaNaoEntra",
            defaults: new { controller = "ResolucaoProbs", action = "CartãoMemóriaNaoEntra", }
            );

            routes.MapRoute(
            name: "RentalPropertyUnit34",
            url: "EspecificacaoTipoProblemas/ResolucaoProbs/CartãoSIMNaoEntra",
            defaults: new { controller = "ResolucaoProbs", action = "CartãoSIMNaoEntra", }
            );

            routes.MapRoute(
            name: "RentalPropertyUnit35",
            url: "EspecificacaoTipoProblemas/ResolucaoProbs/Concluido",
            defaults: new { controller = "ResolucaoProbs", action = "Concluido", }
            );

            routes.MapRoute(
           name: "RentalPropertyUnit36",
           url: "EspecificacaoTipoProblemas/ResolucaoProbs/SemSom",
           defaults: new { controller = "ResolucaoProbs", action = "SemSom", }
           );

            routes.MapRoute(
           name: "RentalPropertyUnit37",
           url: "EspecificacaoTipoProblemas/ResolucaoProbs/SomFalhas",
           defaults: new { controller = "ResolucaoProbs", action = "SomFalhas", }
           );

            routes.MapRoute(
           name: "RentalPropertyUnit38",
           url: "EspecificacaoTipoProblemas/ResolucaoProbs/SomAuscultadores",
           defaults: new { controller = "ResolucaoProbs", action = "SomAuscultadores", }
           );

            routes.MapRoute(
           name: "RentalPropertyUnit39",
           url: "EspecificacaoTipoProblemas/ResolucaoProbs/SomMicrofone",
           defaults: new { controller = "ResolucaoProbs", action = "SomMicrofone", }
           );

            routes.MapRoute(
           name: "RentalPropertyUnit40",
           url: "EspecificacaoTipoProblemas/ResolucaoProbs/CâmaraNãoLiga",
           defaults: new { controller = "ResolucaoProbs", action = "CâmaraNãoLiga", }
           );

            routes.MapRoute(
           name: "RentalPropertyUnit41",
           url: "EspecificacaoTipoProblemas/ResolucaoProbs/CâmaraNãoFoca",
           defaults: new { controller = "ResolucaoProbs", action = "CâmaraNãoFoca", }
           );

            routes.MapRoute(
            name: "RentalPropertyUnit42",
            url: "EspecificacaoTipoProblemas/ResolucaoProbs/CâmaraFlash",
            defaults: new { controller = "ResolucaoProbs", action = "CâmaraFlash", }
            );

            routes.MapRoute(
           name: "RentalPropertyUnit43",
           url: "EspecificacaoTipoProblemas/ResolucaoProbs/CâmaraFlash",
           defaults: new { controller = "ResolucaoProbs", action = "CâmaraFlash", }
           );

            routes.MapRoute(
     name: "RentalPropertyUnit44",
     url: "RazaoTrocas/TriagemAvariado/{puID}",
     defaults: new { controller = "ProdutosUtilizador", action = "TriagemAvariado", }
     );

            routes.MapRoute(
              name: "RentalPropertyUnit45",
              url: "Home/ResumoTrocas/EstadoTroca",
              defaults: new { controller = "ResumoTrocas", action = "EstadoTroca", }
            );

            routes.MapRoute(
    name: "RentalPropertyUnit46",
    url: "Entregas/ResumoTroca/Resumo/{EntregaID}",
    defaults: new { controller = "ResumoTrocas", action = "Resumo", }
    );

            routes.MapRoute(
        name: "RentalPropertyUnit47",
        url: "RazaoTrocas/RazaoTrocas/OutroMotivo/{puID}",
        defaults: new { controller = "RazaoTrocas", action = "OutroMotivo", }
        );

            routes.MapRoute(
name: "RentalPropertyUnit48",
url: "ProdutosUtilizador/ProdSems/CaractEscolha/{puID}",
defaults: new { controller = "ProdSems", action = "CaractEscolha", }
);

            routes.MapRoute(
name: "RentalPropertyUnit49",
url: "ProdSems/MarcaSem/{puID}",
defaults: new { controller = "ProdSems", action = "MarcaSem", }
);

            routes.MapRoute(
name: "RentalPropertyUnit50",
url: "ProdSems/xpto/{puID}",
defaults: new { controller = "ProdSems", action = "xpto", }
);

            routes.MapRoute(
name: "RentalPropertyUnit51",
url: "ProdSems/TrocaSems/Create/{puID}",
defaults: new { controller = "TrocaSems", action = "Create", }
);

            routes.MapRoute(
name: "RentalPropertyUnit52",
url: "TrocaSems/Sugestao/{puID}",
defaults: new { controller = "TrocaSems", action = "Sugestao", }
);

            routes.MapRoute(
                name: "RentalPropertyUnit53",
                url: "ProdutosUtilizador/EspecificacaoTLMTABLETPU/Create/{puID}",
                defaults: new { controller = "EspecificacaoTLMTABLETPU", action = "Create", }
            );

            routes.MapRoute(
               name: "RentalPropertyUnit54",
               url: "ProdutosUtilizador/Concluido/{puID}",
               defaults: new { controller = "ProdutosUtilizador", action = "Concluido", }
           );

            routes.MapRoute(
               name: "RentalPropertyUnit55",
               url: "ProdutosUtilizador/TrocaDiferentes/Create/{puID}",
               defaults: new { controller = "TrocaDiferentes", action = "Create", }
           );

            routes.MapRoute(
               name: "RentalPropertyUnit56",
               url: "TrocaDiferentes/ResumoTrocaDiferentes/ResumoDiferente/{TrocaDiferenteID}",
               defaults: new { controller = "ResumoTrocaDiferentes", action = "ResumoDiferente", }
           );

            routes.MapRoute(
              name: "RentalPropertyUnit57",
url: "ProdutosUtilizador/ProdSems/Index/{puID}",
defaults: new { controller = "ProdSems", action = "Index", }
);

            routes.MapRoute(
              name: "RentalPropertyUnit58",
url: "ProdSems/TrocaSemelhantes/Create/{ProdutoID}",
defaults: new { controller = "TrocaSemehantes", action = "Create", }
);

            routes.MapRoute(
  name: "RentalPropertyUnit59",
url: "ProdutosUtilizador/EntregasReembolso/Create/{puID}",
defaults: new { controller = "EntregasReembolso", action = "Create", }
);

            routes.MapRoute(
              name: "RentalPropertyUnit60",
url: "EntregasReembolso/ResumoTrocaReembolsos/ResumoReembolso/{EntregaReembolsoID}",
defaults: new { controller = "ResumoTrocaReembolsos", action = "ResumoReembolso", }
);
            routes.MapRoute(
  name: "RentalPropertyUnit61",
url: "ProdutosUtilizador/TrocaSemelhantes/Create/{puID}",
defaults: new { controller = "TrocaSemelhantes", action = "Create", }
);

            routes.MapRoute(
  name: "RentalPropertyUnit62",
url: "TrocaSemelhantes/ResumoTrocaSemelhantes/ResumoSemelhante/{TrocaSemelhanteID}",
defaults: new { controller = "ResumoTrocaSemelhantes", action = "ResumoSemelhante", }
);

            routes.MapRoute(
name: "RentalPropertyUnit63",
url: "Home/ProdutosUtilizador/IndexEstadoTroca",
defaults: new { controller = "ProdutosUtilizador", action = "IndexEstadoTroca", }
);
            routes.MapRoute(
            name: "RentalPropertyUnit64",
url: "ProdutosUtilizador/EscolherTipoTroca",
defaults: new { controller = "ProdutosUtilizador", action = "EscolherTipoTroca", }
);

            routes.MapRoute(
name: "RentalPropertyUnit65",
url: "ProdutosUtilizador/EstadoTrocaSemelhante/{puID}",
defaults: new { controller = "ProdutosUtilizador", action = "EstadoTrocaSemelhante", }
);
            routes.MapRoute(
name: "RentalPropertyUnit66",
url: "ProdutosUtilizador/EstadoTrocaAvaria/{puID}",
defaults: new { controller = "ProdutosUtilizador", action = "EstadoTrocaAvaria", }
);

            routes.MapRoute(
name: "RentalPropertyUnit67",
url: "ProdutosUtilizador/EstadoTrocaDiferente/{puID}",
defaults: new { controller = "ProdutosUtilizador", action = "EstadoTrocaDiferente", }
);

            routes.MapRoute(
name: "RentalPropertyUnit68",
url: "ProdutosUtilizador/EstadoTrocaReembolso/{puID}",
defaults: new { controller = "ProdutosUtilizador", action = "EstadoTrocaReembolso", }
);

            routes.MapRoute(
name: "RentalPropertyUnit69",
url: "Home/Admin",
defaults: new { controller = "Home", action = "Admin", }
);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
