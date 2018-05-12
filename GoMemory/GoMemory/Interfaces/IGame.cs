using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;

namespace GoMemory.Interfaces
{
    public interface IGame
    {
        void Initilize();

        void Start();
        void EndGame();

        void CheckSelections();

     
    }
}
