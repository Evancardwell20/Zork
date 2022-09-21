using System;
using System.Collections.Generic;

namespace Zork
{
    class Program
    {
        static void Main()
        {
            //InitializeRoomDescription();
            Console.WriteLine("Welcome To Zork!");

            Game game = new Game();
            game.Run();

            //    Room previousRoom = null;

            //    bool isRunning = true;
            //    while (isRunning)
            //    {             
            //        if (previousRoom != CurrentRoom)
            //        {
            //            Console.WriteLine(CurrentRoom.Description);
            //            previousRoom = CurrentRoom;
            //        }
            //        Console.Write("> ");

            //        string inputString = Console.ReadLine().Trim();
            //        Commands command = ToCommand(inputString);

            //        string outputString;
            //        switch (command)
            //        {
            //            case Commands.QUIT:
            //                isRunning = false;
            //                outputString = "Thank you for playing!";
            //                break;

            //            case Commands.LOOK:
            //                outputString = CurrentRoom.Description;
            //                break;

            //            case Commands.NORTH:
            //            case Commands.SOUTH:
            //            case Commands.EAST:
            //            case Commands.WEST:
            //                if (Move(command))
            //                {
            //                    outputString = $"You moved {command}.";
            //                }

            //                else
            //                {
            //                    outputString = $"The way is shut."; 
            //                }
            //                break; 

            //            default:
            //                outputString = "Unknown Command";
            //                break;
            //        }

            //        Console.WriteLine(outputString);
            //    }
        }
    }
}