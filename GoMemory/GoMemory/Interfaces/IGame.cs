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

        void GetDifficultyImages();

        Grid CreateNewGrid(Grid grid);

        Grid AddGridImages(Grid grid);

        string SetLevelText();

        void Retry();
    }
}
