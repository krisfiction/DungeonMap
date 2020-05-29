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
            map.CreateMap();
            map.MapDisplay();

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
