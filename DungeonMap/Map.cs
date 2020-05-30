using System;

namespace DungeonMap
{
    public class Map
    {
        string Wall_X = "-";
        string Wall_Y = "|";
        string Floor = ".";

        string[,] GameMap = new string[80, 25];

        public void Display()
        {
            for (int x = 0; x <= 79; x++)
            {
                for (int y = 0; y <= 24; y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(GameMap[x, y]);
                }
            }
        }

        public void Create()
        {
            Random random = new Random();

            int RoomHeight = random.Next(6, 10);
            int RoomWidth = random.Next(7, 10);
            int RoomPOSX = random.Next(0, 79 - RoomWidth - 1);
            int RoomPOSY = random.Next(0, 24 - RoomHeight - 1);

            for (int y = 0; y <= RoomHeight; y++)
            {
                for (int x = 0; x <= RoomWidth; x++)
                {
                    if (y == 0 || y == RoomHeight)
                    {
                        GameMap[RoomPOSX + x, RoomPOSY + y] = Wall_X;
                    }
                    else if (x == 0 || x == RoomWidth)
                    {
                        GameMap[RoomPOSX + x, RoomPOSY + y] = Wall_Y;
                    }
                    else
                    {
                        GameMap[RoomPOSX + x, RoomPOSY + y] = Floor;
                    }

                }
            }
        }

    }
}
