using GoMemory.Enums;
using GoMemory.Helpers;
using GoMemory.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace GoMemory.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameLandingPage : ContentPage
    {
        public string PlayStyle { get; set; }
        public ResumeModel ResumeModel { get; set; }

        public GameLandingPage(string playStyle)
        {
            InitializeComponent();
            Title = playStyle;
            PlayStyle = playStyle;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CheckResume();
        }

        /// <summary>
        /// check to see if there is a saved game
        /// </summary>
        public async void CheckResume()
        {
            ResumeModel = await ResumeHelper.CheckResume(PlayStyle);
            if (ResumeModel != null)
            {
                ResumeBtn.IsEnabled = true;

            }
        }

        public void ResumeBtn_OnClicked(object sender, EventArgs e)
        {
            SetGamePlay(ResumeModel.Difficulty, ResumeModel);
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

        public async void SetGamePlay(Difficulty difficulty, ResumeModel resume = null)
        {
            if (PlayStyle == "What you see")
            {

                await Navigation.PushAsync(new WhatYouSeeGamePlayPage(difficulty, PlayStyle, resume));
            }
            else if (PlayStyle == "Colour Complex")
            {

                await Navigation.PushAsync(new ColourComplexGamePlayPage(difficulty, PlayStyle, resume));
            }
            else
            {
                await Navigation.PushAsync(new SequentialGamePlayPage(difficulty, PlayStyle, resume));
            }
        }



    }
}