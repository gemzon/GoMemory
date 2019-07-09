using GoMemory.Interfaces;
using System.Collections.Generic;
using Xamarin.Forms;

namespace GoMemory.Models
{
    public class UnorderedGame : ILevel
    {
        public Image[] AllImages { get; set; }
        public List<Image> ToMatchImages { get; set; }
        public List<Image> SelectedImages { get; set; }

        public int Level { get; set; }
        public int MatchsNeeded { get; set; } = 2;
    }
}
