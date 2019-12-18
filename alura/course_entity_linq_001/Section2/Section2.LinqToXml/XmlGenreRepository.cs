using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Section2.LinqToXml
{
    public class XmlGenreRepository : IGenreRepository
    {
        public async Task<IEnumerable<Genre>> List()
        {
            var elements = XElement.Load(@"C:\Users\flavio\dev\courses\alura\course_entity_linq_001\Section2\Section2.LinqToXml\AluraTunes.xml");

            var genres = from genre in elements.Element("Genres").Elements("Genre")
                         select new Genre
                         (
                             id: int.Parse(genre.Element("Id").Value),
                             name: genre.Element("Name").Value
                         );

            return genres;
        }
    }
}
