using Android.App;
using Android.OS;

namespace Android_Fragment {
    [Activity(Label = "Android_Fragment", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity {
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            FragmentTransaction ft = FragmentManager.BeginTransaction();
            ft.Replace(Resource.Id.frm_MyFrame, new MyFragment());
            ft.Commit();
        }
    }
}
