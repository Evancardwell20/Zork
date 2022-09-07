﻿using System;
using System.ComponentModel.Design;
using System.Linq;

namespace Zork
{
    class Program
    {
       static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Zork!");

            bool isRunning = true;
            while (isRunning)
            {
                Console.Write($"{_rooms[_currentRoom]} \n> ");

                string inputString = Console.ReadLine().Trim();
                Commands command = ToCommand(inputString);

                string outputString;
                switch (command)
                {
                    case Commands.QUIT:
                        isRunning = false;
                        outputString = "Thank you for playing!";
                        break;

                    case Commands.LOOK:
                        outputString = "This is an open field west of a white house, with a boarded front door.\nA rubber mat saying 'Welcome to Zork!' lies by the door.";
                        break;

                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        if (Move(command))
                        {
                            outputString = $"You moved {command}.";
                        }

                        else
                        {
                            outputString = $"The way is shut."; 
                        }
                        
                        outputString = $"You moved {command}.";
                        break;

                    default:
                        outputString = "Unknown Command";
                        break;
                }

                Console.WriteLine(outputString);
            }
        }
        private static Commands ToCommand(string commandString) => Enum.TryParse<Commands>(commandString, ignoreCase: true, out Commands result) ? result : Commands.UNKNOWN;

        private static bool Move(Commands command)
        {
            bool didMove = false;

            switch (command)
            {
                case Commands.NORTH:
                case Commands.SOUTH:
                    break;

                case Commands.EAST when _currentRoom < _rooms.Length - 1:
                    _currentRoom++;
                    didMove = true;
                    break;

                case Commands.WEST when _currentRoom > _rooms.Length - 1:
                    _currentRoom--;
                    didMove = true;
                    break;
            }
            
            return didMove; 
        }

        private static string[] _rooms = { "Forest", "West of House", "Behind House", "Clearing", "Canyon View" };
        private static int _currentRoom = 1; 
    }
}