using System;
using System.Linq;

namespace Section7.PaginationAndMethodSyntax
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            using (var context = new Context())
            {
                var reader = new PaginatedReader(perPage: 2, count: context.Users.Count());

                reader.PassedToNextPage += Print;

                reader.Read();
            }
        }

        public static void Print(object sender, PassedToNextPageEventArgs args)
        {
            Console.WriteLine($"Currente Page {args.Page}");

            using (var context = new Context())
            {
                var report = from user in context.Users.Skip(args.Skip).Take(args.Take)
                             join file in context.Files
                             on user.FileId equals file.Id
                             select new
                             {
                                 User = user.Name,
                                 File = file.Name
                             };

                foreach (var item in report)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}