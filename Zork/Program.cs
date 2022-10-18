using System;
using System.Collections.Generic;
using System.IO; 

namespace Zork
{
    class Program
    {
    private static Room CurrentRoom 
        {
            get 
            {
                return _rooms[_location.Row, _location.Column];
            }
        }
        static void Main()
        {
            string roomsFileName = "Rooms.txt";
            InitializeRoomDescription(roomsFileName);
            Console.WriteLine("Welcome To Zork!");

            Room previousRoom = null;

            bool isRunning = true;
            while (isRunning)
            {             
                if (previousRoom != CurrentRoom)
                {
                    Console.WriteLine(CurrentRoom.Description);
                    previousRoom = CurrentRoom;
                }
                Console.Write("> ");

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
                        outputString = CurrentRoom.Description;
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

        private static void InitializeRoomDescription(string roomsFileName)
        {
            var roomMap = new Dictionary<string, Room>();
            foreach (Room room in _rooms)
            {
                roomMap.Add(room.Name, room);
            }

            const string fieldDelimiter = "##";
            const int expectedFieldCount = 2;

            string[] lines = File.ReadAllLines(roomsFileName);
            foreach (string line in lines)
            {
                string[] fields = line.Split(fieldDelimiter);
                if (fields.Length != expectedFieldCount)
                {
                    throw new InvalidDataException("Invalid Record");
                }

                string name = fields[(int)Fields.Name];
                string description = fields[(int)Fields.Description];

                roomMap[name].Description = description; 
            }
        }

        private static Room[,] _rooms = 
            {
                { new Room("Rocky Trail"), new Room ("South of House"), new Room ("Canyon View") },
                { new Room ("Forest"), new Room ("West of House"), new Room("Behind House") },
                { new Room ("Dense Woods"), new Room ("North of House"), new Room ("Clearing")}
            };

        private static (int Row, int Column) _location = (1, 1); 

        private enum Fields
        {
            Name = 0,
            Description
        }
    }
}