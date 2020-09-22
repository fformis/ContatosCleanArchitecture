using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Contatos.Domain.Contracts.Repositories;
using Contatos.Infra.Sqlite;
using Contatos.Infra.Sqlite.Models;

namespace Contatos.Infra.Repositories
{
    public class ContatosRepository : IContatosRepository
    {
        public ContatosRepository(ContatosDbContext contatosDbContext)
        {
            DbContext = contatosDbContext;
        }

        private ContatosDbContext DbContext { get; set; }

        public async Task<Domain.Entities.Contato> Alterar(Domain.Entities.Contato contato)
        {
            var t = new Task<Domain.Entities.Contato>(() =>
            {
                Contato contatoModel = new Contato()
                {
                    ID = contato.Id,
                    Nome = contato.Nome,
                    Telefone = contato.Telefone,
                    Bairro = contato.Endereco.Bairro,
                    Cep = contato.Endereco.Cep,
                    Cidade = contato.Endereco.Cidade,
                    Complemento = contato.Endereco.Complemento,
                    Estado = contato.Endereco.Estado,
                    Logradouro = contato.Endereco.Logradouro,
                    Numero = contato.Endereco.Numero
                };

                DbContext.Contatos.Update(contatoModel);
                DbContext.SaveChanges();
                return contato;
            });
            t.Start();
            return await t;
        }

        public async Task Excluir(long id)
        {
            var t = new Task(() =>
            {
                var contato = DbContext.Contatos.Remove(DbContext.Contatos.Where(x => x.ID == id).FirstOrDefault());
                DbContext.SaveChanges();
            });
            t.Start();
            await t;
        }

        public async Task<Domain.Entities.Contato> Inserir(Domain.Entities.Contato contato)
        {
            var t = new Task<Domain.Entities.Contato>(() =>
            {
                Contato contatoModel = new Contato()
                {
                    Nome = contato.Nome,
                    Telefone = contato.Telefone,
                    Bairro = contato.Endereco.Bairro,
                    Cep = contato.Endereco.Cep,
                    Cidade = contato.Endereco.Cidade,
                    Complemento = contato.Endereco.Complemento,
                    Estado = contato.Endereco.Estado,
                    Logradouro = contato.Endereco.Logradouro,
                    Numero = contato.Endereco.Numero
                };

                DbContext.Contatos.Add(contatoModel);
                DbContext.SaveChanges();
                contato.Id = contatoModel.ID;
                return contato;
            });
            t.Start();
            return await t;
        }

        public async Task<List<Domain.Entities.Contato>> Listar()
        {
            var t = new Task<List<Domain.Entities.Contato>>(() =>
            {
                return (from x in DbContext.Contatos
                        select new Domain.Entities.Contato()
                        {
                            Id = x.ID,
                            Nome = x.Nome,
                            Telefone = x.Telefone,
                            Endereco = new Domain.Entities.Endereco()
                            {
                                Bairro = x.Bairro,
                                Cep = x.Cep,
                                Cidade = x.Cidade,
                                Complemento = x.Complemento,
                                Estado = x.Estado,
                                Logradouro = x.Logradouro,
                                Numero = x.Numero
                            }
                        }).ToList();
            });
            t.Start();
            return await t;
        }

        public async Task<Domain.Entities.Contato> Obter(long id)
        {
            var t = new Task<Domain.Entities.Contato>(() =>
            {
                return (from x in DbContext.Contatos
                        where x.ID == id
                        select new Domain.Entities.Contato()
                        {
                            Id = x.ID,
                            Nome = x.Nome,
                            Telefone = x.Telefone,
                            Endereco = new Domain.Entities.Endereco()
                            {
                                Bairro = x.Bairro,
                                Cep = x.Cep,
                                Cidade = x.Cidade,
                                Complemento = x.Complemento,
                                Estado = x.Estado,
                                Logradouro = x.Logradouro,
                                Numero = x.Numero
                            }
                        }).FirstOrDefault();
            });
            t.Start();
            return await t;
        }
    }
}