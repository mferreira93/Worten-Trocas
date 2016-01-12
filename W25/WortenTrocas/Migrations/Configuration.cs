namespace WortenTrocas.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WortenTrocas.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WortenTrocas.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WortenTrocas.Models.ApplicationDbContext context)
        {
            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);

            if (!context.Users.Any(t => t.NResolve == "00112233445566"))
            {
                var user = new User { UserName = "00112233445566", Email = "wortentrocas@gmail.com", NResolve = "00112233445566" };
                userManager.Create(user, "2015pimstt");


                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Admin" });
                context.SaveChanges();

                userManager.AddToRole(user.Id, "Admin");


            }

            var produtos = new List<Produto>
            {
               new Produto { NomeP = "iPad Air 2", Marca = "Apple", Referencia = 5428805, Stock = 5, TipoProduto = "Tablet APPLE", Price = 566, ImagePath ="../../Content/images/ipad_air_2.jpg", InformacaoBas = "iOS 8.1 / 16 GB / WIFI, 4G, BT / Dual-Core"},
               new Produto { NomeP = "iPad mini 3", Marca = "Apple", Referencia = 5428610, Stock = 2, TipoProduto = "Tablet APPLE", Price = 368, ImagePath ="../../Content/images/ipad_mini_silver.jpg", InformacaoBas = "iOS 8.1 / 16 GB / WIFI, BT / Dual-Core"},
               new Produto { NomeP = "iPhone 6", Marca = "Apple", Referencia = 5404099, Stock = 3, Cor ="Prateado", MemoriaInterna = 16,  TipoProduto = "Smartphone APPLE", Price = 700, ImagePath ="../../Content/images/iphone6_16gb.jpg", InformacaoBas = "iOS 8 / 4.7'' / 4G / Dual-core 1.4 GHz"},
               new Produto { NomeP = "iPhone 6", Marca = "Apple", Referencia = 5404096, Stock = 5, Cor ="Prateado", MemoriaInterna = 64,  TipoProduto = "Smartphone APPLE", Price = 800, ImagePath ="../../Content/images/iphone6_16gb.jpg", InformacaoBas = "iOS 8 / 4.7'' / 4G / Dual-core 1.4 GHz"},
               new Produto { NomeP = "Lumia 735", Marca = "Microsoft", Referencia = 5406756, Stock = 9, TipoProduto = "Smartphone MICROSOFT", Price = 200, ImagePath ="../../Content/images/lumia_735.jpg", InformacaoBas = "Windows Phone 8.1 / 4.7'' / 3G / Quad-core 1.2 GHz" },
               new Produto { NomeP = "Galaxy S6 Edge", Marca = "Samsung", Referencia = 5529053, Stock = 4, TipoProduto = "Smartphone SAMSUNG", Price = 950, ImagePath ="../../Content/images/galaxy_s6_edge_64gb.jpg", InformacaoBas = "Android 5.0 / 5.1’’ / 4G / Octa-core 2.1 GHz "},
               new Produto { NomeP = "G4", Marca = "LG", Referencia = 5554049, Stock = 1, Cor = "Vermelho", TipoProduto = "Smartphone LG", Price = 750, ImagePath ="../../Content/images/lg_g4.jpg", InformacaoBas = "Android 5.1 / 5.5'' / 4G / Quad-core 1.8 GHz"},
               new Produto { NomeP = "Pop C1 Kitty", Marca = "Alcatel", Referencia = 5490522, Stock = 6, TipoProduto = "Smartphone NOS", Price = 50, ImagePath ="../../Content/images/alcatel_pop_c1.jpg", InformacaoBas = "Android 4.2 / 3.5'' / 3G / Dual-core 1 GHz "},
               new Produto { NomeP = "Surface 2 RT", Marca = "Microsoft", Referencia = 5180748, Stock = 8, TipoProduto = "Tablet MICROSOFT", Price = 540, ImagePath ="../../Content/images/surface_2_Rt.jpg", InformacaoBas = "Windows RT 8.1 / 64 GB / WIFI / Quad-core 1.7 GHz "},
               new Produto { NomeP = "A1-830-25601G01", Marca = "Acer", Referencia = 5293927, Stock = 7, TipoProduto = "Tablet ACER", Price = 150, ImagePath ="../../Content/images/acer_a1_830_25601g01.jpg", InformacaoBas = "Android 4.2 / 16 GB / WIFI / Dual-Core 1.6 GHz"},
               new Produto { NomeP = "WT7-C-100", Marca = "Toshiba", Referencia = 5438305, Stock = 6, TipoProduto = "Tablet TOSHIBA", Price = 150, ImagePath ="../../Content/images/toshiba_wt7_c.jpg", InformacaoBas = "Windows 8.1 / 16 GB / WIFI / 2 GHz "},
            };
            produtos.ForEach(s => context.Produtoes.AddOrUpdate(p => p.Referencia, s));
            context.SaveChanges();


            var lojas = new List<Loja>
            {
               new Loja { Worten = "Amadora", Morada = "Estrada Nacional 249-1, Venteira 2724-520 Amadora", latitude = 38.7418500000, longitude = -9.23266700000},
               new Loja { Worten = "Cascais", Morada = "Estrada Nacional 9 2645-543 Alcabideche", latitude = 38.7392900000, longitude = -9.3959500000},
               new Loja { Worten = "Colombo", Morada = "Centro Comercial Colombo, Avenida Lusiada 1500-392 Lisboa", latitude = 38.7544850000, longitude = -9.1907230000},         
               new Loja { Worten = "Fórum Sintra", Morada = "IC 19 Alto do Forte 2635-018 Rio de Mouro", latitude = 38.7755180000, longitude = -9.3408450000},
               new Loja { Worten = "Loures", Morada = "Estrada Nacional 250, Quinta Casal da Pipa 2670-339 , Loures", latitude = 38.8185300000, longitude = -9.1757500000},
               new Loja { Worten = "Oeiras", Morada = "Avenida António Bernardo Cabral Macedo 2780-560 Oeiras", latitude = 38.7023240000, longitude = -9.2986180000},
               new Loja { Worten = "Seixal", Morada = "Rio Sul Shopping Qta. Nova do Judeu - Estrada Nacional 10 Fogueteiro 2840-293 Seixal", latitude = 38.6130650000, longitude = -9.1036640000},
               new Loja { Worten = "Telheiras", Morada = "Avenida das Nações Unidas, Telheiras 1600-528 Lisboa", latitude = 38.7646080000, longitude = -9.1753220000,},         
            };
            lojas.ForEach(s => context.Lojas.AddOrUpdate(p => p.Worten, s));
            context.SaveChanges();
        }
    }
}
