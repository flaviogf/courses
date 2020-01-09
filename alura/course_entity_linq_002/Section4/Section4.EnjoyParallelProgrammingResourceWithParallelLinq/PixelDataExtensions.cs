using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using ZXing.Rendering;

namespace Section4.EnjoyParallelProgrammingResourceWithParallelLinq
{
    public static class PixelDataExtensions
    {
        public static Bitmap ToBitmap(this PixelData target)
        {
            var bitmap = new Bitmap(target.Width, target.Height, PixelFormat.Format32bppArgb);

            bitmap.SetResolution(96, 96);

            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(target.Pixels, 0, bitmapData.Scan0, target.Pixels.Length);

            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }
    }
}
