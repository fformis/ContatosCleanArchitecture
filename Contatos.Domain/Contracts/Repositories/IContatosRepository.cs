using System.Collections.Generic;
using System.Threading.Tasks;

using Contatos.Domain.Entities;

namespace Contatos.Domain.Contracts.Repositories
{
    public interface IContatosRepository
    {
        Task<Contato> Inserir(Contato contato);

        Task<Contato> Alterar(Contato contato);

        Task Excluir(long id);

        Task<Contato> Obter(long id);

        Task<List<Contato>> Listar();
    }
}