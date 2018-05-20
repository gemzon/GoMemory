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
       // private int _gridSize;
        public Grid Grid;
        public StackLayout StackLayout;
        public Button StartButton;
        public Label LevelLabel;
       // public Label MessageLabel;
      

        public WhatYouSeeGamePlayPage(Difficulty difficulty)
        {
            InitializeComponent();
           
            _whatYouSeeGamePlayViewModel = new WhatYouSeeGamePlayViewModel(difficulty);
            CreatePageContent();
            Content = StackLayout;
            Grid = _whatYouSeeGamePlayViewModel.SetMemoriseGrid(Grid);
        }

        /// <summary>
        /// Create the initial layout of the page
        /// </summary>
        private void CreatePageContent()
        {
            StackLayout = ControlStyles.SetStackLayout();

            StackLayout innerStackLayout = ControlStyles.SetStackLayout();
            innerStackLayout.Orientation = StackOrientation.Horizontal;

            LevelLabel = ControlStyles.LargeTextBlueLabel();
            LevelLabel.Text = "Level " + _whatYouSeeGamePlayViewModel.Level;

            StartButton = ControlStyles.LargeTextGreenButton();
            StartButton.Text = "Go !";
            StartButton.Clicked += StartButton_Clicked;


           innerStackLayout.Children.Add(LevelLabel);
            innerStackLayout.Children.Add(StartButton);
            
            StackLayout.Children.Add(innerStackLayout);
            
            NewGrid();
            Grid = _whatYouSeeGamePlayViewModel.AddGridImages(Grid);
           
            StackLayout.Children.Add(Grid);
        }

      
      

        /// <summary>
        /// Create image grid 
        /// </summary>
        private void NewGrid()
        {
            Grid = GridCreator.CreateGrid(_whatYouSeeGamePlayViewModel.DifficultySetting.GridSize);

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
        private void StartButton_Clicked(object sender, EventArgs eventArgs)
        {
            Button s = sender as Button;
            s.IsEnabled = false;
            Grid =   _whatYouSeeGamePlayViewModel.ReShuffle(Grid);
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
                  FailedGameOver();
                }

                if (_whatYouSeeGamePlayViewModel.PlayCollections.SelectedImages.Count ==
                    _whatYouSeeGamePlayViewModel.PlayCollections.ToMatchImages.Count)
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
                Grid = _whatYouSeeGamePlayViewModel.ToggleImageIsEnabled(Grid,false);
                LevelLabel.Text = "Level " + _whatYouSeeGamePlayViewModel.Level;
                 Grid =  _whatYouSeeGamePlayViewModel.SetMemoriseGrid(Grid);
            }
            else
            {
                DifficultyCompleted();
             
            }
           
        }


        /// <summary>
        /// Handles the events for selection wrong image in guessing phase
        /// </summary>
        private void FailedGameOver()
        {
           Image gameOver = new Image
            {
                Source = _whatYouSeeGamePlayViewModel.ImageHelper.GameOverImage.Source,
               
                WidthRequest = Application.Current.MainPage.Width * 0.8,
                HeightRequest = Application.Current.MainPage.Height * 0.6
            };

            Button retryButton = ControlStyles.LargeTextGreenButton();
            retryButton.Text = "Retry";
            retryButton.Clicked += RetryButton_Clicked;

            StackLayout failedGameOver = ControlStyles.SetStackLayout();
            failedGameOver.Children.Add(gameOver);
            failedGameOver.Children.Add(retryButton);
           
            Content = failedGameOver;

        }

        /// <summary>
        /// Activates the Image for completing the difficutl
        /// </summary>
        private void DifficultyCompleted()
        {
            Content = new Image
            {
                Source = _whatYouSeeGamePlayViewModel.ImageHelper.CompleteImage.Source,

                WidthRequest = Application.Current.MainPage.Width * 0.8
            };

        }


        /// <summary>
        /// Sets Game play to retry the current level
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void RetryButton_Clicked(object sender, EventArgs eventArgs)
        {
            Button s = sender as Button;
            _whatYouSeeGamePlayViewModel.Level -= 1;
            _whatYouSeeGamePlayViewModel.NumberOfImagesToMatch -= 1;
            Content = StackLayout;
            NextRound();

        }

    }
}