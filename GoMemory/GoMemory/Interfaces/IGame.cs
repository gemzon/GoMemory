using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using GoMemory.Models;

namespace GoMemory.Interfaces
{
    public interface IGame
    {
        void InitilizeRound();

        void Start();
        void EndGame(string endStatus);

        void CheckSelections(GameImage selectedImage);

     
    }
}
