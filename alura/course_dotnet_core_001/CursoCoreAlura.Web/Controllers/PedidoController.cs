using CursoCoreAlura.Web.Models;
using CursoCoreAlura.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CursoCoreAlura.Web.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoController(IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository)
        {
            _produtoRepository = produtoRepository;
            _pedidoRepository = pedidoRepository;
        }

        public IActionResult Index()
        {
            return View(_produtoRepository.Lista());
        }

        public IActionResult Carrinho(string codigo)
        {
            var pedido = !string.IsNullOrEmpty(codigo)
                ? _pedidoRepository.Insere(codigo)
                : _pedidoRepository.Busca();

            return View(pedido);
        }

        public IActionResult Resumo()
        {
            return View(_pedidoRepository.Busca());
        }

        [HttpPost]
        public Pedido AtualizaItemPedido([FromBody] ItemPedido itemPedido)
        {
            return _pedidoRepository.Atualiza(itemPedido);
        }
    }
}
