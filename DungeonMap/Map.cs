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
        private readonly string PlayerIcon = "@";

        private const int MapSizeX = 110;
        private const int MapSizeY = 35;

        public string[,] GameMap = new string[MapSizeX, MapSizeY];

        private int RoomNumber = 1;

        public void Display()
        {
            for (int x = 0; x <= MapSizeX - 1; x++)
            {
                for (int y = 0; y <= MapSizeY - 1; y++)
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
                if (GameMap[PlayerPOSX, PlayerPOSY - 1] != Wall_X && GameMap[PlayerPOSX, PlayerPOSY - 1] != Wall_Y)
                {
                    GameMap[PlayerPOSX, PlayerPOSY - 1] = PlayerIcon;
                    GameMap[PlayerPOSX, PlayerPOSY] = Floor;
                    PlayerPOSY--;
                    DisplayPlayerPosition(PlayerPOSX, PlayerPOSY);
                }
            }
            if (_direction == "South")
            {
                if (GameMap[PlayerPOSX, PlayerPOSY + 1] != Wall_X && GameMap[PlayerPOSX, PlayerPOSY + 1] != Wall_Y)
                {
                    GameMap[PlayerPOSX, PlayerPOSY + 1] = PlayerIcon;
                    GameMap[PlayerPOSX, PlayerPOSY] = Floor;
                    PlayerPOSY++;
                    DisplayPlayerPosition(PlayerPOSX, PlayerPOSY);
                }
            }
            if (_direction == "West")
            {
                if (GameMap[PlayerPOSX + 1, PlayerPOSY] != Wall_Y && GameMap[PlayerPOSX + 1, PlayerPOSY] != Wall_X)
                {
                    GameMap[PlayerPOSX + 1, PlayerPOSY] = PlayerIcon;
                    GameMap[PlayerPOSX, PlayerPOSY] = Floor;
                    PlayerPOSX++;
                    DisplayPlayerPosition(PlayerPOSX, PlayerPOSY);
                }
            }
            if (_direction == "East")
            {
                if (GameMap[PlayerPOSX - 1, PlayerPOSY] != Wall_Y && GameMap[PlayerPOSX - 1, PlayerPOSY] != Wall_X)
                {
                    GameMap[PlayerPOSX - 1, PlayerPOSY] = PlayerIcon;
                    GameMap[PlayerPOSX, PlayerPOSY] = Floor;
                    PlayerPOSX--;
                    DisplayPlayerPosition(PlayerPOSX, PlayerPOSY);
                }
            }
            if (_direction == "NorthWest")
            {
                if (GameMap[PlayerPOSX - 1, PlayerPOSY - 1] != Wall_Y && GameMap[PlayerPOSX - 1, PlayerPOSY - 1] != Wall_X)
                {
                    GameMap[PlayerPOSX - 1, PlayerPOSY - 1] = PlayerIcon;
                    GameMap[PlayerPOSX, PlayerPOSY] = Floor;
                    PlayerPOSX--;
                    PlayerPOSY--;
                    DisplayPlayerPosition(PlayerPOSX, PlayerPOSY);
                }
            }
            if (_direction == "NorthEast")
            {
                if (GameMap[PlayerPOSX + 1, PlayerPOSY - 1] != Wall_Y && GameMap[PlayerPOSX + 1, PlayerPOSY - 1] != Wall_X)
                {
                    GameMap[PlayerPOSX + 1, PlayerPOSY - 1] = PlayerIcon;
                    GameMap[PlayerPOSX, PlayerPOSY] = Floor;
                    PlayerPOSX++;
                    PlayerPOSY--;
                    DisplayPlayerPosition(PlayerPOSX, PlayerPOSY);
                }
            }
            if (_direction == "SouthWest")
            {
                if (GameMap[PlayerPOSX - 1, PlayerPOSY + 1] != Wall_Y && GameMap[PlayerPOSX - 1, PlayerPOSY + 1] != Wall_X)
                {
                    GameMap[PlayerPOSX - 1, PlayerPOSY + 1] = PlayerIcon;
                    GameMap[PlayerPOSX, PlayerPOSY] = Floor;
                    PlayerPOSX--;
                    PlayerPOSY++;
                    DisplayPlayerPosition(PlayerPOSX, PlayerPOSY);
                }
            }
            if (_direction == "SouthEast")
            {
                if (GameMap[PlayerPOSX + 1, PlayerPOSY + 1] != Wall_Y && GameMap[PlayerPOSX + 1, PlayerPOSY + 1] != Wall_X)
                {
                    GameMap[PlayerPOSX + 1, PlayerPOSY + 1] = PlayerIcon;
                    GameMap[PlayerPOSX, PlayerPOSY] = Floor;
                    PlayerPOSX++;
                    PlayerPOSY++;
                    DisplayPlayerPosition(PlayerPOSX, PlayerPOSY);
                }
            }
        }

        public void PlacePlayer()
        {
            int _placed = 0;

            for (int x = 0; x <= MapSizeX - 1; x++)
            {
                for (int y = 0; y <= MapSizeY - 1; y++)
                {
                    if (GameMap[x, y] == Floor && _placed == 0)
                    {
                        GameMap[x, y] = PlayerIcon;
                        PlayerPOSX = x;
                        PlayerPOSY = y;
                        _placed = 1;
                        DisplayPlayerPosition(PlayerPOSX, PlayerPOSY);
                    }
                }
            }
        }

        public void DisplayPlayerPosition(int _x, int _y)
        {
            Console.SetCursorPosition(110, 0);
            Console.WriteLine($"Player Position: x{ _x}, y{_y}");
        }

        public void CreateRoom()
        {
            Random random = new Random();

            int RoomHeight = random.Next(3, 10);
            int RoomWidth = random.Next(3, 35);

            int RoomPOSX = random.Next(0, MapSizeX - 1 - RoomWidth);
            int RoomPOSY = random.Next(0, MapSizeY - 1 - RoomHeight);

            DisplayRoomInfo(RoomWidth, RoomHeight, RoomPOSX, RoomPOSY);

            for (int y = 0; y <= RoomHeight; y++)
            {
                for (int x = 0; x <= RoomWidth; x++)
                {
                    if (y == 0 || y == RoomHeight)
                    {
                        if (y == 0 && x == 0) // testing - to number each room
                        {
                            GameMap[RoomPOSX + x, RoomPOSY + y] = RoomNumber.ToString();
                        }
                        else
                        {
                            GameMap[RoomPOSX + x, RoomPOSY + y] = Wall_X;
                        }
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
            RoomNumber++;
        }

        public void DisplayRoomInfo(int RoomWidth, int RoomHeight, int RoomPOSX, int RoomPOSY)
        {
            if (RoomNumber == 1)
            {
                Console.SetCursorPosition(110, 2);
                Console.WriteLine($"Room {RoomNumber} Location: x{RoomPOSX}, y{RoomPOSY}");

                Console.SetCursorPosition(110, 3);
                Console.WriteLine($"Room {RoomNumber} Width: x{RoomWidth}, Hight: y{RoomHeight}");
            }
            if (RoomNumber == 2)
            {
                Console.SetCursorPosition(110, 5);
                Console.WriteLine($"Room {RoomNumber} Location: x{RoomPOSX}, y{RoomPOSY}");

                Console.SetCursorPosition(110, 6);
                Console.WriteLine($"Room {RoomNumber} Width: x{RoomWidth}, Hight: y{RoomHeight}");
            }
            if (RoomNumber == 3)
            {
                Console.SetCursorPosition(110, 8);
                Console.WriteLine($"Room {RoomNumber} Location: x{RoomPOSX}, y{RoomPOSY}");

                Console.SetCursorPosition(110, 9);
                Console.WriteLine($"Room {RoomNumber} Width: x{RoomWidth}, Hight: y{RoomHeight}");
            }
            if (RoomNumber == 4)
            {
                Console.SetCursorPosition(110, 11);
                Console.WriteLine($"Room {RoomNumber} Location: x{RoomPOSX}, y{RoomPOSY}");

                Console.SetCursorPosition(110, 12);
                Console.WriteLine($"Room {RoomNumber} Width: x{RoomWidth}, Hight: y{RoomHeight}");
            }
            if (RoomNumber == 5)
            {
                Console.SetCursorPosition(110, 14);
                Console.WriteLine($"Room {RoomNumber} Location: x{RoomPOSX}, y{RoomPOSY}");

                Console.SetCursorPosition(110, 15);
                Console.WriteLine($"Room {RoomNumber} Width: x{RoomWidth}, Hight: y{RoomHeight}");
            }
            if (RoomNumber == 6)
            {
                Console.SetCursorPosition(110, 17);
                Console.WriteLine($"Room {RoomNumber} Location: x{RoomPOSX}, y{RoomPOSY}");

                Console.SetCursorPosition(110, 18);
                Console.WriteLine($"Room {RoomNumber} Width: x{RoomWidth}, Hight: y{RoomHeight}");
            }
            if (RoomNumber == 7)
            {
                Console.SetCursorPosition(110, 20);
                Console.WriteLine($"Room {RoomNumber} Location: x{RoomPOSX}, y{RoomPOSY}");

                Console.SetCursorPosition(110, 21);
                Console.WriteLine($"Room {RoomNumber} Width: x{RoomWidth}, Hight: y{RoomHeight}");
            }
            if (RoomNumber == 8)
            {
                Console.SetCursorPosition(110, 23);
                Console.WriteLine($"Room {RoomNumber} Location: x{RoomPOSX}, y{RoomPOSY}");

                Console.SetCursorPosition(110, 24);
                Console.WriteLine($"Room {RoomNumber} Width: x{RoomWidth}, Hight: y{RoomHeight}");
            }
            if (RoomNumber == 9)
            {
                Console.SetCursorPosition(110, 26);
                Console.WriteLine($"Room {RoomNumber} Location: x{RoomPOSX}, y{RoomPOSY}");

                Console.SetCursorPosition(110, 27);
                Console.WriteLine($"Room {RoomNumber} Width: x{RoomWidth}, Hight: y{RoomHeight}");
            }
        }
    }
}
