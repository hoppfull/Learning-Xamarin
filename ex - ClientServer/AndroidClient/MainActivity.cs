using System;
using System.Net.Http;
using Android.App;
using Android.Widget;
using Android.OS;

namespace AndroidClient {
    [Activity(Label = "AndroidClient", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity {
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            Button btn_GetData =
                FindViewById<Button>(Resource.Id.btn_GetData);

            EditText etx_ServerAdress =
                FindViewById<EditText>(Resource.Id.etx_ServerAdress);

            TextView tvw_ServerMessage =
                FindViewById<TextView>(Resource.Id.tvw_ServerMessage);

            btn_GetData.Click += (o, e) => {
                try {
                    string serverAddress = string.Format($"http://{etx_ServerAdress.Text}:8000/");
                    HttpClient client = new HttpClient { BaseAddress = new Uri(serverAddress) };

                    HttpResponseMessage res = client.GetAsync("/myget").Result;

                    string responseMsg = res.Content.ReadAsStringAsync().Result;

                    tvw_ServerMessage.Text = responseMsg;
                } catch (Exception) {
                    tvw_ServerMessage.Text = "Error";
                }
            };
        }
    }
}
