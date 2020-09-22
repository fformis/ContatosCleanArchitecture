using Contatos.Application.Handlers;

using Microsoft.Extensions.DependencyInjection;

namespace Contatos.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<AlterarContatoHandler, AlterarContatoHandler>();
            services.AddTransient<CriarContatoHandler, CriarContatoHandler>();
            services.AddTransient<ExcluirContatoHandler, ExcluirContatoHandler>();
            services.AddTransient<ListarContatoHandler, ListarContatoHandler>();
            services.AddTransient<ObterContatoHandler, ObterContatoHandler>();
            return services;
        }
    }
}