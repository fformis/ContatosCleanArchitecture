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
    public class ObterContatoHandler : IRequestHandler<ObterContatoRequest<HandlerResponse<Contato>>, HandlerResponse<Contato>>
    {
        private IContatosRepository ContatosRepository { get; set; }

        public ObterContatoHandler(IContatosRepository contatosRepository)
        {
            ContatosRepository = contatosRepository;
        }

        public async Task<HandlerResponse<Contato>> Handle(ObterContatoRequest<HandlerResponse<Contato>> request, CancellationToken cancellationToken)
        {
            request.Validar();

            if (request.Invalid)
            {
                return new HandlerResponse<Contato>()
                {
                    Sucesso = false,
                    Resultado = null,
                    Mensagens = request.Notifications.ToList()
                };
            }

            var contato = await ContatosRepository.Obter(request.Id);

            return new HandlerResponse<Contato>()
            {
                Sucesso = true,
                Resultado = contato
            };
        }
    }
}