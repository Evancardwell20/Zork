using System;
using System.Collections.Generic;

namespace Zork
{
    internal class Game
    {
        public World World { get; set; }

        public Player Player { get; set; }

        public void Run()
        {
            Room previousRoom = null;

            bool isRunning = true;
            while (isRunning)
            {
                if (previousRoom != Player.CurrentRoom)
                {
                    Console.WriteLine(Player.CurrentRoom.Description);
                    previousRoom = Player.CurrentRoom;
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
                        outputString = Player.CurrentRoom.Description;
                        break;

                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        if (Player.Move(command))
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
        private void InitializeRoomDescription()
        {
            var roomMap = new Dictionary<string, Room>();
            foreach (Room room in World.Room)
            {
                roomMap.Add(room.Name, room);
            }

            roomMap["Rocky Trail"].Description = "You are on a rock-strewn trail.";
            roomMap["South of House"].Description = "You are facing the south side of a white house.";
            roomMap["Canyon View"].Description = "You are at the top of the Great Canyon on its south wall";

            roomMap["Forest"].Description = "This is a forest, with trees in all directions.";
            roomMap["West of House"].Description = "This is an open field west of a white house, with a boarded front door.";
            roomMap["Behind House"].Description = "You are behind the white house. In one corner of the house there is a small window which is slightly ajar.";

            roomMap["Dense Woods"].Description = "This is a dimly lit forest, with large trees all around. To the east, there appears to be sunlight";
            roomMap["North of House"].Description = "You are facing the north side of a white house. There is no door here, and all the windows are barred.";
            roomMap["Clearing"].Description = "You are in a clearing, with a forest surrounding you on the west and south";
        }
        private static Commands ToCommand(string commandString) => Enum.TryParse<Commands>(commandString, ignoreCase: true, out Commands result) ? result : Commands.UNKNOWN;
    }
}
