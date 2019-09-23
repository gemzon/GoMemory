using GoMemory.Interfaces;
using System.Collections.Generic;
using Xamarin.Forms;

namespace GoMemory.Models
{
    public class UnorderedGame : ILevel
    {
        public Image[] AllImages { get; set; }
        public Image[] ToMatchImages { get; set; }
        public List<Image> SelectedImages { get; set; }

        public int Level { get; set; } = 0;
        public int MatchesNeeded { get; set; } = 2;
    }
}
