namespace Contatos.Domain.Entities
{
    public class Contato
    {
        public long? Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }
    }
}