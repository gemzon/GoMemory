using System;
using System.Collections.Generic;
using System.Text;
using GoMemory.Models;

namespace GoMemory.ViewModels
{
    public class RulesViewModel
    {
        public GameType GameType { get; set; }
        public RulesViewModel(GameType gameType)
        {
            GameType = gameType;
        }
    }
}
