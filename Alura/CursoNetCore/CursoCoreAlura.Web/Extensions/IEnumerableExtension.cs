using System.Collections.Generic;
using System.Linq;

namespace CursoCoreAlura.Web.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool Vazio<T>(this IEnumerable<T> self)
        {
            return !self.Any();
        }

        public static bool NaoVazio<T>(this IEnumerable<T> self)
        {
            return !self.Vazio();
        }
    }
}
