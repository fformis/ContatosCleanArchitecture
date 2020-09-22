using System.Net.Http;
using System.Threading.Tasks;

using Contatos.Domain.Contracts.Repositories;
using Contatos.Domain.Entities;

using Newtonsoft.Json;

namespace Contatos.Infra.Repositories
{
    public class ViaCepRepository : IViaCepRepository
    {
        public async Task<Endereco> ObterEnderecoPorCEP(string cep)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, $"https://viacep.com.br/ws/{cep.Replace("-", "")}/json/");
                var httpResponse = await httpClient.SendAsync(httpRequest);
                string content = await httpResponse.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<ViaCep.Models.Endereco>(content);

                return new Endereco()
                {
                    Cep = result.cep,
                    Logradouro = result.logradouro,
                    Bairro = result.bairro,
                    Cidade = result.localidade,
                    Estado = result.uf
                };
            }
            catch
            {
                return new Endereco();
            }
        }
    }
}