using System.ComponentModel.DataAnnotations.Schema;

namespace Contatos.Infra.Sqlite.Models
{
    [Table("Contatos")]
    public class Contato
    {
        public long? ID { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
    }
}