using System;
using System.IO;

using Xamarin.Forms;

namespace Camera {
    public class App : Application {
        public event Action CameraClickEvent = () => { };
        private Image img = new Image();
        public App() {
            Button btn = new Button {
                Text = "Take picture!",
                Command = new Command(_ => CameraClickEvent())
            };
            // The root page of your application
            MainPage = new ContentPage {
                Content = new StackLayout {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        btn,
                        img
                    }
                }
            };
        }

        public void OnPhoto(byte[] bytes) {
            img.Source = ImageSource.FromStream(() => new MemoryStream(bytes));
        }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}
