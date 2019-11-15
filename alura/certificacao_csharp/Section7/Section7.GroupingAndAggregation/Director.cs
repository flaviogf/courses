using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Section7.GroupingAndAggregation
{
    public class Director
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public async static Task<IList<Director>> All()
        {
            using (var reader = File.OpenText("Directors.json"))
            {
                return JsonConvert.DeserializeObject<List<Director>>(await reader.ReadToEndAsync());
            }
        }
    }
}