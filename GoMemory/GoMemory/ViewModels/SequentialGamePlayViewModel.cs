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
        public OrderedGame OrderedGame { get; set; }
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
           OrderedGame = new OrderedGame {
               AllImages = ImageHelper.GetImages(DifficultySetting.MaxSelectable)
            };
        }

        /// <summary>
        /// Adds images for the round to the sequence layout
        /// </summary>
        /// <param name="layout"></param>
        /// <returns></returns>
        public StackLayout PopulateSequenceStackLayout(StackLayout layout)
        {
            for (int i = 0; i < OrderedGame.ToMatchImages.Length; i++)
            {
                Image img = new Image
                {
                    Source = OrderedGame.ToMatchImages[i].Source,

                    Margin = new Thickness(2)
                };

                layout.Children.Add(img);
            }

            return layout;
        }
      
    
        /// <summary>
        /// Create a grid containing the image used at this levle of difficulty
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public Grid CreateNewGrid(Grid grid)
        {
            grid = GridHelper.CreateGrid(DifficultySetting.GridRowSize, DifficultySetting.GridColumnSize);
            grid = AddGridImages(grid);
     

           return grid;
        }

        public Grid AddGridImages(Grid grid)
        {
       return  GridHelper.InsertGridImages(grid, OrderedGame.AllImages, DifficultySetting);

        }


        /// <summary>
        /// Determinees if max level for difficulty is reached if not
        /// next round is intilized
        /// </summary>
        public bool NextRound()
        {
            OrderedGame.Level += 1;
           
            if (OrderedGame.Level <= DifficultySetting.MaxLevel)
            {
                
             OrderedGame.MatchsNeeded += 1;
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
            OrderedGame.ToMatchImages = new Image[OrderedGame.MatchsNeeded];
            OrderedGame.SelectedImages = new Image[OrderedGame.MatchsNeeded];
            
            GenerateToMatchSequence();
            GuessesMade = 0;
        }

       


        /// <summary>
        /// Generate the sequence that needs to be matched can have mulitple images of the same type
        /// </summary>
        private void GenerateToMatchSequence()
        {
            
            Random rnd = new Random();
            for (int i = 0; i < OrderedGame.ToMatchImages.Length; i++)
            {
               
                int randomValue = rnd.Next(0, OrderedGame.AllImages.Length);
                Image img = new Image
                {
                    Source = OrderedGame.AllImages[randomValue].Source,
                    Aspect = Aspect.Fill,
                    Margin = new Thickness(2)
                   
                };
                OrderedGame.ToMatchImages[i] = img;
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
            OrderedGame.SelectedImages[GuessesMade] = selectedImage;

            for (int i = 0; i < GuessesMade+1; i++)
            {
                if (OrderedGame.SelectedImages[i].Source != OrderedGame.ToMatchImages[i].Source)
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
            return "Level : " + OrderedGame.Level;
        }

        /// <summary>
        /// Set retry values
        /// </summary>
        public void Retry()
        {
           OrderedGame.Level -= 1;
           OrderedGame.MatchsNeeded -= 1;


        }

        public bool CheckIsRoundComplete()
        {
            return GuessesMade == OrderedGame.ToMatchImages.Length;
        }
        
    }
}
