using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using GoMemory.Interfaces;
using Xamarin.Forms;

namespace GoMemory.Models
{
    public class UnorderedGameValues : ILevel
    {
        public Image[] AllImages { get; set; }
        public List<Image> ToMatchImages { get; set; }
        public List<Image> SelectedImages { get; set; }

        public int Level { get; set; } 
        public int NumberOfImagesToMatch { get; set; } = 1;
    }
}
