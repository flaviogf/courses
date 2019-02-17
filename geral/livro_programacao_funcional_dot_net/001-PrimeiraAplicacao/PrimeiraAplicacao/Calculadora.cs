using System.Linq;

namespace PrimeiraAplicacao
{
    public class Calculadora
    {
        public int Quadrado(int numero)
        {
            return numero * numero;
        }

        public int SomaQuadradoDezPrimeirosNumeros()
        {
            return Enumerable.Range(1, 10).Select(Quadrado).Sum();
        }
    }
}
