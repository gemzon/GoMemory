using System;
using System.Collections.Generic;
using System.Text;
using GoMemory.Interfaces;
using Xamarin.Forms;

namespace GoMemory.Models
{
    public class OrderedGameValues : ILevel
    {
        public Image[] AllImages { get; set; }
        public Image[] ToMatchImages { get; set; }
        public Image[] SelectedImages { get; set; }
        public int Level { get; set; }
        public int NumberOfImagesToMatch { get; set; } = 3;
    }
}
