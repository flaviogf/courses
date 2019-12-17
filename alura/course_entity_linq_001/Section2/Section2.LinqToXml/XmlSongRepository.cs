using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Linq;

namespace Section2.LinqToXml
{
    public class XmlSongRepository : ISongRepository
    {
        public async Task<IList<Song>> List()
        {
            var element = XElement.Load(@"C:\Users\flavio\dev\courses\alura\course_entity_linq_001\Section2\Section2.LinqToXml\AluraTunes.xml");

            var songs = from item in element.Element("Songs").Elements("Song")
                        orderby int.Parse(item.Element("Id").Value) ascending
                        select new Song
                        (
                            id: int.Parse(item.Element("Id").Value),
                            name: item.Element("Name").Value,
                            autor: item.Element("Autor").Value,
                            miliseconds: int.Parse(item.Element("Miliseconds").Value),
                            bytes: int.Parse(item.Element("Bytes").Value),
                            price: decimal.Parse(item.Element("Price").Value),
                            genreId: int.Parse(item.Element("GenreId").Value)
                        );

            return songs.ToList();
        }
    }
}
