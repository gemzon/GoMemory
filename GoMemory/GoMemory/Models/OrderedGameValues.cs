using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GoMemory.Models
{
    public class OrderedGameValues
    {
        public Image[] AllImages { get; set; }
        public Image[] ToMatchImages { get; set; }
        public Image[] SelectedImages { get; set; }
    }
}
