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
    public class AlterarContatoHandler : IRequestHandler<AlterarContatoRequest<HandlerResponse<Contato>>, HandlerResponse<Contato>>
    {
        private IContatosRepository ContatosRepository { get; set; }
        private IViaCepRepository ViaCepRepository { get; set; }

        public AlterarContatoHandler(IContatosRepository contatosRepository, IViaCepRepository viaCepRepository)
        {
            ContatosRepository = contatosRepository;
            ViaCepRepository = viaCepRepository;
        }

        public async Task<HandlerResponse<Contato>> Handle(AlterarContatoRequest<HandlerResponse<Contato>> request, CancellationToken cancellationToken)
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

            if (!string.IsNullOrEmpty(request?.Contato?.Endereco?.Cep))
            {
                var endereco = await ViaCepRepository.ObterEnderecoPorCEP(request.Contato.Endereco.Cep);

                if (!string.IsNullOrEmpty(endereco.Cep))
                {
                    request.Contato.Endereco.Cep = endereco.Cep;
                    request.Contato.Endereco.Bairro = endereco.Bairro;
                    request.Contato.Endereco.Logradouro = endereco.Logradouro;
                    request.Contato.Endereco.Cidade = endereco.Cidade;
                    request.Contato.Endereco.Estado = endereco.Estado;
                }
            }

            var contato = await ContatosRepository.Alterar(request.Contato);

            return new HandlerResponse<Contato>()
            {
                Sucesso = true,
                Resultado = contato
            };
        }
    }
}