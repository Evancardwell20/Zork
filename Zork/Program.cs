using System;
using System.ComponentModel.Design;
using System.Linq;

namespace Zork
{
    class Program
    {
        private static string CurrentRoom 
        {
            get 
            {
                return _rooms[_location.Row, _location.Column];
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Zork!");

            bool isRunning = true;
            while (isRunning)
            {
                Console.Write($"{CurrentRoom} \n> ");

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
                case Commands.NORTH when _location.Row < _rooms.GetLength(0) - 1:
                    _location.Row++;
                    didMove = true;
                    break;

                case Commands.SOUTH when _location.Row > 0:
                    _location.Row--;
                    didMove = true;
                    break;

                case Commands.EAST when _location.Column < _rooms.GetLength(1) - 1:
                    _location.Column++;
                    didMove = true;
                    break;

                case Commands.WEST when _location.Column > 0:
                    _location.Column--;
                    didMove = true;
                    break;
            }
            
            return didMove; 
        }

        private static string[,] _rooms = 
            {
                {"Rocky Trail", "South of House", "Canyon View" },
                {"Forest", "West of House", "Behind House" },
                {"Dense Woods", "North of House", "Clearing" }
            };

        private static (int Row, int Column) _location = (1, 1); 
    }
}