using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyringthConsole
{
    internal class Game
    {
        private int _totalPoint = 0;
        private int _temp = 0;
        readonly Random rnd = new Random();
        private readonly Map map;
        private Pointer _pointer;
        private string log = "";

        public Game(int width, int height)
        {

            map = new Map(width, height);
        }

        internal void Run()
        {
            bool quit = true;
            //init game
            _pointer = new Pointer();
            //PopulateMap();




            // game loop
            do
            {
                Console.Clear();
                PrintMap();

                // read input
                ConsoleKey key = GetInput();


                // process actions
                switch (key)
                {
                    case (ConsoleKey.DownArrow):
                        if (_pointer.Y < map.Height - 1) _pointer.Y += 1;
                        break;
                    case (ConsoleKey.UpArrow):
                        if (_pointer.Y > 0) _pointer.Y -= 1;
                        break;
                    case (ConsoleKey.LeftArrow):
                        if (_pointer.X > 0) _pointer.X -= 1;
                        break;
                    case (ConsoleKey.RightArrow):
                        if (_pointer.X < map.Width - 1) _pointer.X += 1;
                        break;
                    case ConsoleKey.Escape:
                        quit = false;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Please use arrow keys");
                        break;
                }


            } while (quit);

            // game over
        }


        private ConsoleKey GetInput()
        {
            Console.WriteLine("\n\nPress arrowkeys to keep playing or \npress escape for main menu");
            var keyInfo = Console.ReadKey(intercept: true);
            var key = keyInfo.Key;
            return key;
        }

        private void PrintMap()
        {
            Console.WriteLine("________________");
            for (int y = 0; y < map.Height; y++)
            {
                Console.Write("|");
                for (int x = 0; x < map.Width; x++)
                {
                    var cell = map.Cells[x, y];
                    Console.Write(" ");

                    Block blockToMove = null;
                    if (_pointer.X == x && _pointer.Y == y)
                    {
                        blockToMove = _pointer;
                    }

                    else
                    {
                        Console.Write(rnd.Next(1, 9));
                    }
                    if (blockToMove != null)
                    {
                        Console.ForegroundColor = blockToMove.Color;
                        Console.Write(blockToMove.MapSymbol);
                        Console.ResetColor();
                    }
                    Console.Write("|");
                }
                Console.WriteLine();
            }
            Console.Write("________________");
            Console.WriteLine("\nYour total score {0}", _totalPoint);
        }
    }
}
