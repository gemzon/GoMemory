using GoMemory.Enums;

namespace GoMemory.Models
{
    public class DifficultySetting
    {
        public int GridSize { get; set; }
        public int  TotalImagesNeeded { get; set; }
        public int MaxLevel { get; set; }

        public DifficultySetting(Difficulty difficulty)
        {
            
            switch (difficulty)
            {
                case Difficulty.Easy:
                    GridSize = 4;
                    TotalImagesNeeded = 16;
                    MaxLevel = 12;
                    break;
                case Difficulty.Hard:
                    GridSize = 6;
                    TotalImagesNeeded = 36;
                    MaxLevel = 32;
                    break;
                default:
                    GridSize = 5;
                    TotalImagesNeeded = 25;
                    MaxLevel = 22;
                    break;
            }
        }
    }
}