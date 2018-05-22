using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoMemory.Enums;
using GoMemory.Helpers;
using GoMemory.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoMemory.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SequentialGamePlayPage : ContentPage
    {
        private SequentialGamePlayViewModel _sequentialGamePlayViewModel;
        public Grid Grid;
        public StackLayout StackLayout;
        public StackLayout SelectedImageStacklayout;
        public StackLayout SequenceStackLayout;
        public StackLayout StartStackLayout;
        public FlexLayout FlexLayout;
        public Button StartButton;
        public Label LevelLabel;

        public SequentialGamePlayPage (Difficulty difficulty)
        {
            InitializeComponent (); Title = "Sequential";
           _sequentialGamePlayViewModel = new SequentialGamePlayViewModel(difficulty);
            CreatePageContent();
            Content = StackLayout;
            NextRound();
            
        }


        /// <summary>
        /// Create the initial layout of the page
        /// </summary>
        private void CreatePageContent()
        {
            StackLayout = ControlStyles.SetStackLayout();

            StartStackLayout = ControlStyles.SetStackLayout();
            StartStackLayout.Orientation = StackOrientation.Horizontal;

            LevelLabel = ControlStyles.LargeTextBlueLabel();
            LevelLabel.Text = _sequentialGamePlayViewModel.SetLevelText();

            StartButton = ControlStyles.LargeTextGreenButton();
            StartButton.Text = "Go !";
            StartButton.Clicked += StartButton_Clicked;

            StartStackLayout.Children.Add(LevelLabel);
            StartStackLayout.Children.Add(StartButton);
            StackLayout.Children.Add(StartStackLayout);

            FlexLayout = new FlexLayout
            {
               JustifyContent = FlexJustify.SpaceEvenly,
                Wrap = FlexWrap.Wrap,
                WidthRequest = Application.Current.MainPage.Width -10
            };


            StackLayout.Children.Add(FlexLayout);

           
        } 

        public void NextRound()
        {
            bool next;
            next = _sequentialGamePlayViewModel.NextRound();
            if (next)
            {
              CreatePageContent();
                FlexLayout = _sequentialGamePlayViewModel.CreateSequenceFlexLayout(FlexLayout);
                LevelLabel.Text = _sequentialGamePlayViewModel.SetLevelText();
                Content = StackLayout;
            }
            else
            {
               DifficultyCompleted();
            }


        }

        private void DifficultyCompleted()
        {
            Content = new Image
            {
                Source = _sequentialGamePlayViewModel.ImageHelper.CompleteImage.Source,
                WidthRequest = Application.Current.MainPage.Width * 0.8
            };
        }

        private void StartButton_Clicked(object sender, EventArgs e)
        {
           
          Content =  GuessLayout();
            
        }

        private StackLayout GuessLayout()
        {
            StackLayout layout = ControlStyles.SetStackLayout();

            StartStackLayout = ControlStyles.SetStackLayout();
            StartStackLayout.Orientation = StackOrientation.Horizontal;

           Label selectionLabel = ControlStyles.LargeTextBlueLabel();
            selectionLabel.Text = "Your Guesses";
            
            StartStackLayout.Children.Add(selectionLabel);
          layout.Children.Add(StartStackLayout);
        
            Frame frame = new Frame();
            SelectedImageStacklayout = new StackLayout
            {
                Margin = new Thickness(0),
                Padding = new Thickness(2),
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                HeightRequest = Application.Current.MainPage.Height * 0.1
        };
            frame.Content = SelectedImageStacklayout;
            frame.BorderColor = Color.Black;
            layout.Children.Add(frame);

            Grid = _sequentialGamePlayViewModel.CreateNewGrid(Grid);
            Grid.HorizontalOptions = LayoutOptions.FillAndExpand;
            Grid.VerticalOptions = LayoutOptions.FillAndExpand;
            Grid.WidthRequest =  Application.Current.MainPage.Width *0.5;
            Grid.HeightRequest = Application.Current.MainPage.Height * 0.6;

            layout.Children.Add(Grid);
            AddTapGestures();
            return layout;
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
                found = _sequentialGamePlayViewModel.CheckSequence(img);
                if (found)
                {
                    Image sImage = new Image {Source = img.Source};
                  
                    if (SelectedImageStacklayout.Children.Count > 2 )
                    {
                        SelectedImageStacklayout.Children.RemoveAt(0);
                    }
                    SelectedImageStacklayout.Children.Add(sImage);
                }
                else
                {
                    FailedGameOver();
                }
                if (_sequentialGamePlayViewModel.CheckIsRoundComplete())
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
        /// Handles the events for selection wrong image in guessing phase
        /// </summary>
        private void FailedGameOver()
        {
            Image gameOver = new Image
            {
                Source = _sequentialGamePlayViewModel.ImageHelper.GameOverImage.Source,

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

        private void RetryButton_Clicked(object sender, EventArgs e)
        {
            _sequentialGamePlayViewModel.Retry();
            Content = StackLayout;
            SelectedImageStacklayout.Children.Clear();
            NextRound();
        }
    }
}