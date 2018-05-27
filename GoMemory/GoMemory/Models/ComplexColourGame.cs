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
        public List<string> WordColours { get; set; }

        public string[] PlayWordColours { get; set; }
        public Color[] PlayColours { get; set; }
        public ComplexColour[] SequenceColours { get; set; }
        public object[] SelectedColours { get; set; }
        public string[] SelectedWordColours { get; set; }
        public Mode Mode { get; set; }
        public int Level { get; set; } 
        public int MatchsNeeded { get; set; } = 1;


        public ComplexColourGame(int maxSelectable)
        {
           ColoursArray();
            WordColorsArray();
          PlayColours = new Color[maxSelectable];
            PlayWordColours = new string[maxSelectable];

            GenerateColors();
            GenerateWordColors();

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

        private void GenerateWordColors()
        {
            Random rnd = new Random();

            for (int i = 0; i < PlayWordColours.Length; i++)
            {
                int index = rnd.Next(0, WordColours.Count);
                PlayWordColours[i] = WordColours[index];
                WordColours.RemoveAt(index);
            }
        }

        private void ColoursArray()
        {
            Colours = new List<Color>()
            {
                Color.Blue,
                Color.SaddleBrown,
                Color.DarkRed, 
                Color.DimGray, 
                Color.Green, 
                Color.Orange, 
                Color.DeepPink, 
                Color.Purple, 
                Color.Teal
            };
        }

        private void WordColorsArray()
        {
            WordColours = new List<string>
            {
                "Blue",
                "Brown",
                "Red",
                "Gray",
                "Green",
                "Orange",
                "Pink",
                "Purple",
                "Teal"
            };
        }

       
    }


}
