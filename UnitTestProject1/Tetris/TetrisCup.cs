using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestProject1
{
    public interface ITetrisCup 
    {
        int GetColorOfPoint(Point point);
        ITetrisCup Clone(int color);
        void CopyFrom(ITetrisCup upperLayer, Offset offset, int color);
        bool Fits(ITetrisCup cup, Offset offset);
        int Width { get; }
        int Height { get; }
    }
    public class TetrisCup: ITetrisCup
    {
        private Size _size;
        private Point[] _pattern;
        private int[,] _colors;
        public int Width { get { return _size.Width; } }
        public int Height { get { return _size.Height; } }
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
        public ITetrisCup Clone(int color)
        {
            TetrisCup cloneTetrisCup = new TetrisCup(_size.Width, _size.Height, _pattern);
            for (int i = 0; i < _size.Width; i++)
                for (int j = 0; j < _size.Height; j++)
                {
                    if (_colors[i, j] == -1)
                        cloneTetrisCup._colors[i, j] = color;
                    else cloneTetrisCup._colors[i, j] = _colors[i, j];
                }
            return cloneTetrisCup;
        }
        public void CopyFrom(ITetrisCup upperLayer1, Offset offset, int color)
        {//илья уверен, что ф-я недотестирована
            var upperLayer = (TetrisCup)upperLayer1;
            for (int i = 0; i < upperLayer.Height; i++)
                for (int j = 0; j < upperLayer.Width; j++)
                    if (upperLayer._colors[j, i] != 0)
                        this._colors[j+offset.X, i+offset.Y] = color;

        }
        public bool Fits(ITetrisCup intoCup1, Offset offset)
        {
            var intoCup = (TetrisCup) intoCup1;
            if (intoCup._size.StrictlyLess(this._size+offset))
                return false;
            if (offset.X < 0) return false;
            for (int y = 0; y < this._size.Height; y++)
                for (int x = 0; x < this._size.Width; x++)
                    if (this._colors[x, y] != 0 &&
                        intoCup._colors[x + offset.X, y + offset.Y] != 0)
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
