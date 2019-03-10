using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    enum Direction
    {
        left,
        right,
        up,
        down
    }

    class Program
    {
        static readonly char[,] levelDataInit = {
            { '#', '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#' },
            { '#', ' ',' ',' ','#',' ','#','#',' ',' ',' ',' ',' ',' ','o',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','s',' ',' ',' ',' ',' ',' ',' ','#' },
            { '#', ' ','#',' ','o',' ',' ','#','o','#','#','#','#','#','#','#','#','#','#','#','#','#','#',' ','#','#','#','#','#','#','#','#','#',' ','#' },
            { '#', ' ','#','#','#','#','#','#',' ','#',' ',' ',' ','#',' ','#','3',' ',' ','s',' ',' ','#',' ','#','#','s','#','#',' ',' ',' ','#',' ','#' },
            { '#', ' ',' ','s',' ',' ',' ',' ',' ',' ',' ','#',' ','#',' ','#','#','#','#','#','#',' ','#',' ','#','s','4',' ',' ',' ','#','s','#',' ','#' },
            { '#', '#','#','#','#','#',' ','#',' ','#','#','#',' ','#',' ',' ',' ',' ',' ',' ','#',' ','#',' ','#','#','s','#','#',' ',' ',' ','#',' ','#' },
            { '#', '#',' ',' ','o','#',' ','#',' ','#',' ','#',' ','#','#','#','#',' ','#',' ','#',' ',' ',' ','#','#','#','#','#',' ','#',' ','#',' ','#' },
            { '#', ' ',' ','#',' ',' ',' ','#',' ','#',' ','o',' ',' ',' ',' ','#',' ','#','#',' ','#','#','#','#','#','#',' ','#',' ',' ',' ','#',' ','#' },
            { '#', '#','#','#','#','#','#','#',' ','#',' ','#','#','#','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ','s','#',' ','#',' ','#','s','#' },
            { '#', ' ',' ','2','#',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#','#','#','#','#','#','#',' ','#',' ','#',' ','#',' ',' ',' ','#',' ','#' },
            { '#', ' ','#','#','#',' ','#','#','#','#',' ','#','#','#','#','#','#',' ',' ',' ','o',' ',' ',' ','#',' ','#',' ',' ',' ','#',' ',' ',' ','#' },
            { '#', ' ',' ','o',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#','#','#','#','#','#','#',' ','#','#','#','#','#','#','#','#','#' },
            { '#', '#','#','#','#','#','#','#','#','#','#','#',' ','#','#','#','#','#','#',' ',' ',' ','#','1','#',' ','#',' ','s',' ','#',' ',' ',' ','#' },
            { '#', 'h',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ','#',' ',' ',' ','#','s',' ',' ','#',' ','#' },
            { '#', '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','e','#' }
        };
        
        static void Main(string[] args)
        {
            Initialize();

            while (true)
            {
                Render();
                Update();
            }
            Console.Read();
        }

        const int rowCounts = 15;
        const int columnCounts = 35;

        static Unit Hero;
        static void Initialize()
        {
            Map.SetMap(rowCounts, columnCounts, levelDataInit);
            int heroIndex = Map.HeroIndex;
            Hero = Map.Units[heroIndex];
        }

        static void Render()
        {
            Console.SetCursorPosition(0, 0);
            for (int row = 0; row < rowCounts; row++)
            {
                for (int column = 0; column < columnCounts; column++)
                {
                    char sym = Symbols.GetRenderSymbol(Map.LevelData[row, column]);
                    ConsoleColor color = Symbols.GetRenderColor(Map.LevelData[row, column]);
                    Console.ForegroundColor = color;
                    Console.Write(sym);
                }
                Console.WriteLine();
            }
        }

        public static void Update()
        {
            Console.CursorVisible = false;

            Direction direction = 0;
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.LeftArrow)
                    direction = Direction.left;
                else if (key.Key == ConsoleKey.RightArrow)
                    direction = Direction.right;
                else if (key.Key == ConsoleKey.UpArrow)
                    direction = Direction.up;
                else if (key.Key == ConsoleKey.DownArrow)
                    direction = Direction.down;

                MoveHero(1, direction);
            }
        }

        static void MoveHero(int offset, Direction direction)
        {
            int nextRow = Hero.Row;
            int nextColumn = Hero.Column;

            switch (direction)
            {
                case Direction.left:
                    nextColumn -= offset;
                    break;
                case Direction.right:
                    nextColumn += offset;
                    break;
                case Direction.up:
                    nextRow -= offset;
                    break;
                case Direction.down:
                    nextRow += offset;
                    break;
                default:
                    break;
            }
            Hero.MoveUnit(ref Map.LevelData[Hero.Row, Hero.Column], ref Map.LevelData[nextRow, nextColumn], nextRow, nextColumn);
        }
    }
}
