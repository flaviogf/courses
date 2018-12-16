using System.Runtime.Serialization;

namespace casa_do_codigo_core.Models
{
    [DataContract]
    public class ItemCarrinho
    {
        [DataMember]
        public int Id { get; private set; }

        [DataMember]
        public int ProdutoId { get; private set; }

        [DataMember]
        public virtual Produto Produto { get; private set; }

        [DataMember]
        public int Quantidade { get; private set; }

        [DataMember]
        public decimal PrecoUnitario { get; private set; }

        [DataMember]
        public decimal SubTotal
        {
            get
            {
                return this.Quantidade * this.PrecoUnitario;
            }
        }

        public ItemCarrinho()
        {

        }

        public ItemCarrinho(Produto produto, int quantidade)
        {
            this.Produto = produto;
            this.Quantidade = quantidade;
            this.PrecoUnitario = this.Produto.Preco;
        }

        public ItemCarrinho(int id, Produto produto, int quantidade) : this(produto, quantidade)
        {
            this.Id = id;
        }

        public void AtualizarQuantidade(int quantidade) {
            this.Quantidade = quantidade;
        }
    }
}