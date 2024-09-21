using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntHill.Creatures
{
    public class World
    {
        public const int Width = 20;
        public const int Height = 20;
        public char[,] Grid { get; set; }

        public World() 
        {
            Grid = new char[Height, Width];

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Grid[i, j] = '.';
                }    
            }    
        }
        public void UpdatePosition(int oldX, int oldY, int newX, int newY, char symbol)
        {
            lock (this)
            {
                Grid[oldY, oldX] = '.';  
                Grid[newY, newX] = symbol;  
            }
        }


        
        public static bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }

        public void Display()
        {
            lock (this)
            {
                Console.Clear();
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        Console.Write(Grid[i, j]);
                    }
                    Console.WriteLine();
                }
            }
        }

    }
}
