using System;

namespace DungeonMap
{
    public class Map
    {
        private readonly string Wall_X = "-";
        private readonly string Wall_Y = "|";
        private readonly string Floor = ".";

        private int PlayerPOSX { get; set; }
        private int PlayerPOSY { get; set; }

        public string[,] GameMap = new string[80, 25];

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

        public void MovePlayer(string _direction)
        {
            if (_direction == "North")
            {
                if (GameMap[PlayerPOSX, PlayerPOSY - 1] != "-")
                {
                    GameMap[PlayerPOSX, PlayerPOSY - 1] = "@";
                    GameMap[PlayerPOSX, PlayerPOSY] = ".";
                    PlayerPOSY--;
                    Console.SetCursorPosition(80, 0);
                    Console.WriteLine($"Player Position: X{PlayerPOSX}, Y{PlayerPOSY}");
                }
            }
            if (_direction == "South")
            {
                if (GameMap[PlayerPOSX, PlayerPOSY + 1] != "-")
                {
                    GameMap[PlayerPOSX, PlayerPOSY + 1] = "@";
                    GameMap[PlayerPOSX, PlayerPOSY] = ".";
                    PlayerPOSY++;
                    Console.SetCursorPosition(80, 0);
                    Console.WriteLine($"Player Position: X{PlayerPOSX}, Y{PlayerPOSY}");
                }
            }
            if (_direction == "West")
            {
                if (GameMap[PlayerPOSX + 1, PlayerPOSY] != "|")
                {
                    GameMap[PlayerPOSX + 1, PlayerPOSY] = "@";
                    GameMap[PlayerPOSX, PlayerPOSY] = ".";
                    PlayerPOSX++;
                    Console.SetCursorPosition(80, 0);
                    Console.WriteLine($"Player Position: X{PlayerPOSX}, Y{PlayerPOSY}");
                }
            }
            if (_direction == "East")
            {
                if (GameMap[PlayerPOSX - 1, PlayerPOSY] != "|")
                {
                    GameMap[PlayerPOSX - 1, PlayerPOSY] = "@";
                    GameMap[PlayerPOSX, PlayerPOSY] = ".";
                    PlayerPOSX--;
                    Console.SetCursorPosition(80, 0);
                    Console.WriteLine($"Player Position: X{PlayerPOSX}, Y{PlayerPOSY}");
                }
            }
            if (_direction == "NorthWest")
            {
                if (GameMap[PlayerPOSX - 1, PlayerPOSY - 1] != "|" && GameMap[PlayerPOSX - 1, PlayerPOSY - 1] != "-")
                {
                    GameMap[PlayerPOSX - 1, PlayerPOSY - 1] = "@";
                    GameMap[PlayerPOSX, PlayerPOSY] = ".";
                    PlayerPOSX--;
                    PlayerPOSY--;
                    Console.SetCursorPosition(80, 0);
                    Console.WriteLine($"Player Position: X{PlayerPOSX}, Y{PlayerPOSY}");
                }
            }
            if (_direction == "NorthEast")
            {
                if (GameMap[PlayerPOSX + 1, PlayerPOSY - 1] != "|" && GameMap[PlayerPOSX + 1, PlayerPOSY - 1] != "-")
                {
                    GameMap[PlayerPOSX + 1, PlayerPOSY - 1] = "@";
                    GameMap[PlayerPOSX, PlayerPOSY] = ".";
                    PlayerPOSX++;
                    PlayerPOSY--;
                    Console.SetCursorPosition(80, 0);
                    Console.WriteLine($"Player Position: X{PlayerPOSX}, Y{PlayerPOSY}");
                }
            }
            if (_direction == "SouthWest")
            {
                if (GameMap[PlayerPOSX - 1, PlayerPOSY + 1] != "|" && GameMap[PlayerPOSX - 1, PlayerPOSY + 1] != "-")
                {
                    GameMap[PlayerPOSX - 1, PlayerPOSY + 1] = "@";
                    GameMap[PlayerPOSX, PlayerPOSY] = ".";
                    PlayerPOSX--;
                    PlayerPOSY++;
                    Console.SetCursorPosition(80, 0);
                    Console.WriteLine($"Player Position: X{PlayerPOSX}, Y{PlayerPOSY}");
                }
            }
            if (_direction == "SouthEast")
            {
                if (GameMap[PlayerPOSX + 1, PlayerPOSY + 1] != "|" && GameMap[PlayerPOSX + 1, PlayerPOSY + 1] != "-")
                {
                    GameMap[PlayerPOSX + 1, PlayerPOSY + 1] = "@";
                    GameMap[PlayerPOSX, PlayerPOSY] = ".";
                    PlayerPOSX++;
                    PlayerPOSY++;
                    Console.SetCursorPosition(80, 0);
                    Console.WriteLine($"Player Position: X{PlayerPOSX}, Y{PlayerPOSY}");
                }
            }
        }

        public void PlacePlayer()
        {
            int _placed = 0;

            for (int x = 0; x <= 79; x++)
            {
                for (int y = 0; y <= 24; y++)
                {
                    if (GameMap[x, y] == "." && _placed == 0)
                    {
                        GameMap[x, y] = "@";
                        PlayerPOSX = x;
                        PlayerPOSY = y;
                        _placed = 1;
                        Console.SetCursorPosition(80, 0);
                        Console.WriteLine($"Player Position: X{ x}, Y{y}");
                    }
                }
            }
        }

        public void Create()
        {
            Random random = new Random();

            int RoomHeight = random.Next(4, 6);
            int RoomWidth = random.Next(8, 24);
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
