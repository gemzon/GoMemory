using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace GoMemory.Models
{
    public class ImagePlayCollection
    {
        public ImagePath[] AllImages { get; set; }
        public List<ImagePath> ToMatchImages { get; set; }
        public List<ImagePath> SelectedImages { get; set; }
    }
}
