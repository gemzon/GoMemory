using System;
using System.Collections.Generic;
using System.Text;
using GoMemory.Enums;

namespace GoMemory.ViewModels
{
    class ColourComplexGamePlayViewModel
    {
        public Difficulty Difficulty { get; set; }

        public ColourComplexGamePlayViewModel(Difficulty difficulty)
        {
            Difficulty = difficulty;
        }
    }
}
