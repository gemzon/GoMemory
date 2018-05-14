using System;
using System.Collections.Generic;
using System.Text;
using GoMemory.Models;

namespace GoMemory.ViewModels
{
    public class StatsViewModel : BaseViewModel
    {
        public GameType GameType { get; set; }
        public StatsViewModel(GameType gameType)
        {
            GameType = gameType;
        }
    }
}
