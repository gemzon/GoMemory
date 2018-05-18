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
            Button btn = sender as Button;
            GameType gametype = new GameType();
            if (btn == null)
            {
                return;
            }

            if (btn.Text == "What You See")
            {
                gametype.Style = PlayStyle.WhatYouSeeGame;
            }
            else if(btn.Text == "Colour Complex")
            {
                gametype.Style = PlayStyle.ColourComplexGame;
            }
            else if(btn.Text == "Sequential")
            {
                gametype.Style = PlayStyle.SequentialGame;
            }

            gametype.Title = btn.Text;
            await Navigation.PushAsync(new GameLandingPage(gametype));
        }
    }
}