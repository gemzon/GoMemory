using GoMemory.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoMemory.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RulesPage : ContentPage
    {
        private RulesViewModel _rulesViewModel;
        public RulesPage(string playStyle)
        {
            InitializeComponent();
            BindingContext = _rulesViewModel = new RulesViewModel(playStyle);
            Title =  $"{_rulesViewModel.PlayStyle } Rules";
            switch (playStyle)
            {
                case "What you see":
                    WhatYouSee.IsVisible = true;
                    break;
                case "Sequential":
                    Sequential.IsVisible = true;
                    break;
                case "Colour Complex":
                    ColourComplex.IsVisible = true;
                    break;
            }

        }
    }
}