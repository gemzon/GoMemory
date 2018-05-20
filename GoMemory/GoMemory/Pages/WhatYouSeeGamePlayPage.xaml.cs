using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
        private int _gridSize;
        public Grid Grid;
        public StackLayout StackLayout;
       


        public WhatYouSeeGamePlayPage (Difficulty difficulty)
        {
            InitializeComponent ();
            _whatYouSeeGamePlayViewModel = new WhatYouSeeGamePlayViewModel(difficulty) ;
         CreatePageContent();
            Content = StackLayout;
        }

        private void OnTapped(Image img)
        {
            bool found = false;
           found =  _whatYouSeeGamePlayViewModel.CheckSelections(img);

            if (found)
            {
                img.Opacity = 0.5;
            }
            else
            {
                _whatYouSeeGamePlayViewModel.EndGame("error");
            }

            if (_whatYouSeeGamePlayViewModel.PlayCollections.SelectedImages.Count == _whatYouSeeGamePlayViewModel.NumberOfImagesToMatch)
            {
                _whatYouSeeGamePlayViewModel.RoundComplete();
            }
        }

        private void CreatePageContent()
        {
            StackLayout = new StackLayout();
            Label label = new Label {Text = "Level " + _whatYouSeeGamePlayViewModel.Level};
            StackLayout.Children.Add(label);
            SetStackLayoutMargins();
            CreateGrid();
            AddGridImages();
            StackLayout.Children.Add(Grid);
        }

        private void SetStackLayoutMargins()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    StackLayout.Margin = new Thickness(20, 40, 20, 20);
                    break;
                case Device.Android:
                    StackLayout.Margin = new Thickness(20);
                    break;
                default:
                    StackLayout.Margin = new Thickness(20);
                    break;
            }
        }

        private void CreateGrid()
        {
            Grid = new Grid {Margin = new Thickness(0,20,0,0),ColumnSpacing = 1,RowSpacing = 1};
            _gridSize = _whatYouSeeGamePlayViewModel.DifficultySetting.GridSize;
            for (int i = 0; i < _gridSize; i++)
            {
                Grid.ColumnDefinitions.Add(new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)});
                Grid.RowDefinitions.Add(new RowDefinition {Height = new GridLength(1, GridUnitType.Star)});
            }

           
        }

        

        private void AddGridImages()
        {
            
            int imagecount = 0;
            for (int row = 0; row < _whatYouSeeGamePlayViewModel.DifficultySetting.GridSize; row++)
            {
                for (int column = 0; column < _whatYouSeeGamePlayViewModel.DifficultySetting.GridSize; column++)
                {

                    Image image = new Image
                    {
                        Source = _whatYouSeeGamePlayViewModel.PlayCollections.AllImages[imagecount].Source
                    };
                 
                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += (s, e) => {
                        OnTapped(s as Image);
                    };
                    image.GestureRecognizers.Add(tapGestureRecognizer);

                    Grid.Children.Add(image, row, column);

                    imagecount += 1;
                }
            }
        }



    }
}