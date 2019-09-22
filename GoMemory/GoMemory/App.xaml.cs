using GoMemory.DataAccess;
using GoMemory.Interfaces;
using GoMemory.Models;
using GoMemory.Pages;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace GoMemory
{
    public partial class App : Application
    {
        public static IStatRepository StatRepository { get; private set; }

        public static IResumeRepository ResumeRepository { get; private set; }

        public  IList<DifficultySetting> DifficultySettings;


        public App(string dbPath)
        {
            InitializeComponent();
            StatRepository = new StatRepository(dbPath);
            ResumeRepository = new ResumeRepository(dbPath);
            DifficultySettings = SettingsData.SetDifficultyParmeters();
            MainPage = new NavigationPage(new HomePage());
        }

        protected override void OnStart()
        {
          
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
