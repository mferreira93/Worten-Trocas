using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WortenTrocas.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        public string NResolve { get; set; }

        public string Address { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ProdutoUtilizador> ProdutosUtilizadores { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<WortenTrocas.Models.Produto> Produtoes { get; set; }

        public DbSet<File> Files { get; set; }

        public System.Data.Entity.DbSet<WortenTrocas.Models.FileUtilizador> FileUtilizadors { get; set; }

        public System.Data.Entity.DbSet<WortenTrocas.Models.Loja> Lojas { get; set; }

        public System.Data.Entity.DbSet<WortenTrocas.Models.ProdutoUtilizador> ProdutoUtilizadors { get; set; }

        public System.Data.Entity.DbSet<WortenTrocas.Models.Entrega> Entregas { get; set; }

        public System.Data.Entity.DbSet<WortenTrocas.Models.ResumoTroca> ResumoTrocas { get; set; }

        public System.Data.Entity.DbSet<WortenTrocas.Models.EspecificacaoTLMTABLET> EspecificacaoTLMTABLETs { get; set; }

        public System.Data.Entity.DbSet<WortenTrocas.Models.RazaoTroca> RazaoTrocas { get; set; }

        public System.Data.Entity.DbSet<WortenTrocas.Models.EspecificacaoTLMTABLETPU> EspecificacaoTLMTABLETPUs { get; set; }

        public System.Data.Entity.DbSet<WortenTrocas.Models.TrocaDiferente> TrocaDiferentes { get; set; }

        public System.Data.Entity.DbSet<WortenTrocas.Models.ResumoTrocaDiferente> ResumoTrocaDiferentes { get; set; }

        public System.Data.Entity.DbSet<WortenTrocas.Models.TrocaSemelhante> TrocaSemelhantes { get; set; }

        public System.Data.Entity.DbSet<WortenTrocas.Models.ResumoTrocaSemelhante> ResumoTrocaSemelhantes { get; set; }

        public System.Data.Entity.DbSet<WortenTrocas.Models.EntregaReembolso> EntregaReembolsoes { get; set; }

        public System.Data.Entity.DbSet<WortenTrocas.Models.ResumoTrocaReembolso> ResumoTrocaReembolsoes { get; set; }
    }
}