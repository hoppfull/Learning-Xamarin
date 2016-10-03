using System;
using System.IO;

using Android.App;
using Android.Graphics;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Content.PM;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Provider;
using Java.IO;
using Java.Nio;

namespace Camera.Droid {
    [Activity(Label = "Camera", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity {
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            Forms.Init(this, bundle);
            
            LoadApplication(new App());

            (Xamarin.Forms.Application.Current as App).CameraClickEvent += () => {
                Intent intent = new Intent(MediaStore.ActionImageCapture);
                StartActivityForResult(intent, 0);
            };
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent intent) {
            base.OnActivityResult(requestCode, resultCode, intent);
            if(requestCode == 0 && resultCode == Result.Ok) {
                Bitmap bmp = (Bitmap)intent.Extras.Get("data");
                byte[] bytes;
                using (var stream = new MemoryStream()) {
                    bmp.Compress(Bitmap.CompressFormat.Png, 100, stream);
                    bytes = stream.ToArray();
                }
                (Xamarin.Forms.Application.Current as App).OnPhoto(bytes);
            }
        }
    }
}

