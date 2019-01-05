using System.Collections.Generic;
using System.Linq;
using CursoCoreAlura.Web.Extensions;
using CursoCoreAlura.Web.Models;
using CursoCoreAlura.Web.Repositories;
using static Newtonsoft.Json.JsonConvert;
using static System.IO.File;
using static System.Console;

namespace CursoCoreAlura.Web.Infra
{
    public interface ISeedService
    {
        void Inicializa();
    }

    public class SeedService : ISeedService
    {
        private readonly IProdutoRepository _repository;

        public SeedService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public void Inicializa()
        {
            if (_repository.Lista().NaoVazio())
            {
                WriteLine("Seed ja inicializada");
                return;
            }

            InsereLivrosArquivoJson();
            WriteLine("Seed foi inicializada");
        }

        private void InsereLivrosArquivoJson()
        {
            var json = ReadAllText("livros.json");
            var livros = DeserializeObject<List<Livro>>(json);
            var produtos = livros.Select(l => new Produto {Codigo = l.Codigo, Nome = l.Nome, Preco = l.Preco});
            _repository.Insere(produtos);
        }
    }
}
