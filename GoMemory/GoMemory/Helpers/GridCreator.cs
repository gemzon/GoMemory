using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GoMemory.Helpers
{
    public static class GridCreator
    {
        public static Grid CreateGrid(int size)
        {
          Grid Grid =   new Grid { Margin = new Thickness(0, 20, 0, 0), ColumnSpacing = 1, RowSpacing = 1 };

            for (int i = 0; i < size; i++)
            {
                Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }

            return Grid;
        }
    }
}
