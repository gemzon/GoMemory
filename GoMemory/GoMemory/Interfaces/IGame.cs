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

        Grid SetMemoriseGrid(Grid grid);
       

       bool CheckSelections(Image selectedImage);

     
    }
}
