using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace QuizXamarin.Droid
{
    [Activity(Label = "QuizXamarin.Droid", MainLauncher = true, Theme = "@style/Theme.Splash",
    NoHistory = true, ConfigurationChanges = ConfigChanges.ScreenSize, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            try
            {


                base.OnCreate(bundle);

                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);

            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long);
            }
        }
    }
}