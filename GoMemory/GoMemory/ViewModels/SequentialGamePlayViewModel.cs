using System;
using System.Collections.Generic;
using System.Text;
using GoMemory.Enums;
using GoMemory.Helpers;
using GoMemory.Models;

namespace GoMemory.ViewModels
{
    public class SequentialGamePlayViewModel
    {
        public DifficultySetting DifficultySetting { get; set; }
        public OrderedGameValues OrderedGameValues { get; set; }

        public ImageHelper ImageHelper { get; set; }

        public SequentialGamePlayViewModel(Difficulty difficulty)
        {
            SetDifficultySettings(difficulty);

        }

        /// <summary>
        /// Setup game difficulty settings
        /// </summary>
        /// <param name="difficulty"></param>
        /// <returns></returns>
        private void SetDifficultySettings(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    DifficultySetting = new DifficultySetting(2, 2, 4, 20);
                    break;
                case Difficulty.Hard:
                    DifficultySetting = new DifficultySetting(3, 3, 9, 50);
                    break;
                default:
                    DifficultySetting = new DifficultySetting(4, 4, 16, 25);
                    break;
            }
        }

        private void GetDifficulyImages()
        {
           OrderedGameValues = new OrderedGameValues {
               AllImages = ImageHelper.GetImages(DifficultySetting.TotalImagesNeeded)
            };
        }
    }
}
