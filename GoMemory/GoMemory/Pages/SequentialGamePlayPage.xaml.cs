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
        private readonly SequentialGamePlayViewModel _sequentialGamePlayViewModel;


        public SequentialGamePlayPage(Difficulty difficulty)
        {
            InitializeComponent(); Title = "Sequential";
            _sequentialGamePlayViewModel = new SequentialGamePlayViewModel(difficulty);

            Content = StackLayout;
            
            NextRound();
            GuessLayout();
        }

        public void NextRound()
        {
            bool next;
            next = _sequentialGamePlayViewModel.NextRound();
            if (next)
            {

                StackLayout.IsVisible = true;
                PlayLayout.IsVisible = false;
                Failed.IsVisible = false;
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
            Complete.IsVisible = true;
        }

        private void StartButton_OnClicked(object sender, EventArgs e)
        {
            FlexLayout.Children.Clear();
            SelectedImageStackLayout.Children.Clear();
            StackLayout.IsVisible = false;
            PlayLayout.IsVisible = true;

            Content = PlayLayout;

        }

        private void GuessLayout()
        {
            Grid = _sequentialGamePlayViewModel.CreateNewGrid(Grid);


            WidthRequest = Application.Current.MainPage.Width - 10;
            HeightRequest = Application.Current.MainPage.Height * 0.6;
            Frame.WidthRequest = Application.Current.MainPage.Width * 0.7;
            Frame.HeightRequest = Application.Current.MainPage.Height * 0.1;
            Grid.WidthRequest = Application.Current.MainPage.Width * 0.5;
            Grid.HeightRequest = Application.Current.MainPage.Height * 0.6;

            PlayLayout.Children.Add(Grid);
            AddTapGestures();

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
                    Image sImage = new Image { Source = img.Source };

                    if (SelectedImageStackLayout.Children.Count > 2)
                    {
                        SelectedImageStackLayout.Children.RemoveAt(0);
                    }
                    SelectedImageStackLayout.Children.Add(sImage);
                }
                else
                {
                    Failed.IsVisible = true;
                    FlexLayout.Children.Clear();
                    Content = Failed;

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



        private void RetryButton_Clicked(object sender, EventArgs e)
        {
            _sequentialGamePlayViewModel.Retry();
            StackLayout.IsVisible = true;
            Failed.IsVisible = false;
            PlayLayout.IsVisible = false;
            Content = StackLayout;

            NextRound();
        }
    }
}