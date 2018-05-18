using System;
using System.Collections.Generic;
using System.Text;
using GoMemory.Enums;

namespace GoMemory.ViewModels
{
    public class SequentialGamePlayViewModel
    {
        public Difficulty Difficulty { get; set; }

        public SequentialGamePlayViewModel(Difficulty difficulty)
        {
            Difficulty = difficulty;
           
        }
    }
}
