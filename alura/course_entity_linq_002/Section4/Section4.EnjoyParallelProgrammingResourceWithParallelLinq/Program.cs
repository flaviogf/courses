using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;

namespace Section4.EnjoyParallelProgrammingResourceWithParallelLinq
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var context = new Context();

            var stopwatch = new Stopwatch();

            stopwatch.Start();

            var barcodeWriter = new BarcodeWriter<PixelData>();

            barcodeWriter.Renderer = new PixelDataRenderer();

            barcodeWriter.Options = new EncodingOptions
            {
                Height = 100,
                Width = 100
            };

            barcodeWriter.Format = BarcodeFormat.QR_CODE;

            var tracks = from track in context.Tracks.AsParallel() // Without AsParallel: 0.445 and with AsParallel: 0.005
                         select new
                         {
                             Filename = Path.Join("Images", $"{track.Id}.jpg"),
                             Bitmap = barcodeWriter.Write(track.Id.ToString()).ToBitmap()
                         };

            if (!Directory.Exists("Images")) Directory.CreateDirectory("Images");

            foreach (var qrcode in tracks)
            {
                qrcode.Bitmap.Save(qrcode.Filename, ImageFormat.Jpeg);
            }

            stopwatch.Stop();

            Console.WriteLine("It have passed {0:F3} seconds", stopwatch.Elapsed.TotalSeconds);
        }
    }
}
