using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMap
{
    public class Tile
    {
        public bool IsWalkable { get; set; }
        public string Icon { get; set; }
        public int Y { get; set; }
        public int X { get; set; }

        public Tile(int _x, int _y, string _icon, bool _iswalkable)
        {
            X = _x;
            Y = _y;
            Icon = _icon;
            IsWalkable = _iswalkable;
        }

        public string DisplayIcon()
        {
            return Icon;
        }
    }
}
