using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using GoMemory.Enums;
using GoMemory.Models;
using Xamarin.Forms;

namespace GoMemory.Interfaces
{
    public interface IGame
    {
        bool NextRound();
        void InitilizeRound();
        void SetDifficultySettings(Difficulty difficulty);

        string SetLevelText();

        void Retry();
    }
}
