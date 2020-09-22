using System;

using Contatos.Domain.Contracts.Requests;
using Contatos.Domain.Entities;

using Flunt.Notifications;

using MediatR;

namespace Contatos.Application.Requests
{
    public class CriarContatoRequest<T> : Notifiable, IRequestValidation, IRequest<T>
    {
        public CriarContatoRequest(Contato contato)
        {
            Contato = contato ?? throw new ArgumentNullException(nameof(contato));
        }

        public Contato Contato { get; private set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Contato.Nome))
            {
                AddNotification(nameof(Contato.Nome), $"A propriedade '{nameof(Contato.Nome)}' é obrigatória");
            }
            if (string.IsNullOrEmpty(Contato.Telefone))
            {
                AddNotification(nameof(Contato.Telefone), $"A propriedade '{nameof(Contato.Telefone)}' é obrigatória");
            }
            if (Contato.Endereco == null)
            {
                AddNotification(nameof(Contato.Endereco), $"A propriedade '{nameof(Contato.Endereco)}' é obrigatória");
            }
            else
            {
                if (string.IsNullOrEmpty(Contato.Endereco.Cep))
                {
                    AddNotification(nameof(Contato.Endereco.Cep), $"A propriedade '{nameof(Contato.Endereco.Cep)}' é obrigatória");
                }
            }
        }
    }
}