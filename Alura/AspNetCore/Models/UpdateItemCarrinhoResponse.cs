using casa_do_codigo_core.Models.ViewModels;

namespace casa_do_codigo_core.Models
{
    
    public class UpdateItemCarrinhoResponse {

        public ItemCarrinho ItemCarrinho { get; set; }
        public CarrinhoViewModel CarrinhoViewModel { get; set; }

        public UpdateItemCarrinhoResponse(ItemCarrinho itemCarrinho, CarrinhoViewModel carrinhoViewModel) {
            this.ItemCarrinho = itemCarrinho;
            this.CarrinhoViewModel = carrinhoViewModel;
        }
    }
}