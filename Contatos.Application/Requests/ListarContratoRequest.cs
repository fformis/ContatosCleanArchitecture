using Contatos.Domain.Contracts.Requests;

using Flunt.Notifications;

using MediatR;

namespace Contatos.Application.Requests
{
    public class ListarContratoRequest<T> : Notifiable, IRequestValidation, IRequest<T>
    {
        public void Validar()
        {
        }
    }
}