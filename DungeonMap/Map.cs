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

        private readonly Room[,] rooms = new Room[3,3];

        private int RoomNumber = 1;

        public int NumberOfRooms = 0;

        public void Create()
        {
            Random random = new Random();

            //todo 3x3 room structure - may enlarge in the future

            // row 0
            int buildRoom = random.Next(1, 3);
            if (buildRoom == 1)
            {
                int RoomHeight = random.Next(3, 9);
                int RoomWidth = random.Next(3, 34);

                int RoomPOSX = random.Next(0, 34 - 1 - RoomWidth);
                int RoomPOSY = random.Next(0, 9 - 1 - RoomHeight);

                rooms[0, 0] = new Room(1, RoomPOSX, RoomPOSY, RoomHeight, RoomWidth);
                CreateRoom(RoomPOSX, RoomPOSY, RoomHeight, RoomWidth);
            }

            buildRoom = random.Next(1, 3);
            if (buildRoom == 1)
            {
                int RoomHeight = random.Next(3, 9);
                int RoomWidth = random.Next(3, 34);

                int RoomPOSX = random.Next(38, 72 - 1 - RoomWidth);
                int RoomPOSY = random.Next(0, 9 - 1 - RoomHeight);

                rooms[0, 1] = new Room(2, RoomPOSX, RoomPOSY, RoomHeight, RoomWidth);
                CreateRoom(RoomPOSX, RoomPOSY, RoomHeight, RoomWidth);
            }

            buildRoom = random.Next(1, 3);
            if (buildRoom == 1)
            {
                int RoomHeight = random.Next(3, 9);
                int RoomWidth = random.Next(3, 34);

                int RoomPOSX = random.Next(76, 110 - 1 - RoomWidth);
                int RoomPOSY = random.Next(0, 9 - 1 - RoomHeight);

                rooms[0, 2] = new Room(3, RoomPOSX, RoomPOSY, RoomHeight, RoomWidth);
                CreateRoom(RoomPOSX, RoomPOSY, RoomHeight, RoomWidth);
            }


            // row 1
            buildRoom = random.Next(1, 3);
            if (buildRoom == 1)
            {
                int RoomHeight = random.Next(3, 9);
                int RoomWidth = random.Next(3, 34);

                int RoomPOSX = random.Next(0, 34 - 1 - RoomWidth);
                int RoomPOSY = random.Next(13, 22 - 1 - RoomHeight);

                rooms[1, 0] = new Room(4, RoomPOSX, RoomPOSY, RoomHeight, RoomWidth);
                CreateRoom(RoomPOSX, RoomPOSY, RoomHeight, RoomWidth);
            }

            buildRoom = random.Next(1, 3);
            if (buildRoom == 1)
            {
                int RoomHeight = random.Next(3, 9);
                int RoomWidth = random.Next(3, 34);

                int RoomPOSX = random.Next(38, 72 - 1 - RoomWidth);
                int RoomPOSY = random.Next(13, 22 - 1 - RoomHeight);

                rooms[1, 1] = new Room(5, RoomPOSX, RoomPOSY, RoomHeight, RoomWidth);
                CreateRoom(RoomPOSX, RoomPOSY, RoomHeight, RoomWidth);
            }

            buildRoom = random.Next(1, 3);
            if (buildRoom == 1)
            {
                int RoomHeight = random.Next(3, 9);
                int RoomWidth = random.Next(3, 34);

                int RoomPOSX = random.Next(76, 110 - 1 - RoomWidth);
                int RoomPOSY = random.Next(13, 22 - 1 - RoomHeight);

                rooms[1, 2] = new Room(6, RoomPOSX, RoomPOSY, RoomHeight, RoomWidth);
                CreateRoom(RoomPOSX, RoomPOSY, RoomHeight, RoomWidth);
            }

            // row 2
            buildRoom = random.Next(1, 3);
            if (buildRoom == 1)
            {
                int RoomHeight = random.Next(3, 9);
                int RoomWidth = random.Next(3, 34);

                int RoomPOSX = random.Next(0, 34 - 1 - RoomWidth);
                int RoomPOSY = random.Next(26, 35 - 1 - RoomHeight);

                rooms[2, 0] = new Room(7, RoomPOSX, RoomPOSY, RoomHeight, RoomWidth);
                CreateRoom(RoomPOSX, RoomPOSY, RoomHeight, RoomWidth);
            }

            buildRoom = random.Next(1, 3);
            if (buildRoom == 1)
            {
                int RoomHeight = random.Next(3, 9);
                int RoomWidth = random.Next(3, 34);

                int RoomPOSX = random.Next(38, 72 - 1 - RoomWidth);
                int RoomPOSY = random.Next(26, 35 - 1 - RoomHeight);

                rooms[2, 1] = new Room(8, RoomPOSX, RoomPOSY, RoomHeight, RoomWidth);
                CreateRoom(RoomPOSX, RoomPOSY, RoomHeight, RoomWidth);
            }

            buildRoom = random.Next(1, 3);
            if (buildRoom == 1)
            {
                int RoomHeight = random.Next(3, 9);
                int RoomWidth = random.Next(3, 34);

                int RoomPOSX = random.Next(76, 110 - 1 - RoomWidth);
                int RoomPOSY = random.Next(26, 35 - 1 - RoomHeight);

                rooms[2, 2] = new Room(9, RoomPOSX, RoomPOSY, RoomHeight, RoomWidth);
                CreateRoom(RoomPOSX, RoomPOSY, RoomHeight, RoomWidth);
            }
        }




        public void CreateRoom(int RoomPOSX, int RoomPOSY, int RoomHeight, int RoomWidth)
        {
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


        public void FillRooms()
        {
            for (int x = 0; x <= 2; x++)
            {
                for (int y = 0; y <= 2; y++)
                {
                    //fill array with blank rooms
                    rooms[x, y] = new Room(0, 0, 0, 0, 0);
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


        public void DisplayRoomInfo()
        {
            int _printLocationAt = 0;
            int _printDimensionsAt = 1;

            for (int x = 0; x <= 2; x++)
            {
                for (int y = 0; y <= 2; y++)
                {
                    Room CurrentRoom = (Room)rooms[x, y];
                    int _number = CurrentRoom.Number;
                    int _posx = CurrentRoom.POSx;
                    int _posy = CurrentRoom.POSy;
                    int _height = CurrentRoom.Height;
                    int _width = CurrentRoom.Width;

                    _printDimensionsAt += 3;
                    _printLocationAt += 3;


                    Console.SetCursorPosition(110, _printLocationAt);
                    Console.WriteLine($"Room {_number} Location: x{_posx}, y{_posy}");
                    Console.SetCursorPosition(110, _printDimensionsAt);
                    Console.WriteLine($"Room {_number} Width: x{_width}, Hight: y{_height}");
                }
            }
        }
    }
}
