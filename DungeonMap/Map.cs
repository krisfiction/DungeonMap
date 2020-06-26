using System;

namespace DungeonMap
{
    public class Map
    {
        private readonly string Wall_X = "═";
        private readonly string Wall_Y = "║";
        private readonly string Floor = "·"; //ascii #183 middle dot

        public string NWcorner = "╔";
        public string NEcorner = "╗";
        public string SWcorner = "╚";
        public string SEcorner = "╝";

        private int PlayerPOSX { get; set; }
        private int PlayerPOSY { get; set; }
        private readonly string PlayerIcon = "@";

        private const int MapSizeX = 110;
        private const int MapSizeY = 35;

        private readonly Tile[,] GameMap = new Tile[MapSizeX, MapSizeY];

        private int RoomNumber = 1;

        public int NumberOfRooms = 0;

        public void Create()
        {
            Random random = new Random();

            //todo 3x3 room structure - may enlarge in the future

            // row 1
            int buildRoom = random.Next(1, 3);
            if (buildRoom == 1)
            {
                int RoomHeight = random.Next(3, 9);
                int RoomWidth = random.Next(3, 34);

                int RoomPOSX = random.Next(0, 34 - 1 - RoomWidth);
                int RoomPOSY = random.Next(0, 9 - 1 - RoomHeight);

                DisplayRoomInfo(RoomWidth + 1, RoomHeight + 1, RoomPOSX, RoomPOSY);
                CreateRoom(RoomHeight, RoomWidth, RoomPOSX, RoomPOSY);
            }

            buildRoom = random.Next(1, 3);
            if (buildRoom == 1)
            {
                int RoomHeight = random.Next(3, 9);
                int RoomWidth = random.Next(3, 34);

                int RoomPOSX = random.Next(38, 72 - 1 - RoomWidth);
                int RoomPOSY = random.Next(0, 9 - 1 - RoomHeight);

                DisplayRoomInfo(RoomWidth + 1, RoomHeight + 1, RoomPOSX, RoomPOSY);
                CreateRoom(RoomHeight, RoomWidth, RoomPOSX, RoomPOSY);
            }

            buildRoom = random.Next(1, 3);
            if (buildRoom == 1)
            {
                int RoomHeight = random.Next(3, 9);
                int RoomWidth = random.Next(3, 34);

                int RoomPOSX = random.Next(76, 110 - 1 - RoomWidth);
                int RoomPOSY = random.Next(0, 9 - 1 - RoomHeight);

                DisplayRoomInfo(RoomWidth + 1, RoomHeight + 1, RoomPOSX, RoomPOSY);
                CreateRoom(RoomHeight, RoomWidth, RoomPOSX, RoomPOSY);
            }


            // row 2
            buildRoom = random.Next(1, 3);
            if (buildRoom == 1)
            {
                int RoomHeight = random.Next(3, 9);
                int RoomWidth = random.Next(3, 34);

                int RoomPOSX = random.Next(0, 34 - 1 - RoomWidth);
                int RoomPOSY = random.Next(13, 22 - 1 - RoomHeight);

                DisplayRoomInfo(RoomWidth + 1, RoomHeight + 1, RoomPOSX, RoomPOSY);
                CreateRoom(RoomHeight, RoomWidth, RoomPOSX, RoomPOSY);
            }

            buildRoom = random.Next(1, 3);
            if (buildRoom == 1)
            {
                int RoomHeight = random.Next(3, 9);
                int RoomWidth = random.Next(3, 34);

                int RoomPOSX = random.Next(38, 72 - 1 - RoomWidth);
                int RoomPOSY = random.Next(13, 22 - 1 - RoomHeight);

                DisplayRoomInfo(RoomWidth + 1, RoomHeight + 1, RoomPOSX, RoomPOSY);
                CreateRoom(RoomHeight, RoomWidth, RoomPOSX, RoomPOSY);
            }

            buildRoom = random.Next(1, 3);
            if (buildRoom == 1)
            {
                int RoomHeight = random.Next(3, 9);
                int RoomWidth = random.Next(3, 34);

                int RoomPOSX = random.Next(76, 110 - 1 - RoomWidth);
                int RoomPOSY = random.Next(13, 22 - 1 - RoomHeight);

                DisplayRoomInfo(RoomWidth + 1, RoomHeight + 1, RoomPOSX, RoomPOSY);
                CreateRoom(RoomHeight, RoomWidth, RoomPOSX, RoomPOSY);
            }

            // row 3
            buildRoom = random.Next(1, 3);
            if (buildRoom == 1)
            {
                int RoomHeight = random.Next(3, 9);
                int RoomWidth = random.Next(3, 34);

                int RoomPOSX = random.Next(0, 34 - 1 - RoomWidth);
                int RoomPOSY = random.Next(26, 35 - 1 - RoomHeight);

                DisplayRoomInfo(RoomWidth + 1, RoomHeight + 1, RoomPOSX, RoomPOSY);
                CreateRoom(RoomHeight, RoomWidth, RoomPOSX, RoomPOSY);
            }

            buildRoom = random.Next(1, 3);
            if (buildRoom == 1)
            {
                int RoomHeight = random.Next(3, 9);
                int RoomWidth = random.Next(3, 34);

                int RoomPOSX = random.Next(38, 72 - 1 - RoomWidth);
                int RoomPOSY = random.Next(26, 35 - 1 - RoomHeight);

                DisplayRoomInfo(RoomWidth + 1, RoomHeight + 1, RoomPOSX, RoomPOSY);
                CreateRoom(RoomHeight, RoomWidth, RoomPOSX, RoomPOSY);
            }

            buildRoom = random.Next(1, 3);
            if (buildRoom == 1)
            {
                int RoomHeight = random.Next(3, 9);
                int RoomWidth = random.Next(3, 34);

                int RoomPOSX = random.Next(76, 110 - 1 - RoomWidth);
                int RoomPOSY = random.Next(26, 35 - 1 - RoomHeight);

                DisplayRoomInfo(RoomWidth + 1, RoomHeight + 1, RoomPOSX, RoomPOSY);
                CreateRoom(RoomHeight, RoomWidth, RoomPOSX, RoomPOSY);
            }




        }




