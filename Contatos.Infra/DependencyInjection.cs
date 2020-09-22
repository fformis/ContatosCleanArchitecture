using Contatos.Domain.Contracts.Repositories;
using Contatos.Infra.Repositories;
using Contatos.Infra.Sqlite;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Contatos.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services)
        {
            services.AddDbContext<ContatosDbContext>(options =>
                options.UseSqlite("Data Source=Contatos.db")
            );
            services.AddTransient<IContatosRepository, ContatosRepository>();
            services.AddTransient<IViaCepRepository, ViaCepRepository>();
            return services;
        }
    }
}