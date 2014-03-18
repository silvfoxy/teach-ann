using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestProject1
{
    public class Point
    {
        private int _x;
        private int _y;
        public int X { get { return _x; } }
        public int Y { get { return _y; } }

        public Point(int x, int y)
        {
            this._x = x;
            this._y = y;
        }
        public override bool Equals(object obj)
        {
            var other = (Point)obj;
            return _x == other._x && _y == other._y;
        }
    }
}