        public void CreateRoom(int RoomHeight, int RoomWidth, int RoomPOSX, int RoomPOSY)
        {
            //Random random = new Random();

            //int RoomHeight = random.Next(3, 9);
            //int RoomWidth = random.Next(3, 34);

            //int RoomPOSX = random.Next(0, MapSizeX - 1 - RoomWidth);
            //int RoomPOSY = random.Next(0, MapSizeY - 1 - RoomHeight);

            //DisplayRoomInfo(RoomWidth + 1, RoomHeight + 1, RoomPOSX, RoomPOSY);

            NumberOfRooms++;

            for (int y = 0; y <= RoomHeight; y++)
            {
                for (int x = 0; x <= RoomWidth; x++)
                {
                    //apply walls
                    if (y == 0 || y == RoomHeight) // "═"
                    {
                        GameMap[RoomPOSX + x, RoomPOSY + y] = new Tile(x, y, Wall_X, false);
                    }
                    else if (x == 0 || x == RoomWidth) // "║"
                    {
                        GameMap[RoomPOSX + x, RoomPOSY + y] = new Tile(x, y, Wall_Y, false);
                    }
                    //apply floors
                    else // "."
                    {
                        GameMap[RoomPOSX + x, RoomPOSY + y] = new Tile(x, y, Floor, true);
                    }

                    // apply corner walls
                    if (x == 0 && y == 0)
                    {
                        GameMap[RoomPOSX + x, RoomPOSY + y] = new Tile(x, y, NWcorner, false);
                    }
                    if (y == 0 && x == RoomWidth)
                    {
                        GameMap[RoomPOSX + x, RoomPOSY + y] = new Tile(x, y, NEcorner, false);
                    }
                    if (y == RoomHeight && x == RoomWidth)
                    {
                        GameMap[RoomPOSX + x, RoomPOSY + y] = new Tile(x, y, SEcorner, false);
                    }
                    if (y == RoomHeight && x == 0)
                    {
                        GameMap[RoomPOSX + x, RoomPOSY + y] = new Tile(x, y, SWcorner, false);
                    }

                }
            }

            RoomNumber++;
        }






        public void FillMap()
        {
            for (int x = 0; x <= MapSizeX - 1; x++)
            {
                for (int y = 0; y <= MapSizeY - 1; y++)
                {
                    GameMap[x, y] = new Tile(x, y, " ", false);
                }
            }
        }


        public void Display()
        {
            for (int x = 0; x <= MapSizeX - 1; x++)
            {
                for (int y = 0; y <= MapSizeY - 1; y++)
                {
                    Tile CurrentTile = (Tile)GameMap[x, y];
                    string _icon = CurrentTile.Icon;

                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(_icon);
                }
            }
        }


        public void PlacePlayer()
        {
            Random random = new Random();
            int _placed = 0;

            do
            {
                int _randX = random.Next(0, MapSizeX);
                int _randY = random.Next(0, MapSizeY);

                Tile CurrentTile = (Tile)GameMap[_randX, _randY];
                bool _iswalkable = CurrentTile.IsWalkable;

                if (_iswalkable && _placed == 0)
                {
                    CurrentTile.Icon = PlayerIcon;

                    PlayerPOSX = _randX;
                    PlayerPOSY = _randY;
                    _placed = 1;
                }
            } while (_placed == 0);

            DisplayPlayerPosition();
        }


        public void PlaceMonster()
        {
            Random random = new Random();
            int _placed = 0;

            do
            {
                int _randX = random.Next(0, MapSizeX);
                int _randY = random.Next(0, MapSizeY);

                Tile CurrentTile = (Tile)GameMap[_randX, _randY];
                bool _iswalkable = CurrentTile.IsWalkable;

                if (_iswalkable && _placed == 0)
                {
                    CurrentTile.Icon = "M";
                    _placed = 1;
                }
            } while (_placed == 0);
        }


