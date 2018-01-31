using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyringthConsole
{
    internal class Block
    {
        public string MapSymbol { get; }
        public ConsoleColor Color { get; protected set; }

        public Block(string mapSymbol)
        {
            MapSymbol = mapSymbol;
        }
    }
}
