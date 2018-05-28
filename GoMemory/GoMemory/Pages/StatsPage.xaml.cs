using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class StatsPage : ContentPage
    {
        private readonly StatsViewModel _statsViewModel;
        public StatsPage (string  playStyle)
        {
            InitializeComponent ();
            BindingContext = _statsViewModel = new StatsViewModel(playStyle);
            Title = _statsViewModel.Title + " Stats";
        }
    }
}