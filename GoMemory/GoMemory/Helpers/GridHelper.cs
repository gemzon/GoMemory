using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GoMemory.Helpers
{
    public static class GridHelper
    {
        public static Grid CreateGrid(int rowSize,int columSize)
        {
          Grid Grid =   new Grid { Margin = new Thickness(0, 20, 0, 0), ColumnSpacing = 1, RowSpacing = 1 };

            for (int i = 0; i < rowSize; i++)
            {
                Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }
            for (int i = 0; i < columSize; i++)
            {
                Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            return Grid;
        }

        /// <summary>
        /// Toggle the click event of image of the Grid
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="enabled"></param>
        /// <returns></returns>
        public static Grid ToggleImageIsEnabled(Grid grid, bool enabled)
        {
            foreach (var child in grid.Children)
            {
                child.IsEnabled = enabled;
            }
            return grid;
        }
    }
}