        public void DisplayPlayerPosition()
        {
            Console.SetCursorPosition(110, 0);
            Console.WriteLine($"Player Position: x{PlayerPOSX}, y{PlayerPOSY}");
        }


        public void MovePlayer(string _direction)
        {
            if (_direction == "North")
            {
                Tile CurrentTile = (Tile)GameMap[PlayerPOSX, PlayerPOSY];
                Tile NextTile = (Tile)GameMap[PlayerPOSX, PlayerPOSY - 1];
                bool _iswalkable = NextTile.IsWalkable;
                if (_iswalkable)
                {
                    CurrentTile.Icon = Floor;
                    NextTile.Icon = PlayerIcon;
                    PlayerPOSY--;
                    DisplayPlayerPosition();
                }
            }
            if (_direction == "South")
            {
                Tile CurrentTile = (Tile)GameMap[PlayerPOSX, PlayerPOSY];
                Tile NextTile = (Tile)GameMap[PlayerPOSX, PlayerPOSY + 1];
                bool _iswalkable = NextTile.IsWalkable;
                if (_iswalkable)
                {
                    CurrentTile.Icon = Floor;
                    NextTile.Icon = PlayerIcon;
                    PlayerPOSY++;
                    DisplayPlayerPosition();
                }
            }
            if (_direction == "West")
            {
                Tile CurrentTile = (Tile)GameMap[PlayerPOSX, PlayerPOSY];
                Tile NextTile = (Tile)GameMap[PlayerPOSX - 1, PlayerPOSY];
                bool _iswalkable = NextTile.IsWalkable;
                if (_iswalkable)
                {
                    CurrentTile.Icon = Floor;
                    NextTile.Icon = PlayerIcon;
                    PlayerPOSX--;
                    DisplayPlayerPosition();
                }
            }
            if (_direction == "East")
            {
                Tile CurrentTile = (Tile)GameMap[PlayerPOSX, PlayerPOSY];
                Tile NextTile = (Tile)GameMap[PlayerPOSX + 1, PlayerPOSY];
                bool _iswalkable = NextTile.IsWalkable;
                if (_iswalkable)
                {
                    CurrentTile.Icon = Floor;
                    NextTile.Icon = PlayerIcon;
                    PlayerPOSX++;
                    DisplayPlayerPosition();
                }
            }
            if (_direction == "NorthWest")
            {
                Tile CurrentTile = (Tile)GameMap[PlayerPOSX, PlayerPOSY];
                Tile NextTile = (Tile)GameMap[PlayerPOSX - 1, PlayerPOSY - 1];
                bool _iswalkable = NextTile.IsWalkable;
                if (_iswalkable)
                {
                    CurrentTile.Icon = Floor;
                    NextTile.Icon = PlayerIcon;
                    PlayerPOSX--;
                    PlayerPOSY--;
                    DisplayPlayerPosition();
                }
            }
            if (_direction == "NorthEast")
            {
                Tile CurrentTile = (Tile)GameMap[PlayerPOSX, PlayerPOSY];
                Tile NextTile = (Tile)GameMap[PlayerPOSX + 1, PlayerPOSY - 1];
                bool _iswalkable = NextTile.IsWalkable;
                if (_iswalkable)
                {
                    CurrentTile.Icon = Floor;
                    NextTile.Icon = PlayerIcon;
                    PlayerPOSX++;
                    PlayerPOSY--;
                    DisplayPlayerPosition();
                }
            }
            if (_direction == "SouthWest")
            {
                Tile CurrentTile = (Tile)GameMap[PlayerPOSX, PlayerPOSY];
                Tile NextTile = (Tile)GameMap[PlayerPOSX - 1, PlayerPOSY + 1];
                bool _iswalkable = NextTile.IsWalkable;
                if (_iswalkable)
                {
                    CurrentTile.Icon = Floor;
                    NextTile.Icon = PlayerIcon;
                    PlayerPOSX--;
                    PlayerPOSY++;
                    DisplayPlayerPosition();
                }
            }
            if (_direction == "SouthEast")
            {
                Tile CurrentTile = (Tile)GameMap[PlayerPOSX, PlayerPOSY];
                Tile NextTile = (Tile)GameMap[PlayerPOSX + 1, PlayerPOSY + 1];
                bool _iswalkable = NextTile.IsWalkable;
                if (_iswalkable)
                {
                    CurrentTile.Icon = Floor;
                    NextTile.Icon = PlayerIcon;
                    PlayerPOSX++;
                    PlayerPOSY++;
                    DisplayPlayerPosition();
                }
            }
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
            if (RoomNumber == 10)
            {
                Console.SetCursorPosition(110, 29);
                Console.WriteLine($"Room {RoomNumber} Location: x{RoomPOSX}, y{RoomPOSY}");

                Console.SetCursorPosition(110, 30);
                Console.WriteLine($"Room {RoomNumber} Width: x{RoomWidth}, Hight: y{RoomHeight}");
            }
        }
    }
}
