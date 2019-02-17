using System.Runtime.Serialization;

namespace casa_do_codigo_core.Models
{
    [DataContract]
    public class Produto
    {
        [DataMember]
        public int Id { get; private set; }

        [DataMember]
        public string Nome { get; private set; }

        [DataMember]
        public decimal Preco { get; private set; }

        public Produto()
        {

        }

        public Produto(string nome, decimal preco)
        {
            this.Nome = nome;
            this.Preco = preco;
        }

        public Produto(int id, string nome, decimal preco) : this(nome, preco)
        {
            this.Id = id;
        }
    }
}