using System.Threading.Tasks;

using Contatos.Domain.Entities;

namespace Contatos.Domain.Contracts.Repositories
{
    public interface IViaCepRepository
    {
        Task<Endereco> ObterEnderecoPorCEP(string cep);
    }
}