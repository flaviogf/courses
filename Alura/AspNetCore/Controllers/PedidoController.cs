using Microsoft.AspNetCore.Mvc;
using casa_do_codigo_core.Models.ViewModels;
using casa_do_codigo_core.Models;

namespace casa_do_codigo_core.Controllers
{

    public class PedidoController : Controller
    {

        private readonly IDataService dataService;

        public PedidoController(IDataService dataService)
        {
            this.dataService = dataService;
        }

        public IActionResult Carrosel()
        {
            var produtos = this.dataService.GetProdutos();
            return View(produtos);
        }

        public IActionResult Resumo()
        {
            var viewModel = GetCarrinhoViewModel();
            return View(viewModel);
        }

        public IActionResult Carrinho(int? produtoId)
        {
            if(produtoId.HasValue) {
                this.dataService.AddItemCarrinho(produtoId.Value);
            }
            var viewModel = GetCarrinhoViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public UpdateItemCarrinhoResponse PostQuantidade([FromBody]ItemCarrinho item)
        {
            return this.dataService.UpdateItemCarrinho(item);
        }

        private CarrinhoViewModel GetCarrinhoViewModel()
        {
            var itensCarinho = this.dataService.GetItensCarrinho();
            return new CarrinhoViewModel(itensCarinho);
        }
    }
}