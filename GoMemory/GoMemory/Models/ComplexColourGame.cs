using GoMemory.Enums;
using GoMemory.Interfaces;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace GoMemory.Models
{
    public class ComplexColourGame : ILevel
    {
        public List<Color> Colors { get; set; }
        public List<string> WordColors { get; set; }

        public string[] PlayWordColors { get; set; }
        public Color[] PlayColors { get; set; }
        public ComplexColour[] SequenceColors { get; set; }
        public object[] SelectedColors { get; set; }
        public string[] SelectedWordColors { get; set; }
        public Mode Mode { get; set; }
        public int Level { get; set; }
        public int MatchesNeeded { get; set; } = 1;


        public ComplexColourGame(int maxSelectable)
        {
            ColoursArray();
            WordColorsArray();
            PlayColors = new Color[maxSelectable];
            PlayWordColors = new string[maxSelectable];

            GenerateColors();
            GenerateWordColors();

        }

        private void GenerateColors()
        {
            Random rnd = new Random();

            for (int i = 0; i < PlayColors.Length; i++)
            {
                int index = rnd.Next(0, Colors.Count);
                PlayColors[i] = Colors[index];
                Colors.RemoveAt(index);
            }
        }

        private void GenerateWordColors()
        {
            Random rnd = new Random();

            for (int i = 0; i < PlayWordColors.Length; i++)
            {
                int index = rnd.Next(0, WordColors.Count);
                PlayWordColors[i] = WordColors[index];
                WordColors.RemoveAt(index);
            }
        }

        private void ColoursArray()
        {
            Colors = new List<Color>()
            {
                Color.Blue,
                Color.Brown,
                Color.Red,
                Color.Gray,
                Color.Green,
                Color.Orange,
                Color.Pink,
                Color.Purple,
                Color.Teal
            };
        }

        private void WordColorsArray()
        {
            WordColors = new List<string>
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
