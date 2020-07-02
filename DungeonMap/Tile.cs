using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMap
{
    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Icon { get; set; }
        public bool IsWalkable { get; set; }
        public bool IsHallway { get; set; }

        public Tile(int _x, int _y, string _icon, bool _iswalkable, bool _ishallway)
        {
            X = _x;
            Y = _y;
            Icon = _icon;
            IsWalkable = _iswalkable;
            IsHallway = _ishallway;
        }

        public string DisplayIcon()
        {
            return Icon;
        }
    }
}
