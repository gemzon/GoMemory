using GoMemory.Enums;

namespace GoMemory.Models
{
    public class DifficultySetting
    {
        public int GridRowSize { get; set; }
        public int GridColumnSize { get; set; } 
        public int  TotalImagesNeeded { get; set; }
        public int MaxLevel { get; set; }

        
    }
}