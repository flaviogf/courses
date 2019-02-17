using System.Collections.Generic;
using System.Linq;

namespace casa_do_codigo_core.Models.ViewModels
{

    public class CarrinhoViewModel
    {
        public List<ItemCarrinho> Itens { get; private set; }
        public decimal Total
        {
            get
            {
                return this.Itens.Sum((item) => item.SubTotal);
            }
        }

        public CarrinhoViewModel(List<ItemCarrinho> itens)
        {
            this.Itens = itens;
        }
    }
}