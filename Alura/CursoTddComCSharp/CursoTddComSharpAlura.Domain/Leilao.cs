using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CursoTddComCSharpAlura.Domain
{
    public class Leilao : IEnumerable<Lance>
    {
        private readonly IList<Lance> _lances = new List<Lance>();

        public Produto Produto { get; }

        public decimal MaiorLance => _lances.Max(it => it.Valor);

        public IList<Lance> TresMaioresLances => _lances.OrderByDescending(it => it.Valor).Take(3).ToList();

        public Leilao(Produto produto)
        {
            Produto = produto;
        }

        public void Propoe(Lance lance)
        {
            if (lance.Valor <= 0)
                throw new ArgumentException($"{nameof(lance.Valor)} não pode ser menor ou igual a zero", nameof(lance.Valor));

            _lances.Add(lance);
        }

        public void Add(Lance lance)
        {
            Propoe(lance);
        }

        public IEnumerator<Lance> GetEnumerator()
        {
            return _lances.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _lances.GetEnumerator();
        }
    }
}
