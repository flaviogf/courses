namespace Section2.LinqToXml
{
    public class Song
    {
        public Song(int id, string name, string autor, int miliseconds, int bytes, decimal price, int genreId)
        {
            Id = id;
            Name = name;
            Autor = autor;
            Miliseconds = miliseconds;
            Bytes = bytes;
            Price = price;
            GenreId = genreId;
        }

        public int Id { get; private set; }

        public string Name { get; set; }

        public string Autor { get; set; }

        public int Miliseconds { get; set; }

        public int Bytes { get; set; }

        public decimal Price { get; set; }

        public int GenreId { get; set; }
    }
}
