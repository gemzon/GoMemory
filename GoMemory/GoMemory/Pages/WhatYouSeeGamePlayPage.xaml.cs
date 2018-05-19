using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoMemory.Enums;
using GoMemory.Models;
using GoMemory.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoMemory.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WhatYouSeeGamePlayPage : ContentPage
	{
	    readonly WhatYouSeeGamePlayViewModel _whatYouSeeGamePlayViewModel ;
	    private int GridSize;
		public WhatYouSeeGamePlayPage (Difficulty difficulty)
		{
			InitializeComponent ();
            _whatYouSeeGamePlayViewModel = new WhatYouSeeGamePlayViewModel(difficulty) ;
		  
		   
		}

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
	        CreateGrid();
	    }

	    private void CreateGrid()
	    {
	         GridSize = 0;
	        if (_whatYouSeeGamePlayViewModel.Difficulty == Difficulty.Easy)
	        {
	            GridSize = 4;
	        }
            if (_whatYouSeeGamePlayViewModel.Difficulty == Difficulty.Normal)
	        {
	            GridSize = 5;
	        }
	        if (_whatYouSeeGamePlayViewModel.Difficulty == Difficulty.Hard)
	        {
	            GridSize = 6;
	        }

            var grid =  new Grid();
	        for (int i = 0; i < GridSize; i++)
	        {
	            grid.ColumnDefinitions.Add(new ColumnDefinition{Width = new GridLength(1,GridUnitType.Star)});
                grid.RowDefinitions.Add(new RowDefinition{Height = new GridLength(1, GridUnitType.Star) });
	        }

	        AddGridImages(grid);
            PlayGrid = grid;
	    }

	    private void AddGridImages(Grid grid)
	    {
	        int imagecount = 0;
	        for (int row = 0; row < GridSize; row++)
	        {
	            for (int column = 0; column < GridSize; column++)
	            {
	                GameImage nextImage = _whatYouSeeGamePlayViewModel.PlayCollections.AllGameImages[imagecount];
                    Image image = new Image
                    {
                        

                        Source = nextImage.Location
                    };

	                Grid.SetRow(image, row);
                    Grid.SetColumn(image,column);
                    grid.Children.Add(image);
	                imagecount += 1;
	            }
	        }
	    }
	}
}