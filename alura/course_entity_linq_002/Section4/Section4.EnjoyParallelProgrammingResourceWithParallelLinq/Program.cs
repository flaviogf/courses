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

            // 0.005 seconds
            var qrcodes = from track in context.Tracks.AsParallel() 
                         select new
                         {
                             Filename = Path.Join("Images", $"{track.Id}.jpg"),
                             Bitmap = barcodeWriter.Write(track.Id.ToString()).ToBitmap()
                         };

            // 0.445 seconds
            //var qrcodes = from track in context.Tracks
            //             select new
            //             {
            //                 Filename = Path.Join("Images", $"{track.Id}.jpg"),
            //                 Bitmap = barcodeWriter.Write(track.Id.ToString()).ToBitmap()
            //             };

            stopwatch.Stop();

            Console.WriteLine("Barcode.Write has delayed {0:F3} seconds", stopwatch.Elapsed.TotalSeconds);

            if (!Directory.Exists("Images")) Directory.CreateDirectory("Images");

            stopwatch.Restart();

            stopwatch.Start();

            // 6.856 seconds
            qrcodes.ForAll(it => it.Bitmap.Save(it.Filename, ImageFormat.Jpeg));

            // 18.031 seconds
            //foreach (var it in qrcodes)
            //{
            //    it.Bitmap.Save(it.Filename, ImageFormat.Jpeg);
            //}

            stopwatch.Stop();

            Console.WriteLine("Barcode.Save has delayed {0:F3} seconds", stopwatch.Elapsed.TotalSeconds);
        }
    }
}
