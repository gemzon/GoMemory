using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoMemory.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GameLandingPage : ContentPage
	{
		public GameLandingPage ()
		{
			InitializeComponent ();
		    Title = "Complex Color";

		}

	    private void ResumeBtn_OnClicked(object sender, EventArgs e)
	    {
	        throw new NotImplementedException();
	    }

	    private void StatsBtn_OnClicked(object sender, EventArgs e)
	    {
	        throw new NotImplementedException();
	    }

	    private void RulesBtn_OnClicked(object sender, EventArgs e)
	    {
	        throw new NotImplementedException();
	    }

	    private void Difficulty_OnClicked(object sender, EventArgs e)
	    {
	        throw new NotImplementedException();
	    }
	}
}