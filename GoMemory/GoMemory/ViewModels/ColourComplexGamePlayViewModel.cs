using GoMemory.DataAccess;
using GoMemory.Enums;
using GoMemory.Helpers;
using GoMemory.Interfaces;
using GoMemory.Models;
using System;
using Xamarin.Forms;

namespace GoMemory.ViewModels
{
    class ColourComplexGamePlayViewModel : BaseViewModel, IGame
    {

        public DifficultySetting DifficultySetting { get; private set; }
        public ComplexColourGame ComplexColourGame { get; set; }
        public int GuessesMade { get; set; } = 0;
        public ResumeModel ResumeModel { get; set; }

        public ColourComplexGamePlayViewModel(Difficulty difficulty, ResumeModel resume)
        {
            DifficultySetting = SettingsData.SetCurrentDifficulty(GameType.Guess, difficulty);


            //TODO refactor out to own class
            ComplexColourGame = new ComplexColourGame(DifficultySetting.MaxSelectable);
            if (resume != null)
            {
                ComplexColourGame.Level = resume.Level;
                ComplexColourGame.MatchesNeeded = resume.MatchesNeeded;
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
            ComplexColourGame.Level -= 1;
            ComplexColourGame.MatchesNeeded -= 1;
        }


        /// <summary>
        /// Determiners if max level for difficulty is reached if not
        /// next round is initialized
        /// </summary>
        public bool NextRound()
        {
            ComplexColourGame.Level += 1;
            if (ComplexColourGame.Level <= DifficultySetting.MaxLevel)
            {
                ResumeModel.Level = ComplexColourGame.Level - 1;
                ResumeModel.MatchesNeeded = ComplexColourGame.MatchesNeeded;
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
            ComplexColourGame.MatchesNeeded += 1;
            GuessesMade = 0;
            ComplexColourGame.SequenceColors = new ComplexColour[ComplexColourGame.MatchesNeeded];
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
            for (int i = 0; i < ComplexColourGame.SequenceColors.Length; i++)
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
                    Text = ComplexColourGame.SequenceColors[i].SpeltColour,
                    TextColor = ComplexColourGame.SequenceColors[i].TextColour,


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

            for (int i = 0; i < ComplexColourGame.SequenceColors.Length; i++)
            {
                int colourRndIndex = rnd.Next(0, ComplexColourGame.PlayColors.Length);
                int textRndIndex = rnd.Next(0, ComplexColourGame.PlayColors.Length);
                ComplexColour complexColour = new ComplexColour
                {
                    SpeltColour = ComplexColourGame.PlayWordColors[colourRndIndex],
                    TextColour = ComplexColourGame.PlayColors[textRndIndex],
                };
                ComplexColourGame.SequenceColors[i] = complexColour;

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
                ComplexColourGame.SelectedWordColors = new string[ComplexColourGame.MatchesNeeded];
                return "Mode : Colour Spelling";
            }
            ComplexColourGame.SelectedColors = new object[ComplexColourGame.MatchesNeeded];

            return "Mode : Word Coloring";

        }


        /// <summary>
        /// Check if the selected button text match the correct 
        /// mode  colour
        /// must be in correct order
        /// </summary>
        /// <param name="colourSelected"></param>
        public bool CheckSequenceText(string colourSelected)
        {

            ComplexColourGame.SelectedWordColors[GuessesMade] = colourSelected;

            for (int i = 0; i < ComplexColourGame.SelectedWordColors.Length; i++)
            {
                if (ComplexColourGame.SelectedWordColors[i] == null)
                    break;

                if(String.Compare(ComplexColourGame.SelectedWordColors[i],
                    ComplexColourGame.SequenceColors[i].SpeltColour) == 0 )
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

            ComplexColourGame.SelectedColors[GuessesMade] = textColour;

            for (int i = 0; i < ComplexColourGame.SelectedColors.Length; i++)
            {
                if (ComplexColourGame.SelectedColors[i] == null)
                    break;
                if ((Color)ComplexColourGame.SelectedColors[i] !=
                        ComplexColourGame.SequenceColors[i].TextColour)
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
                        Text = ComplexColourGame.PlayWordColors[index],
                        TextColor = System.Drawing.Color.FromName(ComplexColourGame.PlayWordColors[index]),
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
            return GuessesMade == ComplexColourGame.MatchesNeeded;
        }
    }
}
