using System;
using System.Collections.Generic;
using System.Text;
using GoMemory.Enums;
using GoMemory.Helpers;
using GoMemory.Interfaces;
using GoMemory.Models;
using Xamarin.Forms;

namespace GoMemory.ViewModels
{
    class ColourComplexGamePlayViewModel : BaseViewModel, IGame
    {

        public DifficultySetting DifficultySetting { get; private set; }
        public ComplexColourGame ComplexColourGame { get; set; }
        public int GuessesMade { get; set; } = 0;

        public ColourComplexGamePlayViewModel(Difficulty difficulty,ResumeModel resume)
        {
            SetDifficultySettings(difficulty);
            ComplexColourGame = new ComplexColourGame(DifficultySetting.MaxSelectable);
            if (resume != null)
            {
                ComplexColourGame.Level = resume.Level;
                ComplexColourGame.MatchsNeeded = resume.MatchesNeeded;
            }

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
                    DifficultySetting = new DifficultySetting(1, 3, 3, 10);
                    break;
                case Difficulty.Hard:
                    DifficultySetting = new DifficultySetting(3, 3, 9, 32);
                    break;
                default:
                    DifficultySetting = new DifficultySetting(2, 3, 6, 20);
                    break;
            }
        }


        /// <summary>
        /// Retur na string to set the level
        /// </summary>
        /// <returns></returns>
        public string SetLevelText()
        {
            return "Level : " + ComplexColourGame.Level;
        }

        /// <summary>
        /// set values ready to generate the next round values
        /// </summary>
        public void Retry()
        {
            ComplexColourGame.Level -= 1;
            ComplexColourGame.MatchsNeeded -= 1;
        }


        /// <summary>
        /// Determinees if max level for difficulty is reached if not
        /// next round is intilized
        /// </summary>
        public bool NextRound()
        {
            ComplexColourGame.Level += 1;
            if (ComplexColourGame.Level <= DifficultySetting.MaxLevel)
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
            ComplexColourGame.MatchsNeeded += 1;
            GuessesMade = 0;
            ComplexColourGame.SequenceColours = new ComplexColour[ComplexColourGame.MatchsNeeded];
            GenreateRoundToMatchComplexColours();
            SetMode();
        }
        

        /// <summary>
        /// Populate the stack layout with the sequence of Complexcolors
        /// </summary>
        /// <param name="stackLayout"></param>
        /// <returns></returns>
        public StackLayout PopulateSequencStackLayout(StackLayout stackLayout)
        {
            for (int i = 0; i < ComplexColourGame.SequenceColours.Length; i++)
            {
               
                Label label = new Label
                {
                    Text = ComplexColourGame.SequenceColours[i].SpeltColour,
                    TextColor = ComplexColourGame.SequenceColours[i].TextColour,
                   
                    
                    FontSize = 25,
                    FontAttributes = FontAttributes.Bold,
                    Margin = new Thickness(0,2,0,0)
                };

                stackLayout.Children.Add(label);
            }

            return stackLayout;
        }
        
        /// <summary>
        ///  set the color and text that will be need for the 
        /// round
        /// </summary>
        public void GenreateRoundToMatchComplexColours()
        {
            Random rnd = new Random();
      
            for (int i = 0; i < ComplexColourGame.SequenceColours.Length; i++)
            {
                int colourRndIndex = rnd.Next(0, ComplexColourGame.PlayColours.Length);
                int textRndIndex = rnd.Next(0, ComplexColourGame.PlayColours.Length);
                ComplexColour complexColour = new ComplexColour
                {
                    SpeltColour = ComplexColourGame.PlayWordColours[colourRndIndex],
                    TextColour = ComplexColourGame.PlayColours[textRndIndex],
                };
                ComplexColourGame.SequenceColours[i] = complexColour;

            }
        }


        /// <summary>
        /// randomly set the round mode
        /// </summary>
        public string SetMode()
        {
            Random rnd = new Random();
            int num = rnd.Next(0, 2);

          ComplexColourGame.Mode = num == 1 ? Mode.Color : Mode.Text;
           
            if (ComplexColourGame.Mode == Mode.Text)
            {
                ComplexColourGame.SelectedWordColours = new string[ComplexColourGame.MatchsNeeded];
                return "Mode : Words";
            }
            ComplexColourGame.SelectedColours = new object[ComplexColourGame.MatchsNeeded];

            return "Mode :  Colour";

        }


        /// <summary>
        /// Check if the selected button text match the correct 
        /// mode  colour
        /// must be in correct order
        /// </summary>
        /// <param name="colourSelected"></param>
        public bool CheckSequenceText(string colourSelected)
        {
           
         ComplexColourGame.SelectedWordColours[GuessesMade] = colourSelected;
         
            for (int i = 0; i < ComplexColourGame.SelectedWordColours.Length; i++)
            {
              if  (ComplexColourGame.SelectedWordColours[i] == null)
                break;
                    if ( ComplexColourGame.SelectedWordColours[i] !=
                        ComplexColourGame.SequenceColours[i].SpeltColour)
                        return false;
             

            }

            GuessesMade += 1;
            return true;
        }
        /// <summary>
        /// Check if the selected button text match the correct 
        /// mode  colour
        /// must be in correct order
        /// </summary>
        /// <param name="textColour"></param>
        public bool CheckSequenceColour(Color textColour)
        {
            
             ComplexColourGame.SelectedColours[GuessesMade] = textColour;
         
            for (int i = 0; i < ComplexColourGame.SelectedColours.Length; i++)
            {
                if (ComplexColourGame.SelectedColours[i] == null)
                    break;
                if ((Color)ComplexColourGame.SelectedColours[i] !=
                        ComplexColourGame.SequenceColours[i].TextColour)
                        return false;
            }
            GuessesMade += 1;
            return true;
        }

        /// <summary>
        /// Create the grid for the Guessing buttons
        /// </summary>
        /// <returns></returns>
        public Grid GenerateGrid()
        {
            Grid grid =  GridHelper.CreateGrid(DifficultySetting.GridRowSize, DifficultySetting.GridColumnSize);
            grid = AddSelectionButtonsToGrid(grid);

            return grid;
        }


        /// <summary>
        /// add the guess buttons to the grid
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        private Grid AddSelectionButtonsToGrid(Grid grid)
        {
            int index = 0;
            for (int row = 0; row < DifficultySetting.GridRowSize; row++)
            {
                for (int column = 0; column < DifficultySetting.GridColumnSize; column++)
                {
                    Button button = new Button
                    {
                        Text = ComplexColourGame.PlayWordColours[index],
                        TextColor =  System.Drawing.Color.FromName(ComplexColourGame.PlayWordColours[index]),
                        BorderColor = Color.Black,
                        BackgroundColor = Color.White,
                        Margin = 5,
                        FontAttributes = FontAttributes.Bold
                        
                    };

                    grid.Children.Add(button, row, column);
                    
                    index += 1;

                }
            }

            return grid;
        }


        public bool CheckIsRoundComplete()
        {
            return GuessesMade == ComplexColourGame.MatchsNeeded;
        }
    }
}
