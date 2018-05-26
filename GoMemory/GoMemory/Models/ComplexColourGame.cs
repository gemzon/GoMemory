using System;
using System.Collections.Generic;
using System.Text;
using GoMemory.Enums;
using GoMemory.Interfaces;
using Xamarin.Forms;

namespace GoMemory.Models
{
    public class ComplexColourGame : ILevel
    {
        public List<Color> Colours { get; set; }
        public Color[] PlayColours { get; set; }
        public ComplexColour[] SequenceColours { get; set; }
        public ComplexColour[] SelectedColours { get; set; }
        public Mode Mode { get; set; }
        public int Level { get; set; }
        public int MatchsNeeded { get; set; } = 2;


        public ComplexColourGame(int maxSelectable)
        {
           ColoursArray();
          PlayColours = new Color[maxSelectable];
            GenerateColors();

        }

        private void GenerateColors()
        {
            Random rnd = new Random();
        
            for (int i = 0; i< PlayColours.Length; i++)
            {
                int index = rnd.Next(0, Colours.Count);
                PlayColours[i] = Colours[index];
                Colours.RemoveAt(index);
            }
        }

        private void ColoursArray()
        {
            Colours = new List<Color>()
            {
                Color.Blue,
                Color.SaddleBrown,
                Color.DarkRed, 
                Color.Yellow, 
                Color.Green, 
                Color.Orange, 
                Color.DeepPink, 
                Color.Purple, 
                Color.Teal
            };
        }

       
    }


}
