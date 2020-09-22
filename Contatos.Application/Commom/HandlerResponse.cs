using System.Collections.Generic;

using Flunt.Notifications;

namespace Contatos.Application.Commom
{
    public class HandlerResponse<T>
    {
        public bool Sucesso { get; set; }

        public List<Notification> Mensagens { get; set; }

        public T Resultado { get; set; }
    }
}