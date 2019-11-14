using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Section7.DataProjection
{
    public class Movie
    {
        public Movie(int id, string title, int year, int directorId)
        {
            Id = id;
            Title = title;
            Year = year;
            DirectorId = directorId;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public int DirectorId { get; set; }

        public static IList<Movie> FindAll()
        {
            using (var reader = File.OpenText("Movies.json"))
            {
                return JsonConvert.DeserializeObject<List<Movie>>(reader.ReadToEnd());
            }
        }

        public override string ToString() => $"Movie[Id={Id}, Title={Title}, Year={Year}, DirectorId={DirectorId}]";
    }
}