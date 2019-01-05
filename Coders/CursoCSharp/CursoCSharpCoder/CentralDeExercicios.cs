using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static System.Console;
using static System.ConsoleColor;
using System.Text.RegularExpressions;

namespace CursoCSharpCoder
{
  public class CentralDeExercicios
  {
    private IEnumerable<(MethodInfo, ExercicioAttribute)> exercicios;

    public CentralDeExercicios(params Type[] tipos)
    {
      this.exercicios = tipos.Where(MetodoAtributoEhValido).Select(SelecionaMetodoAtributo);
    }

    public void Inicializa()
    {
      try
      {
        ImprimeDisponiveis();
        EscolheExecuta();
      }
      catch (Exception ex)
      {
        BackgroundColor = Red;
        ForegroundColor = White;
        WriteLine("Ocorreu um erro");
        WriteLine(ex.Message);
        ResetColor();
      }
    }

    private void ImprimeDisponiveis()
    {
      WriteLine();
      WriteLine("Escolha um exercicio: ");
      foreach (var (_, atributo) in exercicios)
      {
        WriteLine(atributo);
      }
    }

    private void EscolheExecuta()
    {
      var (metodoExecutar, atributoExecutar) = exercicios.Last();
      if (int.TryParse(ReadLine(), out var escolha))
      {
        var (metodoEscolhido, atributoEscolhido) = exercicios.Where(e => e.Item2.Numero == escolha).FirstOrDefault();
        if (metodoEscolhido != null)
        {
          atributoExecutar = atributoEscolhido;
          metodoExecutar = metodoEscolhido;
        }
      }
      WriteLine();
      AlteraCorTerminal(Yellow, Black);
      WriteLine($"Executando exercicio: {atributoExecutar} - Capitulo: {PegaNomeCapitulo(metodoExecutar)}");
      WriteLine();
      ResetColor();
      metodoExecutar.Invoke(null, new object[] { });
      AlteraCorTerminal(Yellow, Black);
      WriteLine();
      WriteLine("Finalizado");
      ResetColor();
    }

    private void AlteraCorTerminal(ConsoleColor fundo, ConsoleColor texto)
    {
      BackgroundColor = fundo;
      ForegroundColor = texto;
    }

    private string PegaNomeCapitulo(MethodInfo metodoExecutar)
    {
      return new Regex(@"\.(?<capitulo>\w+)").Match(metodoExecutar.DeclaringType.Namespace).Groups["capitulo"].Value;
    }

    private bool MetodoAtributoEhValido(Type tipo)
    {
      var (metodo, atributo) = SelecionaMetodoAtributo(tipo);
      return metodo != null && atributo != null;
    }

    private(MethodInfo, ExercicioAttribute) SelecionaMetodoAtributo(Type tipo)
    {
      var metodo = tipo.GetMethods().LastOrDefault(m => m.IsPublic && m.IsStatic);
      var atributo = metodo.GetCustomAttribute(typeof(ExercicioAttribute)) as ExercicioAttribute;
      return (metodo, atributo);
    }
  }
}
