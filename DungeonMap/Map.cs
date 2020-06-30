using System;

namespace DungeonMap
{
    public class Map
    {
        private readonly string WallxIcon = "═";
        private readonly string WallyIcon = "║";
        private readonly string FloorIcon = "·"; //ascii #183 middle dot
        private readonly string DoorIcon = "+";

        public string NWcornerIcon = "╔";
        public string NEcornerIcon = "╗";
        public string SWcornerIcon = "╚";
        public string SEcornerIcon = "╝";

        private int PlayerPOSX { get; set; }
        private int PlayerPOSY { get; set; }
        private readonly string PlayerIcon = "@";

        private const int MapSizeX = 110;
        private const int MapSizeY = 35;

        private readonly Tile[,] GameMap = new Tile[MapSizeX, MapSizeY];

        private readonly Room[,] rooms = new Room[3, 3];

        private int RoomNumber = 1;

        public int NumberOfRooms = 0;

        public void Create()
        {
            Random random = new Random();

            //! 3x3 room structure - may enlarge in the future

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

            //! auto build to test hallways
            buildRoom = 1;// random.Next(1, 3);
            if (buildRoom == 1)
            {
                int RoomHeight = random.Next(3, 9);
                int RoomWidth = random.Next(3, 34);

                int RoomPOSX = random.Next(38, 72 - 1 - RoomWidth);
                int RoomPOSY = random.Next(0, 9 - 1 - RoomHeight);

                rooms[0, 1] = new Room(2, RoomPOSX, RoomPOSY, RoomHeight, RoomWidth);
                CreateRoom(RoomPOSX, RoomPOSY, RoomHeight, RoomWidth);
            }

            //! auto build to test hallways
            buildRoom = 1;// random.Next(1, 3);
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


        public void CreateHallways()
        {
            Room room1 = (Room)rooms[0, 0];
            Room room2 = (Room)rooms[0, 1];
            Room room3 = (Room)rooms[0, 2];

            Room room4 = (Room)rooms[1, 0];
            Room room5 = (Room)rooms[1, 1];
            Room room6 = (Room)rooms[1, 2];

            Room room7 = (Room)rooms[2, 0];
            Room room8 = (Room)rooms[2, 1];
            Room room9 = (Room)rooms[2, 2];


            if (room1.Number != 0 && room2.Number != 0)
            {
                CreateHorizontalHallways(0, 0, 0, 1);
            }
            if (room2.Number != 0 && room3.Number != 0)
            {
                CreateHorizontalHallways(0, 1, 0, 2);
            }
            if (room1.Number != 0 && room3.Number != 0)
            {
                if (room2.Number == 0)
                {
                    CreateHorizontalHallways(0, 0, 0, 2);
                }
            }

            if (room4.Number != 0 && room5.Number != 0)
            {
                CreateHorizontalHallways(1, 0, 1, 1);
            }
            if (room5.Number != 0 && room6.Number != 0)
            {
                CreateHorizontalHallways(1, 1, 1, 2);
            }
            if (room4.Number != 0 && room6.Number != 0)
            {
                if (room5.Number == 0)
                {
                    CreateHorizontalHallways(1, 0, 1, 2);
                }
            }

            if (room7.Number != 0 && room8.Number != 0)
            {
                CreateHorizontalHallways(2, 0, 2, 1);
            }
            if (room8.Number != 0 && room9.Number != 0)
            {
                CreateHorizontalHallways(2, 1, 2, 2);
            }
            if (room7.Number != 0 && room9.Number != 0)
            {
                if (room8.Number == 0)
                {
                    CreateHorizontalHallways(2, 0, 2, 2);
                }
            }



        }








        //! connecting room 2 [0, 1] to room 3 [0, 2]
        public void CreateHorizontalHallways(int OneX, int OneY, int TwoX, int TwoY)
        {
            Random random = new Random();
            //! room 1
            Room Room1 = (Room)rooms[OneX, OneY];
            int _number1 = Room1.Number;
            int _posx1 = Room1.POSx;
            int _posy1 = Room1.POSy;
            int _height1 = Room1.Height;
            int _width1 = Room1.Width;

            //! room 2
            Room Room2 = (Room)rooms[TwoX, TwoY];
            int _number2 = Room2.Number;
            int _posx2 = Room2.POSx;
            int _posy2 = Room2.POSy;
            int _height2 = Room2.Height;
            int _width2 = Room2.Width;

            //! connect room 1 to room 2

            //! door 1 x, y
            int RandomDoor1 = random.Next(1, _height1);
            int Door1x = _posx1 + _width1;
            int Door1y = _posy1 + RandomDoor1;

            //! door 2 x, y
            int RandomDoor2 = random.Next(1, _height2);
            int Door2x = _posx2;
            int Door2y = _posy2 + RandomDoor2;

            //! hallway
            int HallLength = Door2x - _posx1 - _width1;
            int HallRandom = random.Next(1, HallLength);
            int HallpartA = HallLength - HallRandom;
            int HallpartB = Door1x + HallLength - HallpartA;


            //todo check if door1 and door2 are on same y path
            if (Door1y == Door2y)
            {
                int y = Door1y;
                for (int x = Door1x; x <= Door2x; x++)
                {
                    Tile CurrentTile = (Tile)GameMap[x, y];
                    CurrentTile.Icon = FloorIcon;
                    CurrentTile.IsWalkable = true;

                    //! walls and corner walls around the hallway
                    //! needs tweaked but mostly works however it is disabled untill i get hallways working correctly
                    //Tile uTile = (Tile)GameMap[x, y - 1];
                    //uTile.Icon = WallxIcon;
                    //uTile.IsWalkable = false;

                    //Tile bTile = (Tile)GameMap[x, y + 1];
                    //bTile.Icon = WallxIcon;
                    //bTile.IsWalkable = false;

                    //? check center tile and all 8 tiles around it to apply correct wall icon
                    if (x == _posx1 + _width1)
                    {
                        Tile UcornerTile = (Tile)GameMap[x, y];
                        UcornerTile.Icon = DoorIcon;
                        UcornerTile.IsWalkable = true;

                        //    Tile UcornerTile = (Tile)GameMap[x, y - 1];
                        //    UcornerTile.Icon = SWcornerIcon;
                        //    UcornerTile.IsWalkable = false;

                        //    Tile BcornerTile = (Tile)GameMap[x, y + 1];
                        //    BcornerTile.Icon = NWcornerIcon;
                        //    BcornerTile.IsWalkable = false;
                    }

                    if (x == Door2x)
                    {
                        Tile UcornerTile = (Tile)GameMap[x, y];
                        UcornerTile.Icon = DoorIcon;
                        UcornerTile.IsWalkable = true;

                        //    Tile UcornerTile = (Tile)GameMap[x, y - 1];
                        //    UcornerTile.Icon = SEcornerIcon;
                        //    UcornerTile.IsWalkable = false;

                        //    Tile BcornerTile = (Tile)GameMap[x, y + 1];
                        //    BcornerTile.Icon = NEcornerIcon;
                        //    BcornerTile.IsWalkable = false;
                    }
                }
            }
            else
            {
                //todo build z hallway

                //Console.SetCursorPosition(110, 1);
                //Console.WriteLine("hallrandom: " + HallRandom + " HallLength: " + HallLength);

                //Console.SetCursorPosition(110, 2);
                //Console.WriteLine("door1x: " + Door1x + " Door1y: " + Door1y);
                //Console.SetCursorPosition(110, 3);
                //Console.WriteLine("door2x: " + Door2x + " Door2y: " + Door2y);
                //Console.SetCursorPosition(110, 4);
                //Console.WriteLine("hallA: " + HallpartA + " HallB: " + HallpartB);

                int y = Door1y;
                for (int x = Door1x; x <= HallpartB; x++)
                {
                    Tile CurrentTile = (Tile)GameMap[x, y];
                    CurrentTile.Icon = FloorIcon;
                    CurrentTile.IsWalkable = true;
                }
                y = Door2y;
                for (int x = HallpartB; x <= Door2x; x++)
                {
                    Tile CurrentTile = (Tile)GameMap[x, y];
                    CurrentTile.Icon = FloorIcon;
                    CurrentTile.IsWalkable = true;
                }

                if (Door1y < Door2y)
                {
                    int x1 = HallpartB;
                    for (int y1 = Door1y; y1 <= Door2y; y1++)
                    {
                        Tile CurrentTile = (Tile)GameMap[x1, y1];
                        CurrentTile.Icon = FloorIcon;
                        CurrentTile.IsWalkable = true;
                    }
                }
                else
                {
                    int x1 = HallpartB;
                    for (int y1 = Door2y; y1 <= Door1y; y1++)
                    {
                        Tile CurrentTile = (Tile)GameMap[x1, y1];
                        CurrentTile.Icon = FloorIcon;
                        CurrentTile.IsWalkable = true;
                    }

                }



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
                        GameMap[RoomPOSX + x, RoomPOSY + y] = new Tile(x, y, WallxIcon, false);
                    }
                    else if (x == 0 || x == RoomWidth) // "║"
                    {
                        GameMap[RoomPOSX + x, RoomPOSY + y] = new Tile(x, y, WallyIcon, false);
                    }
                    //apply floors
                    else // "."
                    {
                        GameMap[RoomPOSX + x, RoomPOSY + y] = new Tile(x, y, FloorIcon, true);
                    }

                    // apply corner walls
                    if (x == 0 && y == 0)
                    {
                        GameMap[RoomPOSX + x, RoomPOSY + y] = new Tile(x, y, NWcornerIcon, false);
                    }
                    if (y == 0 && x == RoomWidth)
                    {
                        GameMap[RoomPOSX + x, RoomPOSY + y] = new Tile(x, y, NEcornerIcon, false);
                    }
                    if (y == RoomHeight && x == RoomWidth)
                    {
                        GameMap[RoomPOSX + x, RoomPOSY + y] = new Tile(x, y, SEcornerIcon, false);
                    }
                    if (y == RoomHeight && x == 0)
                    {
                        GameMap[RoomPOSX + x, RoomPOSY + y] = new Tile(x, y, SWcornerIcon, false);
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
                    //! fill array with blank rooms
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
                    CurrentTile.Icon = FloorIcon;
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
                    CurrentTile.Icon = FloorIcon;
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
                    CurrentTile.Icon = FloorIcon;
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
                    CurrentTile.Icon = FloorIcon;
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
                    CurrentTile.Icon = FloorIcon;
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
                    CurrentTile.Icon = FloorIcon;
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
                    CurrentTile.Icon = FloorIcon;
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
                    CurrentTile.Icon = FloorIcon;
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
