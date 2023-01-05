using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLconsole.Source
{
    public class Grid
    {
        public Cell[,] Cells { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
            Cells = new Cell[width, height];
        }

        public void Initialize()
        {
            var random = new Random();
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Cells[i, j] = new Cell(random.Next(2) == 0);
                }
            }
        }

        public void Update()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    var liveNeighbors = GetLiveNeighbors(i, j);
                    Cells[i, j].Update(liveNeighbors);
                }
            }
        }

        private int GetLiveNeighbors(int x, int y)
        {
            int liveNeighbors = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }

                    int neighborX = x + i;
                    int neighborY = y + j;
                    if (neighborX >= 0 && neighborX < Width && neighborY >= 0 && neighborY < Height)
                    {
                        if (Cells[neighborX, neighborY].IsAlive)
                        {
                            liveNeighbors++;
                        }
                    }
                }
            }
            return liveNeighbors;
        }

        public void NextState()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Cells[i, j].IsAlive = Cells[i, j].NextState;
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int j = 0; j < Height; j++)
            {
                for (int i = 0; i < Width; i++)
                {
                    sb.Append(Cells[i, j].IsAlive ? "O" : ".");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }
    }
}
