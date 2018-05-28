using System;
using System.Collections.Generic;
using System.Text;
using GoMemory.Enums;

namespace GoMemory.Models
{
   public class GameStats
    {
        public int Id { get; set; } 
        public string GameTitle { get; set; }
        public int Level { get; set; }
        public Difficulty Difficulty { get; set; }
        

    }
}
