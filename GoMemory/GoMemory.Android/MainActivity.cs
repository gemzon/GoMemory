using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using GoMemory.Droid.DataAccess;

namespace GoMemory.Droid
{
    [Activity(Label = "GoMemory", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            string dbPath = SqliteDbConnectionHelper.GetLocalDbPath("GoMemory.db3");
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(dbPath));
        }
    }
}

