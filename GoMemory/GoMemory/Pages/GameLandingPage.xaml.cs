using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoMemory.Models;
using GoMemory.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoMemory.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GameLandingPage : ContentPage
	{
	    private GameLandingViewModel _gameLandingViewModel;
		public GameLandingPage (GameType gameType)
		{
			InitializeComponent ();
		    Title = gameType.Title;
		    BindingContext = _gameLandingViewModel = new GameLandingViewModel(gameType);

		}

	    private void ResumeBtn_OnClicked(object sender, EventArgs e)
	    {
	        throw new NotImplementedException();
	    }

	    private async Task StatsBtn_OnClickedAsync(object sender, EventArgs e)
	    {
	        await Navigation.PushAsync(new StatsPage(_gameLandingViewModel.GameType));
	    }

	    private async void RulesBtn_OnClicked(object sender, EventArgs e)
	    {
	        await Navigation.PushAsync(new RulesPage(_gameLandingViewModel.GameType)); 
	    }

	    private void Difficulty_OnClicked(object sender, EventArgs e)
	    {
	        throw new NotImplementedException();
	    }
	}
}