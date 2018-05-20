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
        public DifficultySetting DifficultySetting { get; set; }
        public int Level { get; set; }
        public int NumberOfImagesToMatch { get; set; } = 1;
        

        private readonly ImageHelper _imageHelper;
        public ImagePlayCollection PlayCollections;


        public WhatYouSeeGamePlayViewModel(Difficulty difficulty)
        {
            DifficultySetting = new DifficultySetting(difficulty);
            _imageHelper = new ImageHelper();
           
            GetDifficulyImages();
            NextRound();
        }

        private void GetDifficulyImages()
        {
            
            PlayCollections = new ImagePlayCollection {AllImages = _imageHelper.GetImages(DifficultySetting.TotalImagesNeeded)};
   
        }


        /// <summary>
        /// Determinees if max level for difficulty is reached if not
        /// next round is intilized
        /// </summary>
        private void NextRound()
        {
            if (Level <= DifficultySetting.MaxLevel)
            {
                InitilizeRound();
            }
            else
            {
                //EndGame(PlayCollections.SelectedImages.Count != PlayCollections.ToMatchImages.Count
                //    ? "Lose"
                //    : "Win");
            }
        }


        /// <summary>
        /// IntilizeRound settings
        /// </summary>
        public void InitilizeRound()
        {

            Level += 1;
            NumberOfImagesToMatch += 1;
            PlayCollections.ToMatchImages = _imageHelper.ToMatchImages(NumberOfImagesToMatch,PlayCollections.AllImages);
            PlayCollections.SelectedImages = new List<Image>();
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
        public bool CheckSelections(Image selectedImage)
        {
            bool found = false;
            foreach (var image in PlayCollections.ToMatchImages)
            {
                if (image.Source == selectedImage.Source)
                {
                    PlayCollections.SelectedImages.Add(selectedImage);
                    found = true;
                    
                }
            }


            return found;
        }

        //Todo implement
        public void RoundComplete()
        {
            throw new NotImplementedException();
        }
    }
    }
