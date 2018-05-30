using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
        public GameStat GameStat;
        public Grid Grid;
        public static Timer EndLevelTimer;


        public WhatYouSeeGamePlayPage(Difficulty difficulty,string playStyle,ResumeModel resumeModel)
        {
            InitializeComponent();
            Title =  "What you see";
            GameStat = new GameStat
            {
                Difficulty = difficulty,
                PlayStyle = playStyle
            };
        
            _whatYouSeeGamePlayViewModel = new WhatYouSeeGamePlayViewModel(difficulty,resumeModel);
            CreatePageContent();
       
        }

       



        /// <summary>
        /// Create the initial layout of the page
        /// </summary>
        private void CreatePageContent()
        {
            
            Failed.IsVisible = false;
            LevelLabel.Text = _whatYouSeeGamePlayViewModel.SetLevelText();

            FlexFrame.MinimumHeightRequest = Application.Current.MainPage.Height * 0.6;


            AddImagesToselectFlexLayout();
            
            Grid = _whatYouSeeGamePlayViewModel.CreateNewGrid(Grid);
            Grid.MinimumWidthRequest = Application.Current.MainPage.Width * 0.5;
            Grid.MinimumWidthRequest = Application.Current.MainPage.Height * 0.6;
            Grid.IsVisible = false;

          
            StackLayout.Children.Add(Grid);
            AddTapGestures();

        }

        /// <summary>
        /// add Images to remember to a flex layout
        /// </summary>
        private void AddImagesToselectFlexLayout()
        {
            FlexLayout = _whatYouSeeGamePlayViewModel.CreateSequenceFlexLayout(FlexLayout);
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
            ToggleVisibilities();
           
        }

        /// <summary>
        /// Handles the tapping of a image once guessing phase has started
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ev"></param>
        private void OnTapped(object sender, EventArgs ev)
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
                    GameStat.Level = _whatYouSeeGamePlayViewModel.UnorderedGame.Level;

                    App.StatRepository.UpdateGameStat(GameStat);
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
                LevelLabel.Text = _whatYouSeeGamePlayViewModel.SetLevelText();
                AddImagesToselectFlexLayout();
                foreach (var image in Grid.Children)
                {
                    image.Opacity = 1;
                    image.IsEnabled = true;
                }
               
                ToggleVisibilities();
            }
            else
            {
                StackLayout.IsVisible = false;
                Failed.IsVisible = false;
                Complete.IsVisible = true;
            }

        }

        private void ToggleVisibilities()
        {
            StartButton.IsVisible = !StartButton.IsVisible ;
            FlexFrame.IsVisible = !FlexFrame.IsVisible;
            Grid.IsVisible = !Grid.IsVisible;
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