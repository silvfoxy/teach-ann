using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestProject1
{
    public interface ITetrisCup
    {
        int GetColorOfPoint(Point point);
        bool IsLineFull(int y);
        void EraseLine(int i);
        ITetrisCup Clone(int color);
        void CopyFrom(ITetrisCup upperLayer, Offset offset, int color);
        bool Fits(ITetrisCup cup, Offset offset);
        FitsResult Fits2(ITetrisCup cup, Offset offset);
        IEnumerable<Point> AllCells { get; }
        int Width { get; }
        int Height { get; }
    }
    public class TetrisCup : ITetrisCup
    {
        private Size _size;
        private Point[] _pattern;
        private int[,] _colors;
        public FitsResult Fits2(ITetrisCup lowerCup, Offset offset)
        {
            var lowerCup1 = (TetrisCup)lowerCup;
            if (lowerCup1._size.Width < (this._size.Width + offset.X))
                return FitsResult.RightObstacle;
            if (!this.Fits(lowerCup1, offset))
                return FitsResult.BottomObstacle;
            return FitsResult.Fits;
        }

        public int Width { get { return _size.Width; } }
        public int Height { get { return _size.Height; } }
        public IEnumerable<Point> AllCells
        {
            get
            {
                for (int j = 0; j < _size.Height; j++)
                    for (int i = 0; i < _size.Width; i++)
                        yield return new Point(i, j);
            }
        }
        public TetrisCup(int width, int height, Point[] pattern)
        {
            this._size = new Size(width, height);
            this._pattern = pattern;
            _colors = new int[width, height];
            for (int i = 0; i < pattern.Length; i++)
            {
                var point = pattern[i];
                _colors[point.X, point.Y] = -1;
            }
        }
        public int GetColorOfPoint(Point point)
        {
            return _colors[point.X, point.Y];
        }
        public int this[Point point]
        {
            get { return _colors[point.X, point.Y]; }
            set { _colors[point.X, point.Y] = value; }
        }
        public ITetrisCup Clone(int color)
        {
            TetrisCup cloneTetrisCup = new TetrisCup(_size.Width, _size.Height, _pattern);
            foreach (var point in AllCells)
            {
                cloneTetrisCup[point] = this[point] == -1 ? color : this[point];
            }
            return cloneTetrisCup;
        }
        public void CopyFrom(ITetrisCup upperLayer1, Offset offset, int color)
        {
            var upperLayer = (TetrisCup)upperLayer1;
            foreach (var point in upperLayer.AllCells)
                if (upperLayer[point] != 0)
                    this[point + offset] = color;
        }

        public bool IsLineFull(int y)
        {
            for (int x = 0; x < this._size.Width; x++)
                if (_colors[x, y] == 0)
                    return false;
            return true;
        }

        public void EraseLine(int i)
        {
            for (int y = i; y >= 1; y--)
                for (int x = 0; x < _size.Width; x++)
                    _colors[x, y] = _colors[x, y - 1];
            for (int x = 0; x < _size.Width; x++)
                _colors[x, 0] = 0;
        }

        public bool Fits(ITetrisCup intoCup1, Offset offset)
        {
            var intoCup = (TetrisCup)intoCup1;
            if (intoCup._size.StrictlyLess(this._size + offset))
                return false;
            if (offset.X < 0) return false;
            foreach (var point in AllCells)
                if (this[point] != 0 && intoCup[point + offset] != 0)
                    return false;
            return true;
        }
    }
    public class Size
    {
        public int Width;
        public int Height;
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public bool StrictlyLess(Size right)
        {
            return this.Width < right.Width || this.Height < right.Height;
        }
    }
    [Flags]
    public enum FitsResult
    {
        Fits = 0, RightObstacle = 1, BottomObstacle = 2, TopObstacle = 4,
    }
    public class Offset
    {
        public int X;
        public int Y;
        public Offset(int x, int y)
        {
            X = x;
            Y = y;
        }
        public static Size operator +(Size left, Offset right)
        {
            return new Size(left.Width + right.X, left.Height + right.Y);
        }
        public static Size operator +(Offset left, Size right)
        {
            return new Size(left.X + right.Width, left.Y + right.Height);
        }
        public static Size operator -(Size left, Offset right)
        {
            return new Size(left.Width - right.X, left.Height - right.Y);
        }
        public static Size operator -(Offset left, Size right)
        {
            return new Size(left.X - right.Width, left.Y - right.Height);
        }
        public static Point operator +(Point left, Offset right)
        {
            return new Point(left.X + right.X, left.Y + right.Y);
        }
        public static Point operator +(Offset left, Point right)
        {
            return new Point(left.X + right.X, left.Y + right.Y);
        }
        public static Point operator -(Point left, Offset right)
        {
            return new Point(left.X - right.X, left.Y - right.Y);
        }
        public static Point operator -(Offset left, Point right)
        {
            return new Point(left.X - right.X, left.Y - right.Y);
        }
        public override bool Equals(object obj)
        {
            var other = (Offset)obj;
            return X == other.X && Y == other.Y;
        }
    }
}
