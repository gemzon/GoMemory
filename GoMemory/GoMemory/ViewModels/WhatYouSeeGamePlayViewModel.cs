using System;
using System.Collections.Generic;
using System.Text;
using GoMemory.Enums;

namespace GoMemory.ViewModels
{
    public class WhatYouSeeGamePlayViewModel : BaseViewModel
    {
        public Difficulty Difficulty { get; set; }

        public WhatYouSeeGamePlayViewModel(Difficulty difficulty)
        {
            Difficulty = difficulty;
        }
    }
}
