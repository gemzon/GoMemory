using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoMemory.Models;
using GoMemory.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoMemory.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatsPage : ContentPage
    {
        private StatsViewModel _statsViewModel;
        public StatsPage (GameType gameType)
        {
            InitializeComponent ();
            BindingContext = _statsViewModel = new StatsViewModel(gameType);
            Title = _statsViewModel.Title + " Stats";
        }
    }
}