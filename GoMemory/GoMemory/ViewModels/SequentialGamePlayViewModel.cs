using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using GoMemory.Enums;
using GoMemory.Helpers;
using GoMemory.Interfaces;
using GoMemory.Models;
using Xamarin.Forms;

namespace GoMemory.ViewModels
{
    public class SequentialGamePlayViewModel : BaseViewModel,IGame
    {
        public DifficultySetting DifficultySetting { get; set; }
        public OrderedGameValues OrderedGameValues { get; set; }
        public int GuessesMade { get; set; }
        public ImageHelper ImageHelper { get; set; }

        public SequentialGamePlayViewModel(Difficulty difficulty)
        {
            SetDifficultySettings(difficulty);
            ImageHelper = new ImageHelper();
            GetDifficultyImages();
            GuessesMade = 0;
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
                    DifficultySetting = new DifficultySetting(2, 2, 4, 10);
                    break;
                case Difficulty.Normal:
                    DifficultySetting = new DifficultySetting(3, 3, 9, 20);
                    break;
                case Difficulty.Hard:
                    DifficultySetting = new DifficultySetting(4, 4, 16, 30);
                    break;
            }
        }

        /// <summary>
        /// Retrieve the image need for the selection Grid and for
        /// generate sequences
        /// </summary>
        public void GetDifficultyImages()
        {
           OrderedGameValues = new OrderedGameValues {
               AllImages = ImageHelper.GetImages(DifficultySetting.TotalImagesNeeded)
            };
        }


      
        public FlexLayout CreateSequenceFlexLayout(FlexLayout flexLayout)
        {
            
            for (int i = 0; i < OrderedGameValues.ToMatchImages.Length; i++)
            {
                Image img = new Image
                {
                    Source = OrderedGameValues.ToMatchImages[i].Source,
                   
                    Margin = new Thickness(2)
                };

                flexLayout.Children.Add(img);
            }

            return flexLayout;
        }

        public Grid CreateNewGrid(Grid grid)
        {
            grid = GridHelper.CreateGrid(DifficultySetting.GridRowSize, DifficultySetting.GridColumnSize);
            grid = AddGridImages(grid);
     

           return grid;
        }

        public Grid AddGridImages(Grid grid)
        {
       return  GridHelper.InsertGridImages(grid, OrderedGameValues.AllImages, DifficultySetting);

        }


        /// <summary>
        /// Determinees if max level for difficulty is reached if not
        /// next round is intilized
        /// </summary>
        public bool NextRound()
        {
            OrderedGameValues.Level += 1;
           
            if (OrderedGameValues.Level <= DifficultySetting.MaxLevel)
            {
                
             OrderedGameValues.NumberOfImagesToMatch += 1;
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
            OrderedGameValues.ToMatchImages = new Image[OrderedGameValues.NumberOfImagesToMatch];
            OrderedGameValues.SelectedImages = new Image[OrderedGameValues.NumberOfImagesToMatch];
            
            GenerateToMatchSequence();
            GuessesMade = 0;
        }

       


        /// <summary>
        /// Generate the sequence that needs to be matched can have mulitple images of the same type
        /// </summary>
        private void GenerateToMatchSequence()
        {
            
            Random rnd = new Random();
            for (int i = 0; i < OrderedGameValues.ToMatchImages.Length; i++)
            {
               
                int randomValue = rnd.Next(0, OrderedGameValues.AllImages.Length);
                Image img = new Image
                {
                    Source = OrderedGameValues.AllImages[randomValue].Source,
                    Aspect = Aspect.Fill,
                    Margin = new Thickness(2)
                   
                };
                OrderedGameValues.ToMatchImages[i] = img;
            }
        }


        /// <summary>
        /// Check if the selected image is contain within 
        /// the array of image that are needed to be matched 
        /// must be in correct order
        /// </summary>
        /// <param name="selectedImage"></param>
        public bool CheckSequence(Image selectedImage)
        {
            OrderedGameValues.SelectedImages[GuessesMade] = selectedImage;

            for (int i = 0; i < GuessesMade+1; i++)
            {
                if (OrderedGameValues.SelectedImages[i].Source != OrderedGameValues.ToMatchImages[i].Source)
                    return false;
                else
                    continue;
            }

            GuessesMade += 1;
            return true;
        }


        /// <summary>
            /// Set a Labels text to the current level
            /// </summary>
            /// <returns></returns>
            public string SetLevelText()
        {
            return "Level : " + OrderedGameValues.Level;
        }

        /// <summary>
        /// Set retry values
        /// </summary>
        public void Retry()
        {
           OrderedGameValues.Level -= 1;
           OrderedGameValues.NumberOfImagesToMatch -= 1;


        }

        public bool CheckIsRoundComplete()
        {
            return GuessesMade == OrderedGameValues.ToMatchImages.Length;
        }
        
    }
}
