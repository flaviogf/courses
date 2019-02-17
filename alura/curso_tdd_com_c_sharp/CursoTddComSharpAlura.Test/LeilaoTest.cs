using System;
using CursoTddComCSharpAlura.Domain;
using CursoTddComCSharpAlura.Test.Builders;
using NUnit.Framework;

namespace CursoTddComCSharpAlura.Test
{
    [TestFixture]
    public class LeilaoTest
    {
        private Produto _produto;
        private Usuario _flavio;
        private Usuario _fernando;
        private Usuario _fatima;
        private Usuario _luis;

        [SetUp]
        public void SetUp()
        {
            _produto = new Produto("Xbox One");
            _flavio = new Usuario("Flavio");
            _fernando = new Usuario("Fernando");
            _fatima = new Usuario("Fatima");
            _luis = new Usuario("Luis");
        }

        [Test]
        public void DeveRetornarOValorDoMaiorLanceQuandoOsLancesForemFeitosEmOrdemCrescente()
        {
            var leilao = new LeilaoBuilder(_produto)
                .Lance(_flavio, 2000.0M)
                .Lance(_fernando, 3000.0M)
                .Constroi();

            Assert.That(leilao.MaiorLance, Is.EqualTo(3000.0M));
        }

        [Test]
        public void DeveRetornarOValorDoMaiorLanceQuandoExisteSomenteUmLance()
        {
            var leilao = new LeilaoBuilder(_produto)
                .Lance(_flavio, 200)
                .Constroi();

            Assert.That(leilao.MaiorLance, Is.EqualTo(200));
        }

        [Test]
        public void DeveRetornarOsTresMaioresLancesQuandoOsLancesForemFeitosEmOrdemCrescente()
        {
            var leilao = new LeilaoBuilder(_produto)
                .Lance(_flavio, 2000.0M)
                .Lance(_fernando, 3000.0M)
                .Lance(_fatima, 5000.0M)
                .Lance(_luis, 4000.0M)
                .Constroi();

            Assert.That(leilao.TresMaioresLances.Count, Is.EqualTo(3));
            Assert.That(leilao.TresMaioresLances[0].Valor, Is.EqualTo(5000.0M));
            Assert.That(leilao.TresMaioresLances[1].Valor, Is.EqualTo(4000.0M));
            Assert.That(leilao.TresMaioresLances[2].Valor, Is.EqualTo(3000.0M));
        }

        [Test]
        public void NaoDevePermitirLancesMenoresOuIgualAZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var leilao = new LeilaoBuilder(_produto)
                    .Lance(_flavio, -10)
                    .Constroi();
            });
        }
    }
}
