using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoMemory.Enums;
using GoMemory.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoMemory.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WhatYouSeeGamePlayPage : ContentPage
	{
	    readonly WhatYouSeeGamePlayViewModel _whatYouSeeGamePlayViewModel ;
		public WhatYouSeeGamePlayPage (Difficulty difficulty)
		{
			InitializeComponent ();
            _whatYouSeeGamePlayViewModel = new WhatYouSeeGamePlayViewModel(difficulty) ;
		    CreateGrid(_whatYouSeeGamePlayViewModel.Difficulty);
		}

	    private void CreateGrid(Difficulty difficulty)
	    {
	        int size = 0;
	        if (_whatYouSeeGamePlayViewModel.Difficulty == Difficulty.Easy)
	        {
	            size = 4;
	        }
            if (_whatYouSeeGamePlayViewModel.Difficulty == Difficulty.Normal)
	        {
	            size = 5;
	        }
	        if (_whatYouSeeGamePlayViewModel.Difficulty == Difficulty.Hard)
	        {
	            size = 6;
	        }

            var grid =  new Grid();
	        for (int i = 0; i < size; i++)
	        {
	            grid.ColumnDefinitions.Add(new ColumnDefinition{Width = new GridLength(1,GridUnitType.Star)});
                grid.RowDefinitions.Add(new RowDefinition{Height = new GridLength(1, GridUnitType.Star) });
	        }

	        PlayGrid = grid;

	    }
	}
}