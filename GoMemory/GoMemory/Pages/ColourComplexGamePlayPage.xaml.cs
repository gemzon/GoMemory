using GoMemory.Enums;
using GoMemory.Models;
using GoMemory.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace GoMemory.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColourComplexGamePlayPage : ContentPage
    {
        readonly ColourComplexGamePlayViewModel _colourComplexGamePlayViewModel;
        private GameStat GameStat;

        public ColourComplexGamePlayPage(Difficulty difficulty, string playStyle, ResumeModel resume)
        {
            InitializeComponent();
            Title = "ColourComplex";
            GameStat = new GameStat
            {
                Difficulty = difficulty,
                PlayStyle = playStyle
            };


            _colourComplexGamePlayViewModel = new ColourComplexGamePlayViewModel(difficulty, resume);
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

                StackLayout.IsVisible = true;
                PlayLayout.IsVisible = false;
                Failed.IsVisible = false;
                SelectedStackLayout.Children.Clear();
                SequenceStackLayout = _colourComplexGamePlayViewModel.PopulateSequencStackLayout(SequenceStackLayout);
                LevelLabel.Text = _colourComplexGamePlayViewModel.SetLevelText();
                Content = StackLayout;
            }
            else
            {
                StackLayout.IsVisible = false;
                PlayLayout.IsVisible = false;
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
            ModeLabel.Text = _colourComplexGamePlayViewModel.SetMode();
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
            AddGuessButtonClickHandlers();

        }


        private void AddGuessButtonClickHandlers()
        {
            foreach (var child in Grid.Children)
            {
                if (child is Button btn) btn.Clicked += OnTapped;
            }
        }


        /// <summary>
        /// Handles the clicking of a button once guessing phase has started
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
            bool found = false;
            try
            {
                Grid.IsEnabled = false;
                Button btn = sender as Button;

                if (_colourComplexGamePlayViewModel.ComplexColourGame.Mode == Mode.Text)
                {
                    found = _colourComplexGamePlayViewModel.CheckSequenceText(btn.Text);
                }
                else if (_colourComplexGamePlayViewModel.ComplexColourGame.Mode == Mode.Color)
                {
                    found = _colourComplexGamePlayViewModel.CheckSequenceColour(btn.TextColor);

                }
                if (found)
                {
                    Label label = new Label
                    {
                        Text = btn.Text,
                        TextColor = System.Drawing.Color.FromName(btn.Text),
                        FontSize = 25,
                        FontAttributes = FontAttributes.Bold,
                        Margin = new Thickness(0, 2, 5, 0)
                    };

                    if (SelectedStackLayout.Children.Count > 2)
                    {
                        SelectedStackLayout.Children.RemoveAt(0);
                    }
                    SelectedStackLayout.Children.Add(label);
                }
                else
                {
                    Failed.IsVisible = true;
                    SequenceStackLayout.Children.Clear();
                    Content = Failed;

                }
                if (_colourComplexGamePlayViewModel.CheckIsRoundComplete())
                {
                    try
                    {
                        GameStat.Level = _colourComplexGamePlayViewModel.ComplexColourGame.Level;
                        App.StatRepository.UpdateGameStat(GameStat);
                    }
                    catch (Exception e)
                    {
                        //TODO: throw the exception and handle it properly idiot !!

                        Console.WriteLine(e);
                        throw;
                    }

                    NextRound();
                }


            }
            catch (Exception e)
            {
                //TODO: throw the exception and handle it properly idiot !!
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                Grid.IsEnabled = true;
                IsBusy = false;
            }

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

            NextRound();
        }
    }
}