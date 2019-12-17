using System.Collections.Generic;
using System.Threading.Tasks;

namespace Section2.LinqToXml
{
    public interface ISongRepository
    {
        Task<IList<Song>> List();
    }
}
