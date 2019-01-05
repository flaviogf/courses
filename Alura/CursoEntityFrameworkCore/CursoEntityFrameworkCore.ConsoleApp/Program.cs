using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CursoEntityFrameworkCore.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // GravaProduto();
            // ListaProdutos();
            // DeletaProdutos();
            // AtualizaProdutos();
            // EstadoModified();
            // EstadoAdded();
            // TestaProdutoRepository();
            // UmParaMuitos();
            // MuitoParaMuitos();
            // UmParaUm();
            using (var context = new LojaContext())
            {
                var promocao = context.Promocoes
                    .Include("Produtos.Produto")
                    .FirstOrDefault();

                foreach(var it in promocao.Produtos)
                {
                    Console.WriteLine(it.Produto);
                }
            }
        }

        private static void UmParaUm()
        {
            using (var context = new LojaContext())
            {
                var endereco = new Endereco() { Rua = "TesteR", Bairro = "TesteB", Numero = 10 };
                var cliente = new Cliente() { Nome = "TesteC", Endereco = endereco };
                context.Clientes.Add(cliente);
                ExibeEntries(context);
                context.SaveChanges();
            }
        }

        private static void MuitoParaMuitos()
        {
            using (var context = new LojaContext())
            {
                var promocao = new Promocao() { DataInicio = DateTime.Today, DataFim = DateTime.Today.AddDays(30) };
                var prod1 = new Produto() { Nome = "teste001", Categoria = "teste001", Preco = 100M, Unidade = "KG" };
                var prod2 = new Produto() { Nome = "teste002", Categoria = "teste002", Preco = 100M, Unidade = "KG" };
                promocao.Adiciona(prod1);
                promocao.Adiciona(prod2);
                context.Promocoes.Add(promocao);
                ExibeEntries(context);
                context.SaveChanges();
            }
        }

        public static void UmParaMuitos()
        {
            using (var context = new LojaContext())
            {
                var produto = new Produto { Nome = "Teste", Categoria = "Teste", Preco = 160M, Unidade = "KG" };
                var compra = new Compra { Preco = 1600M, Produto = produto, Quantidade = 100 };
                context.Compras.Add(compra);
                ExibeEntries(context);
                context.SaveChanges();
                ExibeEntries(context);
            }
        }

        private static void EstadoAdded()
        {
            using (var context = new LojaContext())
            {
                var produtos = context.Produtos.ToList();

                ExibeEntries(context);

                var produto = new Produto
                {
                    Nome = "Teste",
                    Categoria = "Teste",
                    Preco = 2000.0M
                };

                context.Produtos.Add(produto);
                ExibeEntries(context);

                context.SaveChanges();

                ExibeEntries(context);
            }
        }

        public static void ExibeEntries(LojaContext context)
        {
            Console.WriteLine("Entries".PadRight(100, '*'));
            context.ChangeTracker.Entries().Select(it => $"{it.Entity.ToString()} - {it.State.ToString()}").ToList().ForEach(Console.WriteLine);
        }

        public static void ExibeProdutos(List<Produto> produtos)
        {
            produtos.ForEach(Console.WriteLine);
        }

        private static void TestaProdutoRepository()
        {
            using (var context = new LojaContext())
            {
                IProdutoRepository repository = new ProdutoRepository(context);

                foreach (var it in repository.Lista())
                {
                    Console.WriteLine(it);
                }
            }
        }

        private static void EstadoModified()
        {
            using (var context = new LojaContext())
            {
                var produtos = context.Produtos.ToList();
                context.ChangeTracker.Entries().Select(it => it.State.ToString()).ToList().ForEach(Console.WriteLine);
                var produto1 = produtos.First();
                produto1.Nome = "Teste";
                context.ChangeTracker.Entries().Select(it => it.State.ToString()).ToList().ForEach(Console.WriteLine);
            }
        }

        private static void AtualizaProdutos()
        {
            using (var context = new LojaContext())
            {
                GravaProduto();
                ListaProdutos();
                var produto = context.Produtos.FirstOrDefault();
                produto.Nome = "Produto 001 - Atualizado";
                context.Update(produto);
                context.SaveChanges();
                ListaProdutos();
            }
        }

        private static void DeletaProdutos()
        {
            ListaProdutos();
            using (var context = new LojaContext())
            {
                context.RemoveRange(context.Produtos);
                context.SaveChanges();
            }
            ListaProdutos();
        }

        private static void ListaProdutos()
        {
            using (var context = new LojaContext())
            {
                Console.WriteLine($"Total Produtos {context.Produtos.Count()}");
                context.Produtos.Select(it => it.Nome).ToList().ForEach(Console.WriteLine);
            }
        }

        private static void GravaProduto()
        {
            using (var context = new LojaContext())
            {
                var produto1 = new Produto
                {
                    Nome = "Produto 001",
                    Categoria = "Categoria 001",
                    Preco = 2000.0M
                };

                context.Produtos.Add(produto1);

                context.SaveChanges();
            }
        }
    }
}
