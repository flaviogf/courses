using CursoCSharpCoder.Api;
using CursoCSharpCoder.ClassesMetodos;
using CursoCSharpCoder.Colecoes;
using CursoCSharpCoder.EstruturasDeControle;
using CursoCSharpCoder.Excecoes;
using CursoCSharpCoder.Fundamentos;
using CursoCSharpCoder.MetodosFuncoes;
using CursoCSharpCoder.OO;
using CursoCSharpCoder.TopicosAvancados;

namespace CursoCSharpCoder
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var central = new CentralDeExercicios(
        typeof(PrimeiroPrograma),
        typeof(Comentarios),
        typeof(VariaveisConstantes),
        typeof(Inferencia),
        typeof(Interpolacao),
        typeof(NotacaoPonto),
        typeof(LendoDados),
        typeof(FormatandoNumero),
        typeof(Conversoes),
        typeof(OperadoresAritmeticos),
        typeof(OperadoresRelacionais),
        typeof(OperadoresLogicos),
        typeof(OperadoresAtribuicao),
        typeof(OperadoresUnarios),
        typeof(OperadorTernario),
        typeof(EstruturaIf),
        typeof(EstruturaIfElse),
        typeof(EstruturaIfElseIf),
        typeof(EstruturaWhile),
        typeof(EstruturaFor),
        typeof(EstruturaForEach),
        typeof(Membros),
        typeof(Construtores),
        typeof(MetodosComRetorno),
        typeof(MetodosEstaticos),
        typeof(AtributosEstaticos),
        typeof(Params),
        typeof(ParametrosNomeados),
        typeof(Propriedades),
        typeof(Readonly),
        typeof(ExemploEnum),
        typeof(ExemploStruct),
        typeof(StructVsClasse),
        typeof(ValorVsReferencia),
        typeof(ParametrosPorReferencia),
        typeof(ValorPadrao),
        typeof(ExemploArray),
        typeof(ExemploList),
        typeof(ExemploArrayList),
        typeof(ExemploSet),
        typeof(ExemploQueue),
        typeof(Igualdade),
        typeof(ExemploStack),
        typeof(ExemploDicionario),
        typeof(Heranca),
        typeof(ConstrutorThis),
        typeof(OO.Encapsulamento),
        typeof(Polimorfismo),
        typeof(ClasseAbstrata),
        typeof(ExemploInterface),
        typeof(Sealed),
        typeof(ExemploLambda),
        typeof(ExemploDelegate),
        typeof(FuncaoAnonima),
        typeof(DelegatesComoParametros),
        typeof(MetodosDeExtensao),
        typeof(PrimeiraExcecao),
        typeof(ExcecoesPersonalizadas),
        typeof(PrimeiroArquivo),
        typeof(LendoArquivos),
        typeof(ExemploFileInfo),
        typeof(Diretorios),
        typeof(ExemploDirectoryInfo),
        typeof(ExemploPath),
        typeof(ExemploDateTime),
        typeof(ExemploTimeSpan),
        typeof(LINQ1),
        typeof(LINQ2),
        typeof(Nullables),
        typeof(Dynamics),
        typeof(Genericos)
      );
      central.Inicializa();
    }
  }
}
