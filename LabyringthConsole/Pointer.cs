using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyringthConsole
{
    internal class Pointer : Block
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Pointer() : base("H")
        {
            Color = ConsoleColor.Yellow;
        }
    }
}
