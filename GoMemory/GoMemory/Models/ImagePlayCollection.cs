using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace GoMemory.Models
{
    public class ImagePlayCollection
    {
        public Image[] AllImages { get; set; }
        public List<Image> ToMatchImages { get; set; }
        public List<Image> SelectedImages { get; set; }
    }
}
