using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoMemory.Enums;
using GoMemory.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace GoMemory.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        #if __IOS__

                Padding = new Thickness(0, 20, 0, 0);

        #endif
        public HomePage()
        {
            InitializeComponent();
            Title = "Go Memory";
           
        }


        private async void Button_OnClicked(object sender, EventArgs e)
        {
            if (!(sender is Button btn))
            {
                return;
            }

            await Navigation.PushAsync(new GameLandingPage(btn.Text));
        }
    }
}