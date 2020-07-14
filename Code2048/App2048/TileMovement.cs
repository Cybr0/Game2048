using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace App2048
{
    interface ITileMovement
    {
        int AddingScore { get; set; }
        void Move_Up();
        void Move_Down();
        void Move_Left();
        void Move_Right();

        void NewTile();
    }
    class TileMovement : ITileMovement
    {
        private int[,] tileControlMask;
        private TextBox[,] tiles;
        private int length;

        // this value need to show score in mainWindow
        private int score;

        public TileMovement(int[,] tileControlMask, TextBox[,] tiles)
        {
            this.tileControlMask = tileControlMask;
            this.tiles = tiles;
            length = Convert.ToInt32(Math.Sqrt(Convert.ToDouble(tileControlMask.Length)));
        }

        public int AddingScore { get { return score; } set { score = value; } }
        public void Move_Up()
        {
            bool[,] unionTiles = new bool[length, length];
            bool move = false;

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (tileControlMask[i, j] != 0 && i != 0)
                    {
                        int goToEnd = i;
                        while (tileControlMask[goToEnd - 1, j] == 0)
                        {

                            tiles[goToEnd - 1, j].Text = tiles[goToEnd, j].Text;
                            tileControlMask[goToEnd - 1, j] = tileControlMask[goToEnd, j];

                            tiles[goToEnd, j].Text = "";
                            tileControlMask[goToEnd, j] = 0;
                            move = true;
                            goToEnd--;
                            if (goToEnd == 0)
                            {
                                break;
                            }

                        }
                        if (goToEnd != 0 && tileControlMask[goToEnd, j] == tileControlMask[goToEnd - 1, j] && !unionTiles[goToEnd - 1, j])
                        {
                            tileControlMask[goToEnd - 1, j] += tileControlMask[goToEnd, j];
                            tileControlMask[goToEnd, j] = 0;

                            tiles[goToEnd, j].Text = "";
                            tiles[goToEnd - 1, j].Text = tileControlMask[goToEnd - 1, j].ToString();
                            unionTiles[goToEnd - 1, j] = true;
                            move = true;
                            score += tileControlMask[goToEnd - 1, j];
                        }
                    }

                }
            }
            if (move)
            {
                NewTile();
            }
        }

        public void Move_Down()
        {
            bool[,] unionTiles = new bool[length, length];
            bool move = false;

            for (int i = length - 1; i >= 0; i--)
            {
                for (int j = 0; j < length; j++)
                {
                    if (tileControlMask[i, j] != 0 && i != length - 1)
                    {
                        int goToEnd = i;
                        while (tileControlMask[goToEnd + 1, j] == 0)
                        {

                            tiles[goToEnd + 1, j].Text = tiles[goToEnd, j].Text;
                            tileControlMask[goToEnd + 1, j] = tileControlMask[goToEnd, j];

                            tiles[goToEnd, j].Text = "";
                            tileControlMask[goToEnd, j] = 0;
                            move = true;
                            goToEnd++;
                            if (goToEnd == length - 1)
                            {
                                break;
                            }

                        }
                        if (goToEnd != length - 1 && tileControlMask[goToEnd, j] == tileControlMask[goToEnd + 1, j] && !unionTiles[goToEnd + 1, j])
                        {
                            tileControlMask[goToEnd + 1, j] += tileControlMask[goToEnd, j];
                            tileControlMask[goToEnd, j] = 0;

                            tiles[goToEnd, j].Text = "";
                            tiles[goToEnd + 1, j].Text = tileControlMask[goToEnd + 1, j].ToString();
                            unionTiles[goToEnd + 1, j] = true;
                            move = true;
                            score += tileControlMask[goToEnd + 1, j];
                        }
                    }

                }
            }
            if (move)
            {
                NewTile();
            }
        }

        public void Move_Left()
        {
            bool[,] unionTiles = new bool[length, length];
            bool move = false;

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (tileControlMask[i, j] != 0 && j != 0)
                    {
                        int goToEnd = j;
                        while (tileControlMask[i, goToEnd - 1] == 0)
                        {

                            tiles[i, goToEnd - 1].Text = tiles[i, goToEnd].Text;
                            tileControlMask[i, goToEnd - 1] = tileControlMask[i, goToEnd];

                            tiles[i, goToEnd].Text = "";
                            tileControlMask[i, goToEnd] = 0;
                            move = true;
                            goToEnd--;
                            if (goToEnd == 0)
                            {
                                break;
                            }
                        }
                        if (goToEnd != 0 && tileControlMask[i, goToEnd] == tileControlMask[i, goToEnd - 1] && !unionTiles[i, goToEnd - 1])
                        {
                            tileControlMask[i, goToEnd - 1] += tileControlMask[i, goToEnd];
                            tileControlMask[i, goToEnd] = 0;

                            tiles[i, goToEnd].Text = "";
                            tiles[i, goToEnd - 1].Text = tileControlMask[i, goToEnd - 1].ToString();
                            unionTiles[i, goToEnd - 1] = true;
                            move = true;
                            score += tileControlMask[i, goToEnd - 1];
                        }
                    }

                }
            }
            if (move)
            {
                NewTile();
            }
        }

        public void Move_Right()
        {
            bool[,] unionTiles = new bool[length, length];
            bool move = false;
            for (int i = 0; i < length; i++)
            {
                for (int j = length - 1; j >= 0; j--)
                {
                    if (tileControlMask[i, j] != 0 && j != length - 1)
                    {
                        int goToEnd = j;
                        while (tileControlMask[i, goToEnd + 1] == 0)
                        {

                            tiles[i, goToEnd + 1].Text = tiles[i, goToEnd].Text;
                            tileControlMask[i, goToEnd + 1] = tileControlMask[i, goToEnd];

                            tiles[i, goToEnd].Text = "";
                            tileControlMask[i, goToEnd] = 0;
                            move = true;
                            goToEnd++;
                            if (goToEnd == length - 1)
                            {
                                break;
                            }
                        }
                        if (goToEnd != length - 1 && tileControlMask[i, goToEnd] == tileControlMask[i, goToEnd + 1] && !unionTiles[i, goToEnd + 1])
                        {
                            tileControlMask[i, goToEnd + 1] += tileControlMask[i, goToEnd];
                            tileControlMask[i, goToEnd] = 0;

                            tiles[i, goToEnd].Text = "";
                            tiles[i, goToEnd + 1].Text = tileControlMask[i, goToEnd + 1].ToString();
                            unionTiles[i, goToEnd + 1] = true;
                            move = true;
                            score += tileControlMask[i, goToEnd + 1];
                        }
                    }

                }
            }
            if (move)
            {
                NewTile();
            }  
        }

        public void NewTile()
        {
            int randValue = new Random().Next(0, 10);
            int tile;
            if(randValue < 8)
            {
                tile = 2;
            }
            else
            {
                tile = 4;
            }

            bool check = true;
            while (check)
            {

                int i = new Random().Next(0, length);
                int j = new Random().Next(0, length);
                if (tileControlMask[i, j] == 0)
                {
                    tiles[i, j].Text = tile.ToString();
                    tileControlMask[i, j] = tile;
                    check = false;
                }
            }


        }
    }
}
