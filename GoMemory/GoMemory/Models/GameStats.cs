using System;
using System.Collections.Generic;
using System.Text;

namespace GoMemory.Models
{
   public class GameStats
    {
        public int Id { get; set; } 
        public string GameTitle { get; set; }
        public int BestLevel { get; set; }
        public DateTime AverageTime { get; set; }

    }
}
