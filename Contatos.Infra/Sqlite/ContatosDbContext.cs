using Contatos.Infra.Sqlite.Models;

using Microsoft.EntityFrameworkCore;

namespace Contatos.Infra.Sqlite
{
    public class ContatosDbContext : DbContext
    {
        public ContatosDbContext(DbContextOptions<ContatosDbContext> options) : base(options)
        {
        }

        public DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Contato>().HasKey(m => m.ID);
            base.OnModelCreating(builder);
        }
    }
}