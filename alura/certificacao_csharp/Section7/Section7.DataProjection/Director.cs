using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Section7.DataProjection
{
    public class Director
    {
        public Director(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public static IList<Director> FindAll()
        {
            using (var reader = File.OpenText("Directors.json"))
            {
                return JsonConvert.DeserializeObject<List<Director>>(reader.ReadToEnd());
            }
        }

        public override string ToString() => $"Director=[Id={Id}, Name={Name}]";
    }
}