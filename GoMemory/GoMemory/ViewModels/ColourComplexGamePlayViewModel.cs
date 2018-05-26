using System;
using System.Collections.Generic;
using System.Text;
using GoMemory.Enums;
using GoMemory.Models;
using Xamarin.Forms;

namespace GoMemory.ViewModels
{
    class ColourComplexGamePlayViewModel
    {

        public DifficultySetting DifficultySetting { get; private set; }
        public ComplexColourGame ComplexColourGame { get; set; }

        public ColourComplexGamePlayViewModel(Difficulty difficulty)
        {
            SetDifficultySettings(difficulty);
            ComplexColourGame = new ComplexColourGame(DifficultySetting.MaxSelectable);
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
                    DifficultySetting = new DifficultySetting(1, 3, 3, 10);
                    break;
                case Difficulty.Hard:
                    DifficultySetting = new DifficultySetting(2, 3, 6, 20);
                    break;
                default:
                    DifficultySetting = new DifficultySetting(3, 3, 9, 32);
                    break;
            }
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
            GenreateRoundToMatchComplexColours();
            ComplexColourGame.SequenceColours = new ComplexColour[ComplexColourGame.MatchsNeeded];
        }

      
        /// <summary>
        ///  set the color and text that will be need for the 
        /// round
        /// </summary>
        private void GenreateRoundToMatchComplexColours()
        {
            Random rnd = new Random();
            ComplexColourGame.SequenceColours = new ComplexColour[ComplexColourGame.MatchsNeeded];

            for (int i = 0; i < ComplexColourGame.MatchsNeeded; i++)
            {
                int colourRndIndex = rnd.Next(0, ComplexColourGame.PlayColours.Length);
                int textRndIndex = rnd.Next(0, ComplexColourGame.PlayColours.Length);
                ComplexColourGame.SequenceColours[i].BackgroundColour = ComplexColourGame.PlayColours[colourRndIndex];
                ComplexColourGame.SequenceColours[i].TextColour = ComplexColourGame.PlayColours[textRndIndex];
            }
        }
    }
}
