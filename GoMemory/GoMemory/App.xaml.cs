using GoMemory.DataAccess;
using GoMemory.Interfaces;
using GoMemory.Pages;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace GoMemory
{
    public partial class App : Application
    {
        public static IStatRepository StatRepository { get; private set; }

        public static IResumeRepository ResumeRepository { get; private set; }




        public App(string dbPath)
        {
            InitializeComponent();
            StatRepository = new StatRepository(dbPath);
            ResumeRepository = new ResumeRepository(dbPath);
            MainPage = new NavigationPage(new HomePage());
        }

        protected override void OnStart()
        {
            AppCenter.Start("uwp=" +
                            "android=" +
                            "ios=",
                typeof(Analytics));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {

        }
    }
}
