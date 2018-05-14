using System;
using System.Collections.Generic;
using System.Text;
using GoMemory.Models;

namespace GoMemory.ViewModels
{
    public class GameLandingViewModel :BaseViewModel
    {
        public GameType GameType { get; set; }  
        public GameLandingViewModel(GameType gameType)
        {
            GameType = gameType;
        }
    }
}
