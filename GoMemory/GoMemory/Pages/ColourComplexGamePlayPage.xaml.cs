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
	public partial class ColourComplexGamePlayPage : ContentPage
	{
	    readonly ColourComplexGamePlayViewModel _colourComplexGamePlayViewModel;
	    public ColourComplexGamePlayPage(Difficulty difficulty)
	    {
	        InitializeComponent();
	        Title = "ComplexColour";
            _colourComplexGamePlayViewModel = new ColourComplexGamePlayViewModel(difficulty);
GuessLayout();
	        NextRound();
            

	    }

	    /// <summary>
	    /// intiate the visibility of elemetns and 
	    /// changes the page content
	    /// </summary>
	    public void NextRound()
	    {
	        bool next;
	        next = _colourComplexGamePlayViewModel.NextRound();
	        if (next)
	        {

	            //StackLayout.IsVisible = true;
	            //PlayLayout.IsVisible = false;
	            //Failed.IsVisible = false;
	            SequenceStackLayout = _colourComplexGamePlayViewModel.PopulateSequencStackLayout(SequenceStackLayout);
	            LevelLabel.Text = _colourComplexGamePlayViewModel.SetLevelText();
	            Content = StackLayout;
	        }
	        else
	        {
	            DifficultyCompleted();
	        }


	    }

	    /// <summary>
	    /// Make visible to difficuly completeImage
	    /// </summary>
	    private void DifficultyCompleted()
	    {
	        Complete.IsVisible = true;
	    }

        /// <summary>
        /// Trigger the trigger the visiblity of view and chgange to 
        /// pages content assignmnet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartButton_OnClicked(object sender, EventArgs e)
	    {

	        SequenceStackLayout.Children.Clear();
	      
	        StackLayout.IsVisible = false;
	        PlayLayout.IsVisible = true;

	        Content = PlayLayout;

	    }

	    private void GuessLayout()
	    {
	        Grid = _colourComplexGamePlayViewModel.GenerateGrid();
	        WidthRequest = Application.Current.MainPage.Width - 10;
	        HeightRequest = Application.Current.MainPage.Height * 0.6;
	        Frame.WidthRequest = Application.Current.MainPage.Width * 0.7;
	        Frame.HeightRequest = Application.Current.MainPage.Height * 0.1;
	        Grid.WidthRequest = Application.Current.MainPage.Width * 0.5;
	        Grid.HeightRequest = Application.Current.MainPage.Height * 0.6;

	        PlayLayout.Children.Add(Grid);
	    

	    }



        /// <summary>
        /// Reinitialize the game round after a bad choice made
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RetryButton_Clicked(object sender, EventArgs e)
	    {
	        _colourComplexGamePlayViewModel.Retry();
	        StackLayout.IsVisible = true;
	        Failed.IsVisible = false;
	        PlayLayout.IsVisible = false;
	        Content = StackLayout;

	     //   NextRound();
	    }
    }
}