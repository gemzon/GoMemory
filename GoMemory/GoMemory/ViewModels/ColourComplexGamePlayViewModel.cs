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
            SetComplexColourPlayArray();
        }

      
        /// <summary>
        ///  set the color and text that will be need for the 
        /// round
        /// </summary>
        private void SetComplexColourPlayArray()
        {
            Random rnd = new Random();
          
            int count = 0;
            while (count != DifficultySetting.MaxSelectable)
            {
                

              
            }

        }
    }
}
