using Contatos.Domain.Contracts.Requests;

using Flunt.Notifications;

using MediatR;

namespace Contatos.Application.Requests
{
    public class ExcluirContatoRequest<T> : Notifiable, IRequestValidation, IRequest<T>
    {
        public ExcluirContatoRequest(long id)
        {
            Id = id;
        }

        public long Id { get; set; }

        public void Validar()
        {
            if (Id <= 0)
            {
                AddNotification(nameof(Id), $"A propriedade '{nameof(Id)}' é obrigatória");
            }
        }
    }
}