using AutoMapper;
using CursoAspNetMvc5Alura.Application.Intefaces;
using CursoAspNetMvc5Alura.Domain.Models;
using CursoAspNetMvc5Alura.Web.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CursoAspNetMvc5Alura.Web.Controllers
{
    public class ClienteController: Controller
    {
        private readonly IClienteApplication _application;

        public ClienteController(IClienteApplication application)
        {
            _application = application;
        }

        public ActionResult Index()
        {
            var clientes = Mapper.Map<IEnumerable<ClienteViewModel>>(_application.Lista());
            return View(clientes);
        }

        public ActionResult Cadastra()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Cadastra(ClienteViewModel cliente)
        {
            if(!ModelState.IsValid)
            {
                return View(cliente);
            }
            _application.Insere(Mapper.Map<Cliente>(cliente));
            return RedirectToAction("Index");
        }
    }
}
