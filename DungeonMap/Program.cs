﻿using System;

namespace DungeonMap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(110, 36); //map will be 80, 25, giving 30 spaces on the side and 10 lines below
            Console.CursorVisible = false; //to hide the cursor

            Map map = new Map();
            map.Create();

            map.PlacePlayer();
            
            map.Display();

            StatBar();

            bool _keepPlaying = true;
            do
            {
                ConsoleKey aInput = Console.ReadKey().Key;
                if (aInput == ConsoleKey.UpArrow || aInput == ConsoleKey.NumPad8)
                {
                    map.MovePlayer("North");
                    map.Display();
                }
                if (aInput == ConsoleKey.DownArrow || aInput == ConsoleKey.NumPad2)
                {
                    map.MovePlayer("South");
                    map.Display();
                }
                if (aInput == ConsoleKey.RightArrow || aInput == ConsoleKey.NumPad6)
                {
                    map.MovePlayer("West");
                    map.Display();
                }
                if (aInput == ConsoleKey.LeftArrow || aInput == ConsoleKey.NumPad4)
                {
                    map.MovePlayer("East");
                    map.Display();
                }
                if (aInput == ConsoleKey.NumPad9)
                {
                    map.MovePlayer("NorthEast");
                    map.Display();
                }
                if (aInput == ConsoleKey.NumPad7)
                {
                    map.MovePlayer("NorthWest");
                    map.Display();
                }
                if (aInput == ConsoleKey.NumPad3)
                {
                    map.MovePlayer("SouthEast");
                    map.Display();
                }
                if (aInput == ConsoleKey.NumPad1)
                {
                    map.MovePlayer("SouthWest");
                    map.Display();
                }
            } while (_keepPlaying);

        }

        static void StatBar()
        {
            //stat bar, activity log
            Console.SetCursorPosition(0, 25);
            Console.WriteLine(("").PadRight(80, '*'));
            Console.WriteLine("Stat Bar / Activity Log Here");
            Console.WriteLine(("").PadRight(80, '*'));
            Console.WriteLine(("").PadRight(80, '*'));
            Console.WriteLine(("").PadRight(80, '*'));
            Console.WriteLine(("").PadRight(80, '*'));
            Console.WriteLine(("").PadRight(80, '*'));
            Console.WriteLine(("").PadRight(80, '*'));
            Console.WriteLine("10 lines of space to work with currently.");
            Console.WriteLine(("").PadRight(80, '*'));
            Console.ReadKey();
        }
    }
}
