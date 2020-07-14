using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace App2048
{
    interface ITileStyle
    {
        void Style(TextBox[,] tiles);
    }


    class TileStyle : ITileStyle
    {

        public void Style(TextBox[,] tiles)
        {
            int length = Convert.ToInt32(Math.Sqrt(Convert.ToDouble(tiles.Length)));

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    StyleItem(tiles[i, j]);
                }
            }
        }

        public void StyleItem(TextBox tile)
        {
            int value;
            if (tile.Text == "")
            {
                value = 0;
            }
            else
            {
                value = Convert.ToInt32(tile.Text);
            }
            if (value == 0)
            {
                tile.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#776e65"));
                tile.Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#cdc1b4"));
            }
            else if(value == 2)
            { 
                tile.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#776e65"));
                tile.Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#eee4da"));
            }
            else if(value == 4)
            {
                tile.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#776e65"));
                tile.Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#ede0c8"));
            }
            else if (value == 8)
            {
                tile.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#f9f6f2"));
                tile.Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#f2b179"));
            }
            else if (value == 16)
            {
                tile.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#f9f6f2"));
                tile.Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#f59563"));
            }
            else if (value == 32)
            {
                tile.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#f9f6f2"));
                tile.Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#f67c5f"));
            }
            else if (value == 64)
            {
                tile.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#f9f6f2"));
                tile.Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#f65e3b"));
            }
            else if (value >= 128 || value < 2048)
            {
                tile.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#f9f6f2"));
                tile.Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#edcc61"));
            }
            else if (value == 2048)
            {
                tile.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#f9f6f2"));
                tile.Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#aa60a6"));
            }
            else if (value > 2048 || value <= 8192)
            {
                tile.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#f9f6f2"));
                tile.Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#a80c0f"));
            }
            else if (value > 8192)
            {
                tile.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#f9f6f2"));
                tile.Background = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#aa60a6"));
            }
        }
    }
}
