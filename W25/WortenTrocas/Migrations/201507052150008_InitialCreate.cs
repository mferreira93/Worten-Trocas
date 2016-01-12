namespace WortenTrocas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntregaReembolsoes",
                c => new
                    {
                        EntregaReembolsoID = c.Int(nullable: false),
                        ResumoTrocaReembolsoID = c.Int(),
                        DataDaTrocaLojaReembolso = c.DateTime(),
                        MetodoPagamentoIBAN = c.String(),
                        MetodoPagamentoCR = c.String(),
                        HoraDeEntregaReembolso = c.String(),
                        LojaWortenReembolso = c.String(),
                        IBAN = c.String(),
                        Morada = c.String(),
                        CPostal = c.String(),
                    })
                .PrimaryKey(t => t.EntregaReembolsoID)
                .ForeignKey("dbo.ProdutoUtilizadors", t => t.EntregaReembolsoID)
                .Index(t => t.EntregaReembolsoID);
            
            CreateTable(
                "dbo.ProdutoUtilizadors",
                c => new
                    {
                        puID = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                        RazaoTrocaID = c.Int(),
                        TrocaSemelhanteID = c.Int(),
                        EspecificacaoTLMTABLETPUID = c.Int(),
                        TrocaDiferenteID = c.Int(),
                        EntregaReembolsoID = c.Int(),
                        Referência = c.Int(nullable: false),
                        nomeProdutoU = c.String(nullable: false),
                        DetalhesPU = c.String(),
                        DataDeCompra = c.DateTime(nullable: false),
                        DiasRestantes = c.Int(nullable: false),
                        LocalDeCompra = c.String(nullable: false),
                        EstadoDaTroca = c.String(),
                        Manual = c.String(),
                        Video1 = c.String(),
                        Video2 = c.String(),
                        ImagePath = c.String(),
                        RandomGeneratedNumber = c.String(),
                    })
                .PrimaryKey(t => t.puID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.EspecificacaoTLMTABLETPUs",
                c => new
                    {
                        EspecificacaoTLMTABLETPUID = c.Int(nullable: false),
                        Marca = c.String(),
                        Ecra = c.String(),
                        SistemaOperativo = c.String(),
                        TamanhoEcra = c.Double(nullable: false),
                        Processador = c.String(),
                        VelocidadeProcessador = c.String(),
                        Camara = c.Boolean(nullable: false),
                        ResCamara = c.String(),
                        CanaraSecundaria = c.Boolean(nullable: false),
                        ResCamaraSecundaria = c.String(),
                        MemoriaInterna = c.String(),
                        MemoriaExterna = c.Boolean(nullable: false),
                        Bateria = c.String(),
                        Bluetooth = c.Boolean(nullable: false),
                        GPS = c.Boolean(nullable: false),
                        WiFi = c.Boolean(nullable: false),
                        Acelerometro = c.Boolean(nullable: false),
                        Bussola = c.Boolean(nullable: false),
                        SensorProximidade = c.Boolean(nullable: false),
                        Cor = c.String(),
                        Peso = c.String(),
                        Altura = c.String(),
                        Largura = c.String(),
                        Rede = c.String(),
                        BloqueadoRede = c.Boolean(nullable: false),
                        BloqueRede = c.String(),
                        AudioJack = c.Boolean(nullable: false),
                        AudioJackType = c.String(),
                        CarregadorWireless = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EspecificacaoTLMTABLETPUID)
                .ForeignKey("dbo.ProdutoUtilizadors", t => t.EspecificacaoTLMTABLETPUID)
                .Index(t => t.EspecificacaoTLMTABLETPUID);
            
            CreateTable(
                "dbo.FileUtilizadors",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        ProdutoUtilizadorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.ProdutoUtilizadors", t => t.ProdutoUtilizadorID, cascadeDelete: true)
                .Index(t => t.ProdutoUtilizadorID);
            
            CreateTable(
                "dbo.RazaoTrocas",
                c => new
                    {
                        RazaoTrocaID = c.Int(nullable: false),
                        EntregaID = c.Int(),
                        MotivoAvaria = c.String(),
                        OutroMotivo = c.String(),
                    })
                .PrimaryKey(t => t.RazaoTrocaID)
                .ForeignKey("dbo.ProdutoUtilizadors", t => t.RazaoTrocaID)
                .Index(t => t.RazaoTrocaID);
            
            CreateTable(
                "dbo.Entregas",
                c => new
                    {
                        EntregaID = c.Int(nullable: false),
                        Morada = c.String(),
                        CPostal = c.String(),
                        Cidade = c.String(),
                        Pais = c.String(),
                        NTelemovel = c.String(),
                        ResumoTrocaID = c.Int(),
                        DataDoPedido = c.DateTime(nullable: false),
                        DataDaTrocaCasa = c.DateTime(),
                        DataDaTrocaLoja = c.DateTime(),
                        HoraDeEntrega = c.String(),
                        LojaWorten = c.String(),
                    })
                .PrimaryKey(t => t.EntregaID)
                .ForeignKey("dbo.RazaoTrocas", t => t.EntregaID)
                .Index(t => t.EntregaID);
            
            CreateTable(
                "dbo.ResumoTrocas",
                c => new
                    {
                        ResumoTrocaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResumoTrocaID)
                .ForeignKey("dbo.Entregas", t => t.ResumoTrocaID)
                .Index(t => t.ResumoTrocaID);
            
            CreateTable(
                "dbo.TrocaDiferentes",
                c => new
                    {
                        TrocaDiferenteID = c.Int(nullable: false),
                        ResumoTrocaDiferenteID = c.Int(),
                        DataDaTrocaLojaDiferente = c.DateTime(nullable: false),
                        HoraDeEntregaDiferente = c.String(),
                        LojaWortenDiferente = c.String(),
                        TipoTrocaDiferente = c.String(),
                    })
                .PrimaryKey(t => t.TrocaDiferenteID)
                .ForeignKey("dbo.ProdutoUtilizadors", t => t.TrocaDiferenteID)
                .Index(t => t.TrocaDiferenteID);
            
            CreateTable(
                "dbo.ResumoTrocaDiferentes",
                c => new
                    {
                        TrocaDiferenteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrocaDiferenteID)
                .ForeignKey("dbo.TrocaDiferentes", t => t.TrocaDiferenteID)
                .Index(t => t.TrocaDiferenteID);
            
            CreateTable(
                "dbo.TrocaSemelhantes",
                c => new
                    {
                        TrocaSemelhanteID = c.Int(nullable: false),
                        ResumoTrocaSemelhanteID = c.Int(),
                        DataDaTrocaLojaSemelhante = c.DateTime(nullable: false),
                        HoraDeEntregaSemelhante = c.String(),
                        LojaWortenSemelhante = c.String(),
                        TipoTrocaSemelhante = c.String(),
                    })
                .PrimaryKey(t => t.TrocaSemelhanteID)
                .ForeignKey("dbo.ProdutoUtilizadors", t => t.TrocaSemelhanteID)
                .Index(t => t.TrocaSemelhanteID);
            
            CreateTable(
                "dbo.ResumoTrocaSemelhantes",
                c => new
                    {
                        ResumoTrocaSemelhanteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResumoTrocaSemelhanteID)
                .ForeignKey("dbo.TrocaSemelhantes", t => t.ResumoTrocaSemelhanteID)
                .Index(t => t.ResumoTrocaSemelhanteID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        NResolve = c.String(),
                        Address = c.String(),
                        PostalCode = c.String(),
                        City = c.String(),
                        Name = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ResumoTrocaReembolsoes",
                c => new
                    {
                        EntregaReembolsoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EntregaReembolsoID)
                .ForeignKey("dbo.EntregaReembolsoes", t => t.EntregaReembolsoID)
                .Index(t => t.EntregaReembolsoID);
            
            CreateTable(
                "dbo.EspecificacaoTLMTABLETs",
                c => new
                    {
                        EspecificacaoTLMTABLETID = c.Int(nullable: false),
                        Marca = c.String(),
                        Ecra = c.String(),
                        SistemaOperativo = c.String(),
                        TamanhoEcra = c.Double(nullable: false),
                        Processador = c.String(),
                        VelocidadeProcessador = c.String(),
                        Camara = c.Boolean(nullable: false),
                        ResCamara = c.String(),
                        CanaraSecundaria = c.Boolean(nullable: false),
                        ResCamaraSecundaria = c.String(),
                        MemoriaInterna = c.String(),
                        MemoriaExterna = c.Boolean(nullable: false),
                        Bateria = c.String(),
                        Bluetooth = c.Boolean(nullable: false),
                        GPS = c.Boolean(nullable: false),
                        WiFi = c.Boolean(nullable: false),
                        Acelerometro = c.Boolean(nullable: false),
                        Bussola = c.Boolean(nullable: false),
                        SensorProximidade = c.Boolean(nullable: false),
                        Cor = c.String(),
                        Peso = c.String(),
                        Altura = c.String(),
                        Largura = c.String(),
                        Rede = c.String(),
                        BloqueadoRede = c.Boolean(nullable: false),
                        BloqueRede = c.String(),
                        AudioJack = c.Boolean(nullable: false),
                        AudioJackType = c.String(),
                        CarregadorWireless = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EspecificacaoTLMTABLETID)
                .ForeignKey("dbo.Produtoes", t => t.EspecificacaoTLMTABLETID)
                .Index(t => t.EspecificacaoTLMTABLETID);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        ProdutoID = c.Int(nullable: false, identity: true),
                        EspecificacaoTLMTABLETID = c.Int(),
                        NomeP = c.String(),
                        Referencia = c.Int(nullable: false),
                        Marca = c.String(),
                        Stock = c.Int(nullable: false),
                        TipoProduto = c.String(),
                        Price = c.Double(nullable: false),
                        Cor = c.String(),
                        MemoriaInterna = c.Int(nullable: false),
                        InformacaoBas = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.ProdutoID);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        ProdutoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoID, cascadeDelete: true)
                .Index(t => t.ProdutoID);
            
            CreateTable(
                "dbo.Lojas",
                c => new
                    {
                        LojaID = c.Int(nullable: false, identity: true),
                        Worten = c.String(nullable: false),
                        Morada = c.String(nullable: false),
                        latitude = c.Double(nullable: false),
                        longitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.LojaID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.EspecificacaoTLMTABLETs", "EspecificacaoTLMTABLETID", "dbo.Produtoes");
            DropForeignKey("dbo.Files", "ProdutoID", "dbo.Produtoes");
            DropForeignKey("dbo.ResumoTrocaReembolsoes", "EntregaReembolsoID", "dbo.EntregaReembolsoes");
            DropForeignKey("dbo.EntregaReembolsoes", "EntregaReembolsoID", "dbo.ProdutoUtilizadors");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProdutoUtilizadors", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ResumoTrocaSemelhantes", "ResumoTrocaSemelhanteID", "dbo.TrocaSemelhantes");
            DropForeignKey("dbo.TrocaSemelhantes", "TrocaSemelhanteID", "dbo.ProdutoUtilizadors");
            DropForeignKey("dbo.ResumoTrocaDiferentes", "TrocaDiferenteID", "dbo.TrocaDiferentes");
            DropForeignKey("dbo.TrocaDiferentes", "TrocaDiferenteID", "dbo.ProdutoUtilizadors");
            DropForeignKey("dbo.RazaoTrocas", "RazaoTrocaID", "dbo.ProdutoUtilizadors");
            DropForeignKey("dbo.ResumoTrocas", "ResumoTrocaID", "dbo.Entregas");
            DropForeignKey("dbo.Entregas", "EntregaID", "dbo.RazaoTrocas");
            DropForeignKey("dbo.FileUtilizadors", "ProdutoUtilizadorID", "dbo.ProdutoUtilizadors");
            DropForeignKey("dbo.EspecificacaoTLMTABLETPUs", "EspecificacaoTLMTABLETPUID", "dbo.ProdutoUtilizadors");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Files", new[] { "ProdutoID" });
            DropIndex("dbo.EspecificacaoTLMTABLETs", new[] { "EspecificacaoTLMTABLETID" });
            DropIndex("dbo.ResumoTrocaReembolsoes", new[] { "EntregaReembolsoID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.ResumoTrocaSemelhantes", new[] { "ResumoTrocaSemelhanteID" });
            DropIndex("dbo.TrocaSemelhantes", new[] { "TrocaSemelhanteID" });
            DropIndex("dbo.ResumoTrocaDiferentes", new[] { "TrocaDiferenteID" });
            DropIndex("dbo.TrocaDiferentes", new[] { "TrocaDiferenteID" });
            DropIndex("dbo.ResumoTrocas", new[] { "ResumoTrocaID" });
            DropIndex("dbo.Entregas", new[] { "EntregaID" });
            DropIndex("dbo.RazaoTrocas", new[] { "RazaoTrocaID" });
            DropIndex("dbo.FileUtilizadors", new[] { "ProdutoUtilizadorID" });
            DropIndex("dbo.EspecificacaoTLMTABLETPUs", new[] { "EspecificacaoTLMTABLETPUID" });
            DropIndex("dbo.ProdutoUtilizadors", new[] { "UserID" });
            DropIndex("dbo.EntregaReembolsoes", new[] { "EntregaReembolsoID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Lojas");
            DropTable("dbo.Files");
            DropTable("dbo.Produtoes");
            DropTable("dbo.EspecificacaoTLMTABLETs");
            DropTable("dbo.ResumoTrocaReembolsoes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ResumoTrocaSemelhantes");
            DropTable("dbo.TrocaSemelhantes");
            DropTable("dbo.ResumoTrocaDiferentes");
            DropTable("dbo.TrocaDiferentes");
            DropTable("dbo.ResumoTrocas");
            DropTable("dbo.Entregas");
            DropTable("dbo.RazaoTrocas");
            DropTable("dbo.FileUtilizadors");
            DropTable("dbo.EspecificacaoTLMTABLETPUs");
            DropTable("dbo.ProdutoUtilizadors");
            DropTable("dbo.EntregaReembolsoes");
        }
    }
}
