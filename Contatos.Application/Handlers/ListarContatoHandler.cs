using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Contatos.Application.Commom;
using Contatos.Application.Requests;
using Contatos.Domain.Contracts.Repositories;
using Contatos.Domain.Entities;

using MediatR;

namespace Contatos.Application.Handlers
{
    public class ListarContatoHandler : IRequestHandler<ListarContratoRequest<HandlerResponse<List<Contato>>>, HandlerResponse<List<Contato>>>
    {
        private IContatosRepository ContatosRepository { get; set; }

        public ListarContatoHandler(IContatosRepository contatosRepository)
        {
            ContatosRepository = contatosRepository;
        }

        public async Task<HandlerResponse<List<Contato>>> Handle(ListarContratoRequest<HandlerResponse<List<Contato>>> request, CancellationToken cancellationToken)
        {
            request.Validar();

            if (request.Invalid)
            {
                return new HandlerResponse<List<Contato>>()
                {
                    Sucesso = false,
                    Resultado = null,
                    Mensagens = request.Notifications.ToList()
                };
            }

            var contatos = await ContatosRepository.Listar();

            return new HandlerResponse<List<Contato>>()
            {
                Sucesso = true,
                Resultado = contatos
            };
        }
    }
}