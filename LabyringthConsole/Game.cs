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
        private readonly Random _rnd = new Random();
        private readonly Map _map;
        private Pointer _pointer;
        private ConsoleKey _lastKeyPressed;
        private bool _quit = true;
        public Game(int width, int height)
        {
            _map = new Map(width, height);
        }

        internal void Run()
        {
            //init game
            _pointer = new Pointer();

            // game loop
            do
            {
                Console.Clear();
                PrintMap();

                // read input
                ConsoleKey key = GetInput();

                // process actions
                CheckKey(key);


            } while (_quit);

            // game over
        }


        private void CheckKey(ConsoleKey key)
        {
            switch (key)
            {
                case (ConsoleKey.DownArrow):
                    if (_pointer.Y < _map.Height - 1)
                    {
                        if (ConsoleKey.DownArrow == _lastKeyPressed)
                        {
                            _lastKeyPressed = key;
                            _pointer.Y -= 1;
                        }
                        else
                        {
                            _lastKeyPressed = ConsoleKey.UpArrow;
                        }
                        _pointer.Y += 1;
                    }
                    break;
                case (ConsoleKey.UpArrow):
                    if (_pointer.Y > 0)
                    {
                        if (ConsoleKey.UpArrow == _lastKeyPressed)
                        {
                            _lastKeyPressed = key;
                            _pointer.Y += 1;
                        }
                        else
                        {
                            _lastKeyPressed = ConsoleKey.DownArrow;
                        }
                        _pointer.Y -= 1;
                    }
                    break;
                case (ConsoleKey.LeftArrow):
                    if (_pointer.X > 0)
                    {
                        if (ConsoleKey.LeftArrow == _lastKeyPressed)
                        {
                            _lastKeyPressed = key;
                            _pointer.X += 1;
                        }
                        else
                        {
                            _lastKeyPressed = ConsoleKey.RightArrow;
                        }
                        _pointer.X -= 1;
                    }
                    break;
                case (ConsoleKey.RightArrow):
                    if (_pointer.X < _map.Width - 1)
                    {
                        if (ConsoleKey.RightArrow == _lastKeyPressed)
                        {
                            _lastKeyPressed = key;
                            _pointer.X -= 1;
                        }
                        else
                        {
                            _lastKeyPressed = ConsoleKey.LeftArrow;
                        }
                        _pointer.X += 1;
                    }
                    break;
                case ConsoleKey.Escape:
                    _quit = false;
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Please use arrow keys");
                    break;
            }

        }


        private ConsoleKey GetInput()
        {
            Console.WriteLine("\n\nPress arrowkeys to keep playing or \npress Esc for main menu");
            var keyInfo = Console.ReadKey(intercept: true);
            var key = keyInfo.Key;
            return key;
        }

        private void PrintMap()
        {
            Console.WriteLine("________________");
            for (int y = 0; y < _map.Height; y++)
            {
                //Console.BackgroundColor = ConsoleColor.Gray;

                Console.Write("|");
                for (int x = 0; x < _map.Width; x++)
                {
                    var cell = _map.Cells[x, y];
                    Console.Write(" ");

                    Block blockToMove = null;
                    if (_pointer.X == x && _pointer.Y == y)
                    {
                        blockToMove = _pointer;
                    }

                    else
                    {
                        Console.Write(_rnd.Next(1, 10));
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
