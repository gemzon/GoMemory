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
        public GameType GameType { get; set; }


        public GameLandingPage(GameType gameType)
        {
            InitializeComponent();
            Title = gameType.Title;
            GameType = gameType;
        }

        public void ResumeBtn_OnClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public async void StatsBtn_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StatsPage(GameType));
        }

        public async void RulesBtn_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RulesPage(GameType));
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
            if (GameType.Style == PlayStyle.WhatYouSeeGame)
            {
                await Navigation.PushAsync(new WhatYouSeeGamePlayPage(difficulty));
            }
            else if (GameType.Style == PlayStyle.ColourComplexGame)
            {
                await Navigation.PushAsync(new ColourComplexGamePlayPage (difficulty));
            }
            else
            {
                await Navigation.PushAsync(new SequentialGamePlayPage(difficulty));
            }
        }



    }
}