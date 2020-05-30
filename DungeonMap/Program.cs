using System;

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
                if (aInput == ConsoleKey.RightArrow)
                {
                    map.MovePlayer("Right");
                    map.Display();
                }
                if (aInput == ConsoleKey.LeftArrow)
                {
                    map.MovePlayer("Left");
                    map.Display();
                }
                if (aInput == ConsoleKey.UpArrow)
                {
                    map.MovePlayer("Up");
                    map.Display();
                }
                if (aInput == ConsoleKey.DownArrow)
                {
                    map.MovePlayer("Down");
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
