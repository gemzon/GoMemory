using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoMemory.Enums;
using GoMemory.Helpers;
using GoMemory.Interfaces;
using GoMemory.Models;

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
            PlayCollections = new ImagePlayCollection { AllGameImages = _imageHelper.ShuffleCollection() };
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
            PlayCollections.ToMatchGameImages = _imageHelper.ToMatchGameImages(NumberOfImagesToMatch);
            PlayCollections.SelectedGameImages = new List<GameImage>();
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
        /// <param name="selectedGameImage"></param>
        public void CheckSelections(GameImage selectedGameImage)
        {

            if (PlayCollections.ToMatchGameImages.Contains(selectedGameImage))
            {
                PlayCollections.SelectedGameImages.Add(selectedGameImage);
                NextRound();
            }
            else
            {
                EndGame(PlayCollections.SelectedGameImages.Count != PlayCollections.ToMatchGameImages.Count
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
