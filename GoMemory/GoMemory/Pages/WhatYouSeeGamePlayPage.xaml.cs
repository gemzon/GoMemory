using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GoMemory.Enums;
using GoMemory.Helpers;
using GoMemory.Models;
using GoMemory.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoMemory.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WhatYouSeeGamePlayPage : ContentPage
    {
        readonly WhatYouSeeGamePlayViewModel _whatYouSeeGamePlayViewModel;
      
        public Grid Grid;
      

        public WhatYouSeeGamePlayPage(Difficulty difficulty)
        {
            InitializeComponent();
            Title = "What you see";
            _whatYouSeeGamePlayViewModel = new WhatYouSeeGamePlayViewModel(difficulty);
            CreatePageContent();
            Grid = _whatYouSeeGamePlayViewModel.SetMemoriseGrid(Grid);
        }

        /// <summary>
        /// Create the initial layout of the page
        /// </summary>
        private void CreatePageContent()
        {
            StackLayout.IsVisible= true;
            Failed.IsVisible = false;
            LevelLabel.Text =  _whatYouSeeGamePlayViewModel.SetLevelText();
            
            NewGrid();
            Grid = _whatYouSeeGamePlayViewModel.AddGridImages(Grid);
            Grid.MinimumWidthRequest = Application.Current.MainPage.Width * 0.5;
            Grid.MinimumWidthRequest = Application.Current.MainPage.Height * 0.6;

            StackLayout.Children.Add(Grid);

        }

      
      

        /// <summary>
        /// Create image grid 
        /// </summary>
        private void NewGrid()
        {
            Grid = _whatYouSeeGamePlayViewModel.CreateNewGrid(Grid);
        }

      /// <summary>
      /// Add Tap gesture for the Grid Images
      /// </summary>
        public void AddTapGestures()
        {
            foreach (var view in Grid.Children)
            {
                Image image = view as Image;
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += OnTapped;
                image.GestureRecognizers.Add(tapGestureRecognizer);
            }
           
        }

        /// <summary>
        /// When player is ready to recall images 
        /// coordinates the start of the guessing  phase
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void StartButton_OnClicked(object sender, EventArgs eventArgs)
        {
            Button s = sender as Button;
            s.IsEnabled = false;
       //     Grid =   _whatYouSeeGamePlayViewModel.ReShuffle(Grid);
            AddTapGestures();
        }

        /// <summary>
        /// Handles the tapping of a image once guessing phase has started
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ev"></param>
        private void OnTapped(object sender,EventArgs ev)
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;
            bool found;
            try
            {
                Image img = sender as Image;
                found = _whatYouSeeGamePlayViewModel.CheckSelections(img);
                if (found)
                {
                    if (img != null)
                    {
                        img.Opacity = 0.5;
                        img.IsEnabled = false;
                    }
                }
                else
                {
                    StackLayout.IsVisible = false;
                    Failed.IsVisible = true;
                }

                if (_whatYouSeeGamePlayViewModel.CheckIsRoundComplete())
                {
                    NextRound();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                IsBusy = false;
            }

        }


        /// <summary>
        /// Intiates next Level of play or signals game completed 
        /// 
        /// </summary>
        public void NextRound()
        {
            bool next;
            next = _whatYouSeeGamePlayViewModel.NextRound();
            if (next)
            {
                StartButton.IsEnabled = true;
                Grid = _whatYouSeeGamePlayViewModel.ToggleImageClickable(Grid,false);
                LevelLabel.Text =  _whatYouSeeGamePlayViewModel.SetLevelText();
                 Grid =  _whatYouSeeGamePlayViewModel.SetMemoriseGrid(Grid);
            }
            else
            {
                StackLayout.IsVisible = false;
                Failed.IsVisible = false;
                Complete.IsVisible = true;
             
            }
           
        }
        

        /// <summary>
        /// Sets Game play to retry the current level
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void RetryButton_Clicked(object sender, EventArgs eventArgs)
        {
            _whatYouSeeGamePlayViewModel.Retry();
            NextRound();
            StackLayout.IsVisible = true;
            Failed.IsVisible = false;
        }


    }
}