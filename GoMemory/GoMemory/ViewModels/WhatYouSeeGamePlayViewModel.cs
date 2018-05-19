using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoMemory.Enums;
using GoMemory.Helpers;
using GoMemory.Interfaces;
using GoMemory.Models;
using Xamarin.Forms;

namespace GoMemory.ViewModels
{
    public class WhatYouSeeGamePlayViewModel : BaseViewModel, IGame
    {
        public Difficulty Difficulty { get; set; }
        public int Level { get; set; }
        public int NumberOfImagesToMatch { get; set; } = 1;
        public int Maxlevel { get; set; }

        private readonly ImageHelper _imageHelper;
        public ImagePlayCollection PlayCollections;


        public WhatYouSeeGamePlayViewModel(Difficulty difficulty)
        {
            Difficulty = difficulty;
            _imageHelper = new ImageHelper();
            SetMaxLevel();
            PlayCollections = new ImagePlayCollection { AllImages = _imageHelper.ShuffleCollection() };
             NextRound();
        }

        

        /// <summary>
        /// Determinees if max level for difficulty is reached if not
        /// next round is intilized
        /// </summary>
        private void NextRound()
        {
            if (Level <= Maxlevel)
            {
                InitilizeRound();
            }
        }


        /// <summary>
        /// IntilizeRound settings
        /// </summary>
        public void InitilizeRound()
        {

            Level += 1;
            NumberOfImagesToMatch += 1;
            PlayCollections.ToMatchImages = _imageHelper.ToMatchImages(NumberOfImagesToMatch);
            PlayCollections.SelectedImages = new List<ImagePath>();
        }

        //Todo implement start of round
        public void Start()
        {

        }


        //Todo Implement end Game conditions
        public void EndGame(string status)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Check if the selected image is contain within 
        /// the list of image that are needed to be matched
        /// </summary>
        /// <param name="selectedImage"></param>
        public void CheckSelections(ImagePath selectedImage)
        {

            if (PlayCollections.ToMatchImages.Contains(selectedImage))
            {
                PlayCollections.SelectedImages.Add(selectedImage);
                NextRound();
            }
            else
            {
                EndGame(PlayCollections.SelectedImages.Count != PlayCollections.ToMatchImages.Count
                    ? "Lose"
                    : "Win");
            }
        }

        /// <summary>
        /// Sets Maxlevel by determining which level of difficulty 
        /// was selected
        /// </summary>
        private void SetMaxLevel()
        {
            switch (Difficulty)
            {
                case Difficulty.Hard:
                    Maxlevel = 30;
                    break;
                case Difficulty.Normal:
                    Maxlevel = 20;
                    break;
                default:
                    Maxlevel = 10;
                    break;
            }
        }


    }
}
