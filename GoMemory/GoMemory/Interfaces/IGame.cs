using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using GoMemory.Models;
using Xamarin.Forms;

namespace GoMemory.Interfaces
{
    public interface IGame
    {
        void InitilizeRound();

        void Start();
        void EndGame(string endStatus);

       bool CheckSelections(Image selectedImage);

     
    }
}
