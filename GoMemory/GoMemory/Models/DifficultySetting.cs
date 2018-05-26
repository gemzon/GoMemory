using GoMemory.Enums;
using GoMemory.Interfaces;

namespace GoMemory.Models
{
    public class DifficultySetting
    {
        public int GridRowSize { get; set; }
        public int GridColumnSize { get; set; }
        public int MaxSelectable { get; set; }
        public int MaxLevel { get; set; }
     

        /// <summary>
        /// Setup Difficulty Setting object
        /// </summary>
        /// <param name="gridColumnSize"></param>
        /// <param name="gridRowSize"></param>
        /// <param name="maxSelectable"></param>
        /// <param name="maxLevel"></param>
        public DifficultySetting(int gridColumnSize, int gridRowSize,
                                     int maxSelectable, int maxLevel)
        {

            GridColumnSize = gridColumnSize;
            GridRowSize = gridRowSize;
            MaxSelectable = maxSelectable;
            MaxLevel = maxLevel;

        }

    }
}