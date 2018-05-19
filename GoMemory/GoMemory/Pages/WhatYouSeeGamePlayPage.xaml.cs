using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
	    public Grid grid;
		public WhatYouSeeGamePlayPage (Difficulty difficulty)
		{
			InitializeComponent ();
            _whatYouSeeGamePlayViewModel = new WhatYouSeeGamePlayViewModel(difficulty) ;
		 
		   grid = new Grid();
            CreateGrid();
            Content = grid;
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

          

            for (int i = 0; i < GridSize; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }
 //grid.Children.Add(new Image
	//        {
	//            Source = ImageSource.FromResource(_whatYouSeeGamePlayViewModel.PlayCollections.AllImages[0].Path)
	//        }, 0, 0);
            AddGridImages();

        }

	    private void AddGridImages()
	    {





            int imagecount = 0;
            for (int row = 0; row < GridSize; row++)
            {
                for (int column = 0; column < GridSize; column++)
                {
                    grid.Children.Add(new Image
                    {
                        Source = ImageSource.FromResource(_whatYouSeeGamePlayViewModel.PlayCollections.AllImages[imagecount].Path)
                    }, row, column);

                    imagecount += 1;
                }
            }


        }
    }
}