using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    struct Symbols
    {
        public static readonly char emptySymbol = ' ';
        public static readonly char heroSymbol = EncodingChar(2);
        public static readonly char wallSymbol = EncodingChar(177);
        public static readonly char skeletonSymbol = EncodingChar(2);
        public static readonly char orgSymbol = EncodingChar(2);

        public static readonly char fistChar = ' ';
        public static readonly char stickChar = EncodingChar(47);
        public static readonly char clubChar = EncodingChar(33);
        public static readonly char spearChar = EncodingChar(24);
        public static readonly char saberChar = EncodingChar(108);

        public static readonly char heroMapSymbol = 'h';
        public static readonly char orgMapSymbol = 'o';
        public static readonly char skeletonMapSymbol = 's';

        public static readonly char stickMapChar = '1';
        public static readonly char clubMapChar = '2';
        public static readonly char spearMapChar = '3';
        public static readonly char saberMapChar = '4';

        private static char EncodingChar(byte numberSym)
        {
            Encoding encoder = Encoding.GetEncoding(437);
            byte[] sym = { numberSym };
            var symbol = encoder.GetString(sym)[0];
            return symbol;
        }

        public static char GetRenderSymbol(char symbol)
        {
            char sym = ' ';
            switch (symbol)
            {
                case '#':
                    sym = wallSymbol;
                    break;
                case 'h':
                    sym = heroSymbol;
                    break;
                case 'o':
                    sym = orgSymbol;
                    break;
                case 's':
                    sym = skeletonSymbol;
                    break;
                case '1':
                    sym = stickChar;
                    break;
                case '2':
                    sym = clubChar;
                    break;
                case '3':
                    sym = spearChar;
                    break;
                case '4':
                    sym = saberChar;
                    break;
                default:
                    sym = symbol;
                    break;
            }
            return sym;
        }

        public static ConsoleColor GetRenderColor(char symbol)
        {
            ConsoleColor Color = ConsoleColor.White;
            switch (symbol)
            {
                case '#':
                    Color = ConsoleColor.White;
                    break;
                case 'h':
                    Color = ConsoleColor.Yellow;
                    break;
                case 'o':
                    Color = ConsoleColor.Green;
                    break;
                case 's':
                    Color = ConsoleColor.White;
                    break;
                case '1':
                    Color = ConsoleColor.DarkYellow;
                    break;
                case '2':
                    Color = ConsoleColor.DarkRed;
                    break;
                case '3':
                    Color = ConsoleColor.DarkCyan;
                    break;
                case '4':
                    Color = ConsoleColor.Cyan;
                    break;
                default:
                    Color = ConsoleColor.Black;
                    break;
            }

            return Color;
        }

        public static char GetMapUnitSymbol(UnitType unit)
        {
            char unitChar = ' ';
            switch (unit)
            {
                case UnitType.Hero:
                    unitChar = heroMapSymbol;
                    break;
                case UnitType.Org:
                    unitChar = orgMapSymbol;
                    break;
                case UnitType.Skeleton:
                    unitChar = skeletonMapSymbol;
                    break;
                default:
                    unitChar = emptySymbol;
                    break;
            }

            return unitChar;
        }
    }
}
