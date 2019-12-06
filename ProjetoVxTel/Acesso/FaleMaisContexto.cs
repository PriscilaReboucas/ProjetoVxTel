using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ProjetoVxTel.Models;

namespace ProjetoVxTel.Acesso
{
    public class FaleMaisContexto : DbContext
    {
        public DbSet<Plano> Planos { get; set; }
        public DbSet<DDD> DDDs { get; set; }
        public DbSet<Chamada> Chamadas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // remove as pluralizações defaults que o entity atribui as tabelas.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //propriedades string terão no máximo 100 caracteres.
            modelBuilder.Properties<string>().Configure(c => c.HasMaxLength(100));
            
            modelBuilder.Entity<Chamada>()
            .HasOne(x => x.DDDOrigem)
            .WithOne()
            .HasForeignKey<Chamada>(p => p.CodigoDDDDestino);
            
            modelBuilder.Entity<Chamada>()
            .HasOne(x => x.DDDDestino)
            .WithOne()
            .HasForeignKey<Chamada>(p => p.CodigoDDDDestino);
            
        }
    }
}



