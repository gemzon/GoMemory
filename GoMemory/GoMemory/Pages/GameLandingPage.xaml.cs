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
    public partial class GameLandingPage : ContentPage
    {
        public string PlayStyle { get; set; }


        public GameLandingPage(string playStyle)
        {
            InitializeComponent();
            Title = playStyle;
            PlayStyle = playStyle;
        }

        public void ResumeBtn_OnClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public async void StatsBtn_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StatsPage(PlayStyle));
        }

        public async void RulesBtn_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RulesPage(PlayStyle));
        }

        public void Difficulty_OnClicked(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null && clickedButton.Text == "Easy")
            {
                SetGamePlay(Difficulty.Easy);
            }
            else if (clickedButton != null && clickedButton.Text == "Normal")
            {
                SetGamePlay(Difficulty.Normal);
            }
            else
            {
                SetGamePlay(Difficulty.Hard);
            }


        }

        public async void SetGamePlay(Difficulty difficulty)
        {
            if (PlayStyle == "What you see")
            {
                await Navigation.PushAsync(new WhatYouSeeGamePlayPage(difficulty,PlayStyle));
            }
            else if (PlayStyle == "Colour Complex")
            {
                await Navigation.PushAsync(new ColourComplexGamePlayPage (difficulty,PlayStyle));
            }
            else
            {
                await Navigation.PushAsync(new SequentialGamePlayPage(difficulty,PlayStyle));
            }
        }



    }
}