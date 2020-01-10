using System;
using System.Linq;

namespace Section6.StudyAnalysisAndPlayWithQueriesThroughLinqPad
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var context = new Context();

            var rockTracks = from track in context.Tracks
                             where track.Genre.Name == "Rock"
                             select track;

            foreach (var track in rockTracks)
            {
                Console.WriteLine(track.Name);
            }
        }
    }
}
