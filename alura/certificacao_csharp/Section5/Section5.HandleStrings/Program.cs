using System;
using System.Text;
using System.IO;

namespace Section5.HandleStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Portugues");
            stringBuilder.AppendLine("English");
            stringBuilder.AppendLine("French");
            var languages = stringBuilder.ToString();

            Console.WriteLine(languages);

            using (var stringWriter = new StringWriter())
            using (var stringReader = new StringReader(GetLongText()))
            {
                string line;

                while ((line = stringReader.ReadLine()) != null)
                {
                    stringWriter.WriteLine($"* {line}");
                }

                Console.WriteLine(stringWriter.ToString());
            }

        }

        static string GetLongText()
        {
            return @"
Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur vehicula quis lectus sed laoreet. Donec sollicitudin metus a blandit lacinia. Nunc eu nisi bibendum, pretium ex vitae, efficitur turpis. Vestibulum mattis efficitur consequat. Donec ac purus vitae sapien tincidunt ullamcorper. Suspendisse blandit egestas sem dictum aliquet. Duis vitae purus ac nibh iaculis sollicitudin. In facilisis urna id justo tempor scelerisque. Curabitur id ante fermentum lorem viverra condimentum.

Integer molestie, neque eu porttitor dignissim, velit ligula tristique metus, id fermentum leo est vel lacus. Suspendisse sollicitudin lacus eget imperdiet rhoncus. Morbi rhoncus bibendum est. Praesent eleifend turpis sit amet eros imperdiet, sit amet ullamcorper ante ullamcorper. Duis imperdiet vitae lacus a dapibus. Sed venenatis tellus vitae viverra aliquam. Nunc lobortis ante feugiat porta laoreet. Nam eget commodo nibh. Sed enim eros, commodo quis risus vel, rhoncus pharetra ante. Ut sollicitudin nec augue quis mollis. Pellentesque interdum purus ac quam maximus ornare. Vivamus dignissim quis tortor sit amet feugiat. Etiam odio nisi, suscipit quis pellentesque nec, varius vel dolor. Aenean in lorem eros. Sed lacinia lectus ac turpis dignissim pretium. Donec vitae efficitur turpis.

Vestibulum non blandit diam. Suspendisse eget tortor est. Duis euismod porttitor tincidunt. Suspendisse blandit nunc a justo vestibulum congue. Quisque auctor dui quis ante sodales tincidunt. Interdum et malesuada fames ac ante ipsum primis in faucibus. In id nunc nunc. Nam pulvinar metus felis, eget pretium justo eleifend vitae. Curabitur volutpat mattis erat vel iaculis. Praesent eleifend placerat eros eget imperdiet. Vestibulum posuere ligula at justo lobortis, id luctus enim tincidunt. Nam in felis eros. Aliquam ligula ante, consectetur sit amet massa quis, porta imperdiet sapien. Pellentesque vitae nibh volutpat, pellentesque ipsum sed, lacinia neque.

Phasellus vel pretium turpis. Sed laoreet eros non nisl maximus, eget pharetra dui pretium. Maecenas vitae condimentum magna. In hac habitasse platea dictumst. Integer vitae scelerisque est. Mauris vel erat malesuada, consequat libero sed, placerat augue. Nulla tincidunt sapien a finibus commodo. Ut vel purus orci. Donec sodales egestas tellus quis dignissim. Nam viverra, magna quis ultrices laoreet, urna diam aliquet enim, non finibus purus ante ac velit. Nulla dui magna, sollicitudin vitae finibus ac, hendrerit non purus. Nulla eget finibus neque. Suspendisse scelerisque ex mattis, porta velit in, faucibus libero. Cras at orci malesuada, porta massa sit amet, ultricies ligula. Etiam eget dignissim felis, at luctus nisl.

In finibus ornare arcu, sed sollicitudin diam luctus a. Integer lobortis diam elementum consequat maximus. Etiam blandit venenatis enim, nec consequat lacus accumsan vel. Fusce ullamcorper quam ac est laoreet, a molestie turpis lobortis. Praesent vestibulum finibus mattis. Integer ut justo dapibus, eleifend nulla sed, semper ante. Duis nisl lacus, rutrum vehicula ultricies a, ultrices vel ante.
            ";
        }
    }
}
