﻿using System;
using System.Collections.Generic;
using System.Text;
using GoMemory.Enums;
using SQLite;

namespace GoMemory.Models
{
    [Table("ResumeModel")]
   public class ResumeModel
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; } 
        
        public string PlayStyle { get; set; }
        public int Level { get; set; }
        public Difficulty Difficulty { get; set; }
        public int MatchesNeeded { get; set; }  
        

    }
}
