using CursoTddComCSharpAlura.Domain;

namespace CursoTddComCSharpAlura.Test.Builders
{
    public class LeilaoBuilder
    {
        private readonly Leilao _leilao;

        public LeilaoBuilder(Produto produto)
        {
            _leilao = new Leilao(produto);
        }

        public LeilaoBuilder Lance(Usuario usuario, decimal valor)
        {
            _leilao.Propoe(new Lance(usuario, valor));
            return this;
        }

        public Leilao Constroi()
        {
            return _leilao;
        }
    }
}
