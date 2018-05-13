using System;
using GoMemory.Pages;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace GoMemory
{
	public partial class App : Application
	{
	    public App()
	    {
	        InitializeComponent();

	        MainPage = new NavigationPage(new HomePage());
	    }


        public App(string dbPath)
		{
			InitializeComponent();

		    MainPage = new NavigationPage(new HomePage());
        }

		protected override void OnStart ()
		{
			AppCenter.Start("uwp=c70a0004-56b6-4dcb-ac0e-6f74e2e8c45b;" +
							"android=a0b6f86b-e646-4ea4-b299-f7b214714dca" +
							"ios=abc334f6-e1d1-4753-925d-7ddae5126e55",
				typeof(Analytics));
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
