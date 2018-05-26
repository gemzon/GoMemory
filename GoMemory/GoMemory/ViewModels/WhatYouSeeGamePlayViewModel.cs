using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using GoMemory.Enums;
using GoMemory.Helpers;
using GoMemory.Interfaces;
using GoMemory.Models;
using Xamarin.Forms;

namespace GoMemory.ViewModels
{
    public class WhatYouSeeGamePlayViewModel : BaseViewModel,IGame
    {
        public DifficultySetting DifficultySetting { get; set; }
        public ImageHelper ImageHelper { get; set; }
        public UnorderedGame UnorderedGame { get; set; }


        public WhatYouSeeGamePlayViewModel(Difficulty difficulty)
        {
            SetDifficultySettings(difficulty);
            ImageHelper = new ImageHelper();
            GetDifficultyImages();
            NextRound();
        }


        /// <summary>
        /// Setup game difficulty settings
        /// </summary>
        /// <param name="difficulty"></param>
        /// <returns></returns>
        public void SetDifficultySettings(Difficulty difficulty)
        {
           switch (difficulty)
            {
                case Difficulty.Easy:
                    DifficultySetting = new DifficultySetting(4,4,16,15);
                    break;
                case Difficulty.Hard:
                    DifficultySetting = new DifficultySetting(6, 6, 36, 32);
                    break;
                default:
                    DifficultySetting = new DifficultySetting(5, 5, 25, 22);
                    break;
            }
        }


        /// <summary>
        /// Retrieve collection of image
        /// amount depends on difficulty setting
        /// </summary>
        public void GetDifficultyImages()
        {
            UnorderedGame = new UnorderedGame {AllImages = ImageHelper.GetImages(DifficultySetting.MaxSelectable)};
   }


        /// <summary>
        /// Determinees if max level for difficulty is reached if not
        /// next round is intilized
        /// </summary>
       public bool NextRound()
        {
            UnorderedGame.Level += 1;
            if (UnorderedGame.Level <= DifficultySetting.MaxLevel)
            {
                InitilizeRound();
                return true;
            }

            return false;
        }


        /// <summary>
        /// IntilizeRound settings
        /// </summary>
        public void InitilizeRound()
        {
            UnorderedGame.MatchsNeeded += 1;
            UnorderedGame.ToMatchImages = ImageHelper.ToMatchImagesList(UnorderedGame.MatchsNeeded,UnorderedGame.AllImages);
            UnorderedGame.SelectedImages = new List<Image>();
        }

       /// <summary>
       /// Set up the to memoriseGrid
       /// </summary>
       /// <param name="grid"></param>
       /// <returns></returns>
        public Grid SetMemoriseGrid(Grid grid)
        {
            foreach (var image  in grid.Children)
            {
                image.Opacity = 0.1;
                Image temp = image as Image;
                
                foreach (var matchImage in UnorderedGame.ToMatchImages)
                {
                    if (temp.Source == matchImage.Source)
                    {
                       temp.Opacity = 1;
                    }
                }
            }
            return grid;
        }




        /// <summary>
        /// Create a new GameGrid
        /// </summary>
        /// <returns></returns>
        public Grid CreateNewGrid(Grid grid)
        {
            grid = GridHelper.CreateGrid(DifficultySetting.GridRowSize, DifficultySetting.GridColumnSize);
            return grid;
        }

        
        /// <summary>
        /// Check if the selected image is contain within 
        /// the list of image that are needed to be matched
        /// </summary>
        /// <param name="selectedImage"></param>
        public bool CheckSelections(Image selectedImage)
        {

            foreach (var image in UnorderedGame.ToMatchImages)
            {
                if (image.Source != selectedImage.Source) continue;

                if (UnorderedGame.SelectedImages.Count > 0)
                {
                    foreach (var img in UnorderedGame.SelectedImages)
                    {
                        if (img.Source == selectedImage.Source) continue;
                        UnorderedGame.SelectedImages.Add(selectedImage);

                        return true;
                    }
                }
                else
                {
                    UnorderedGame.SelectedImages.Add(selectedImage);

                    return true;
                }
            }

            return false;
           
        }

     

        /// <summary>
        /// Insert images into the Grid
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public Grid AddGridImages(Grid grid)
        {
            return GridHelper.InsertGridImages(grid,UnorderedGame.AllImages,DifficultySetting);
        }

    

     



        /// <summary>
        /// Check to see if the number of correct selection is
        /// equal to the total number of correct guesses needed
        /// </summary>
        /// <returns></returns>
        public bool CheckIsRoundComplete()
        {
            return UnorderedGame.SelectedImages.Count ==
                   UnorderedGame.ToMatchImages.Count;
        }

        /// <summary>
        /// Set a Labels text to the current level
        /// </summary>
        /// <returns></returns>
        public string SetLevelText()
        {
            return "Level : " + UnorderedGame.Level;
        }

        /// <summary>
        /// Set retry values
        /// </summary>
        public void Retry()
        {
            UnorderedGame.Level -= 1;
            UnorderedGame.MatchsNeeded -= 1;

        }

        public FlexLayout CreateSequenceFlexLayout(FlexLayout flexLayout)
        {
            flexLayout.Children.Clear();
            for (int i = 0; i < UnorderedGame.ToMatchImages.Count; i++)
            {
                Image img = new Image
                {
                    Source = UnorderedGame.ToMatchImages[i].Source,

                    Margin = new Thickness(2)
                };

                flexLayout.Children.Add(img);
            }

            return flexLayout;
        }
    }
    }
