using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Section7.GroupingAndAggregation
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public int Minutes { get; set; }

        public int DirectorId { get; set; }

        public async static Task<IList<Movie>> All()
        {
            using (var reader = File.OpenText("Movies.json"))
            {
                return JsonConvert.DeserializeObject<List<Movie>>(await reader.ReadToEndAsync());
            }
        }
    }
}