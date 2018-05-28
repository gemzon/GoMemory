using System;
using System.Collections.Generic;
using System.Text;
using GoMemory.Enums;
using GoMemory.Models;

namespace GoMemory.ViewModels
{
    public class RulesViewModel
    {
        public string PlayStyle { get; set; }
        public RulesViewModel(string playStyle)
        {
            PlayStyle = playStyle;
        }
    }
}
