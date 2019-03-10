using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Map
    {
        public static char[,] LevelData { get; set; }
        private const int maxCountUnit = 35;
        public static int UnitsCount { get; private set; }
        public static Unit[] Units { get; private set; }
        public static int HeroIndex { get; private set; }

        public static void SetMap(int rowCounts, int columnCounts, char[,] levelDataInit)
        {
            Units = new Unit[maxCountUnit];
            LevelData = new char[rowCounts, columnCounts];
            SetData(rowCounts, columnCounts, levelDataInit);
        }

        private static void SetData(int rowCounts, int columnCounts, char[,] levelDataInit)
        {
            for (int row = 0; row < rowCounts; row++)
            {
                for (int column = 0; column < columnCounts; column++)
                {
                    char symbol = levelDataInit[row, column];
                    LevelData[row, column] = symbol;
                    if (symbol == Symbols.heroMapSymbol || symbol == Symbols.orgMapSymbol || symbol == Symbols.skeletonMapSymbol)
                    {
                        if (symbol == Symbols.heroMapSymbol)
                            HeroIndex = UnitsCount;

                        Units[UnitsCount] = new Unit(symbol, row, column);
                        UnitsCount++;
                    }
                }
            }
        }

        public static bool GetUnit(int row, int column, out Unit unit)
        {
            bool found = false;
            unit = null;
            for (int i = 0; i < UnitsCount; i++)
            {
                if (Units[i].Row == row && Units[i].Column == column)
                {
                    unit = Units[i];
                    found = true;
                    break;
                }
            }
            return found;
        }
    }
}
