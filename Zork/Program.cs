﻿using System;

namespace Zork
{
    public class Program
    {
        static void Main(string[] args)
        {
            const string defaultFileName = "Zork.json";
            string gameFilename = (args.Length > 0 ? args[(int)CommandLineArguments.GameFilename] : defaultFileName);

            Game game = Game.Load(gameFilename);
            Console.WriteLine("Welcome to Zork!");

            game.Run();
            Console.WriteLine("Thank you for playing!");
        }

        private enum CommandLineArguments
        {
            GameFilename = 0
        }
    }
}