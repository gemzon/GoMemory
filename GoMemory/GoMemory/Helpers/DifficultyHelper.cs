using GoMemory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoMemory.Helpers
{
    public static class DifficultyHelper
    {
          public static DifficultySetting SetDifficulty(int columSize,int rowSize,int maxSelectable, int maxLevel)
        {
              return new DifficultySetting()
            {
                GridColumnSize = columSize,
                GridRowSize = rowSize,
                MaxSelectable = maxSelectable,
                MaxLevel = maxLevel
            };
        }
    }
}
