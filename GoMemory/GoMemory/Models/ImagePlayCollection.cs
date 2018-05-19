using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GoMemory.Models
{
    public class ImagePlayCollection
    {
        public GameImage[] AllGameImages { get; set; }
        public List<GameImage> ToMatchGameImages { get; set; }
        public List<GameImage> SelectedGameImages { get; set; }
    }
}
