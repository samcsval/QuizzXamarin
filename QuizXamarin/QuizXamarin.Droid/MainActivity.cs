
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android;
using Android.App;

namespace QuizXamarin.Droid
{
    [Activity(Label = "QuizXamarin", Icon = "@drawable/icon", Theme = "@style/MainTheme", 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            CheckAppPermissions();
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
        private void CheckAppPermissions()
        {
            if ((int)Build.VERSION.SdkInt < 23)
            {
                return;
            }
            else
            {
                if (PackageManager.CheckPermission(Manifest.Permission.ReadExternalStorage, PackageName) != Permission.Granted
                    && PackageManager.CheckPermission(Manifest.Permission.WriteExternalStorage, PackageName) != Permission.Granted)
                {
                    var permissions = new string[] { Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage };
                    RequestPermissions(permissions, 1);
                }
                if (PackageManager.CheckPermission(Manifest.Permission.AccessNetworkState, PackageName)
                    != Permission.Granted
                    && PackageManager.CheckPermission(Manifest.Permission.AccessWifiState, PackageName)
                    != Permission.Granted)
                {
                    var permissions = new string[] { Manifest.Permission.AccessNetworkState
                        , Manifest.Permission.AccessWifiState };
                    RequestPermissions(permissions, 1);
                }
            }
        }
    }
}

