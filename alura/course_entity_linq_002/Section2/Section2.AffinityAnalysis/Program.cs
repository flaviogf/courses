using System;
using System.Linq;

namespace Section2.AffinityAnalysis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var context = new Context();

            var trackName = "Smells Like Teen Spirit";

            var trackIds = from track in context.Tracks
                           where track.Name == trackName
                           select track.Id;

            var tracksBoughtToo = from bought in context.InvoiceItems
                                  join boughtToo in context.InvoiceItems
                                  on bought.Invoice.Id equals boughtToo.Invoice.Id
                                  where trackIds.Contains(bought.Track.Id)
                                  && bought.Track.Id != boughtToo.Track.Id
                                  select new
                                  {
                                      boughtToo.Track.Name
                                  };

            foreach (var item in tracksBoughtToo)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
