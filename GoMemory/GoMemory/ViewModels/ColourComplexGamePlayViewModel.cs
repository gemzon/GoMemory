using GoMemory.DataAccess;
using GoMemory.Enums;
using GoMemory.Helpers;
using GoMemory.Interfaces;
using GoMemory.Models;
using System;
using Xamarin.Forms;

namespace GoMemory.ViewModels
{
    class ColorComplexGamePlayViewModel : BaseViewModel, IGame
    {

        public DifficultySetting DifficultySetting { get; private set; }
        public ComplexColorGame ComplexColorGame { get; set; }
        public int GuessesMade { get; set; } = 0;
        public ResumeModel ResumeModel { get; set; }

        public ColorComplexGamePlayViewModel(Difficulty difficulty, ResumeModel resume)
        {
            DifficultySetting = SettingsData.SetCurrentDifficulty(GameType.ColourComplex, difficulty);


            //TODO refactor out to own class
            ComplexColorGame = new ComplexColorGame(DifficultySetting.MaxSelectable);
            if (resume != null)
            {
                ComplexColorGame.Level = resume.Level;
                ComplexColorGame.MatchesNeeded = resume.MatchesNeeded;
                ResumeModel = resume;
            }
            else
            {
                ResumeModel = new ResumeModel
                {
                    GameType = GameType.ColourComplex,
                    Difficulty = difficulty,
                };
            }

        }


        /// <summary>
        /// Return a string to set the level
        /// </summary>
        /// <returns></returns>
        public string SetLevelText()
        {
            return $"Level : ComplexColourGame.Level";
        }

        /// <summary>
        /// set values ready to generate the next round values
        /// </summary>
        public void Retry()
        {
            ComplexColorGame.Level -= 1;
            ComplexColorGame.MatchesNeeded -= 1;
        }


        /// <summary>
        /// Determiners if max level for difficulty is reached if not
        /// next round is initialized
        /// </summary>
        public bool NextRound()
        {
            ComplexColorGame.Level += 1;
            if (ComplexColorGame.Level <= DifficultySetting.MaxLevel)
            {
                ResumeModel.Level = ComplexColorGame.Level - 1;
                ResumeModel.MatchesNeeded = ComplexColorGame.MatchesNeeded;
                ResumeHelper.SetResume(ResumeModel);

                InitializeRound();
                return true;
            }

            ResumeHelper.RemoveResume(ResumeModel.GameType);
            return false;
        }


        /// <summary>
        /// InitializeRound settings
        /// </summary>
        public void InitializeRound()
        {
            ComplexColorGame.MatchesNeeded += 1;
            GuessesMade = 0;
            ComplexColorGame.SequenceColors = new ComplexColor[ComplexColorGame.MatchesNeeded];
            GenerateRoundToMatchComplexColors();
            SetMode();
        }


        /// <summary>
        /// Populate the stack layout with the sequence of Complex colors
        /// </summary>
        /// <param name="stackLayout"></param>
        /// <returns></returns>
        public StackLayout PopulateSequenceStackLayout(StackLayout stackLayout)
        {
            for (int i = 0; i < ComplexColorGame.SequenceColors.Length; i++)
            {
                StackLayout st = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal
                };
                Label itemnumber = new Label
                {
                    Text = $"{(i + 1)} . "
                };

                Label label = new Label
                {
                    Text = ComplexColorGame.SequenceColors[i].SpeltColor,
                    TextColor = ComplexColorGame.SequenceColors[i].TextColor,


                    FontSize = 25,
                    FontAttributes = FontAttributes.Bold,
                    Margin = new Thickness(0, 2, 0, 0)
                };

                st.Children.Add(itemnumber);
                st.Children.Add(label);
                stackLayout.Children.Add(st);
            }

            return stackLayout;
        }

        /// <summary>
        ///  set the color and text that will be need for the 
        /// round
        /// </summary>
        public void GenerateRoundToMatchComplexColors()
        {
            Random rnd = new Random();

            for (int i = 0; i < ComplexColorGame.SequenceColors.Length; i++)
            {
                int colourRndIndex = rnd.Next(0, ComplexColorGame.PlayColors.Length);
                int textRndIndex = rnd.Next(0, ComplexColorGame.PlayColors.Length);
               ComplexColorGame.SequenceColors[i] = new ComplexColor
                {                  
                    SpeltColor = ComplexColorGame.PlayColors[colourRndIndex].SpeltColor,
                    TextColor = ComplexColorGame.PlayColors[textRndIndex].TextColor,
                };               

            }
        }


        /// <summary>
        /// randomly set the round mode
        /// </summary>
        public string SetMode()
        {
            Random rnd = new Random();
            int num = rnd.Next(0, 2);

            ComplexColorGame.Mode = num == 1 ? Mode.Color : Mode.Text;
            ComplexColorGame.SelectedItems = new ComplexColor[ComplexColorGame.MatchesNeeded];
             
            if (ComplexColorGame.Mode == Mode.Text)
            {
                 return "Mode : Color Spelling";
            }          
            return "Mode :  Coloring";

        }


        /// <summary>
        /// Check if the selected button text match the correct 
        /// mode  colour
        /// must be in correct order
        /// </summary>
        /// <param name="colourSelected"></param>
        public bool CheckSequenceText(string colourSelected)
        {

            ComplexColorGame.SelectedItems[GuessesMade].SpeltColor = colourSelected;

            for (int i = 0; i < ComplexColorGame.SelectedItems.Length; i++)
            {
                if (ComplexColorGame.SelectedItems[i] == null)
                    break;

                if(String.Compare(ComplexColorGame.SelectedItems[i].SpeltColor,
                    ComplexColorGame.SequenceColors[i].SpeltColor) == 0 )
                    return false;
                //if(ComplexColourGame.SelectedWordColors[i] !=
                //    ComplexColourGame.SequenceColors[i].SpeltColour)                    ;
                 


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

            ComplexColorGame.SelectedItems[GuessesMade].TextColor = textColour;

            for (int i = 0; i < ComplexColorGame.SelectedItems.Length; i++)
            {
                if (ComplexColorGame.SelectedItems[i] == null)
                    break;
                if ((Color)ComplexColorGame.SelectedItems[i].TextColor !=
                        ComplexColorGame.SequenceColors[i].TextColor)
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
            Grid grid = GridHelper.CreateGrid(DifficultySetting.GridRowSize, DifficultySetting.GridColumnSize);
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
                        Text = ComplexColorGame.PlayColors[index].SpeltColor,
                        TextColor = ComplexColorGame.PlayColors[index].TextColor,
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
            return GuessesMade == ComplexColorGame.MatchesNeeded;
        }
    }
}
