using System;
using System.IO;
using AluraCar.Droid;
using AluraCar.Interface;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Plugin.CurrentActivity;

[assembly: Xamarin.Forms.Dependency(typeof(MainActivity))]
namespace AluraCar.Droid
{
    [Activity(Label = "AluraCar", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ICamera
    {
        private static Action<byte[]> _callback;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        public void TirarFoto(Action<byte[]> callback)
        {
            _callback = callback;
            var activity = CrossCurrentActivity.Current.Activity;
            var intent = new Intent(MediaStore.ActionImageCapture);
            activity.StartActivityForResult(intent, 1);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode != Result.Ok) return;
            var image = data.Extras.Get("data") as Bitmap;
            using (var stream = new MemoryStream())
            {
                image?.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);
                _callback(stream.ToArray());
            }
        }
    }
}
