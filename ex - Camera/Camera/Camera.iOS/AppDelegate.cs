using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace Camera.iOS {
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options) {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            var imagePicker = new UIImagePickerController { SourceType = UIImagePickerControllerSourceType.Camera };

            (Xamarin.Forms.Application.Current as App).CameraClickEvent += () =>
                UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(imagePicker, true, null);
            
            imagePicker.FinishedPickingMedia += (o, e) => {
                InvokeOnMainThread(() => {
                    using (var image = e.OriginalImage.AsPNG()) {
                        byte[] bytes = new byte[image.Length];
                        System.Runtime.InteropServices.Marshal.Copy(image.Bytes, bytes, 0, Convert.ToInt32(image.Length));
                        (Xamarin.Forms.Application.Current as App).OnPhoto(bytes);
                    }
                });
                UIApplication.SharedApplication.KeyWindow.RootViewController.DismissViewController(true, null);
            };

            imagePicker.Canceled += (o, e) =>
                UIApplication.SharedApplication.KeyWindow.RootViewController.DismissViewController(true, null);

            return base.FinishedLaunching(app, options);
        }
    }
}
