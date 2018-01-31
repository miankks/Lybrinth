using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LabyringthConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.BackgroundColor = ConsoleColor.Gray;
            Game game = new Game(width: 5, height: 5);
            bool quit = true;

            Console.WriteLine("Welcome to the Lybrinth game!");
            while (quit)
            {
                int enterDigit = AskForInt("Press 1 to play or 2 to quit: ");

                if (enterDigit == 1)
                {
                    game.Run();
                }
                else if (enterDigit == 2)
                {
                    quit = false;
                }

            }
        }

        private static int AskForInt(string question)
        {

            int value;
            bool parsed;
            string error = "";
            do
            {
                string input = AskForString(question + error);
                parsed = int.TryParse(input, out value);
                error = "";
            } while (!parsed); //(parsed == false)

            return value;
        }

        private static string AskForString(string question)
        {
            Console.Write(question);
            return Console.ReadLine();
        }
    }
}
