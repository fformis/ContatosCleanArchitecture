using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Contatos.Infra.Sqlite
{
    public class ContatosContextFactory : IDesignTimeDbContextFactory<ContatosDbContext>
    {
        public ContatosDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContatosDbContext>();
            optionsBuilder.UseSqlite("Data Source=Contatos.db");

            return new ContatosDbContext(optionsBuilder.Options);
        }
    }
}
