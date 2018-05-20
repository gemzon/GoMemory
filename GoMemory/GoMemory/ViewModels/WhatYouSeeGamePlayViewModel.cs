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
        

        public ImageHelper ImageHelper;
        public ImagePlayCollection PlayCollections;


        public WhatYouSeeGamePlayViewModel(Difficulty difficulty)
        {
            DifficultySetting = new DifficultySetting(difficulty);
            ImageHelper = new ImageHelper();
           
            GetDifficulyImages();
            NextRound();
        }

        /// <summary>
        /// Retrieve collection of image
        /// amount depends on difficulty setting
        /// </summary>
        private void GetDifficulyImages()
        {
            PlayCollections = new ImagePlayCollection {AllImages = ImageHelper.GetImages(DifficultySetting.TotalImagesNeeded)};
   }


        /// <summary>
        /// Determinees if max level for difficulty is reached if not
        /// next round is intilized
        /// </summary>
       public bool NextRound()
        {
            Level += 1;
            if (Level <= DifficultySetting.MaxLevel)
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
            
            NumberOfImagesToMatch += 1;
            PlayCollections.ToMatchImages = ImageHelper.ToMatchImages(NumberOfImagesToMatch,PlayCollections.AllImages);
            PlayCollections.SelectedImages = new List<Image>();
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
                image.Opacity = 0;
                Image temp = image as Image;
                
                foreach (var matchImage in PlayCollections.ToMatchImages)
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
        /// Toggles opacity of all the  images in the grid
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public Grid SetOpacity(Grid grid)
        {
            foreach (var image in grid.Children)
            {
                image.Opacity = 1;
            }

            return grid;
        }

      

        /// <summary>
        /// Check if the selected image is contain within 
        /// the list of image that are needed to be matched
        /// </summary>
        /// <param name="selectedImage"></param>
        public bool CheckSelections(Image selectedImage)
        {

            foreach (var image in PlayCollections.ToMatchImages)
            {
                if (image.Source != selectedImage.Source) continue;

                if (PlayCollections.SelectedImages.Count > 0)
                {
                    foreach (var img in PlayCollections.SelectedImages)
                    {
                        if (img.Source == selectedImage.Source) continue;
                        PlayCollections.SelectedImages.Add(selectedImage);

                        return true;
                    }
                }
                else
                {
                    PlayCollections.SelectedImages.Add(selectedImage);

                    return true;
                }
            }

            return false;
           
        }

        /// <summary>
        /// Toggle the click event of image of the Grid
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="visible"></param>
        /// <returns></returns>
        public Grid ToggleImageIsEnabled(Grid grid,bool visible)
        {
            foreach (var child in grid.Children)
            {
                child.IsEnabled = visible;
            }
            return grid;
        }
        /// <summary>
        /// Insert images into the Grid
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public Grid AddGridImages(Grid grid)
        {
            if (grid.Children.Count != 0)
            {
                grid.Children.Clear();
            }


            int imagecount = 0;
            for (int row = 0; row < DifficultySetting.GridSize; row++)
            {
                for (int column = 0; column < DifficultySetting.GridSize; column++)
                {

                    Image image = new Image
                    {
                        Source = PlayCollections.AllImages[imagecount].Source,
                        
                    };

                    grid.Children.Add(image, row, column);


                    imagecount += 1;
                }
            }

            return grid;
        }

    

      /// <summary>
      /// reshuffles the grid images on start 
      /// </summary>
      /// <param name="grid"></param>
      /// <returns></returns>
        public Grid ReShuffle(Grid grid)
        {
            PlayCollections.AllImages = ImageHelper.ShuffleCollection(PlayCollections.AllImages);
            grid = SetOpacity(grid);
            grid = ToggleImageIsEnabled(grid, true);
            grid = AddGridImages(grid);
            return grid;
        }

    }
    }
