﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Tetris
{
    public interface IScene
    {
        void DropDown();
        void MoveLeft();
        void MoveRight();
        bool MoveDown();
        void Rotate();
        int EraseFullLines();
        bool NextFigure(IFigure figure);
        void Print();
        int GetColorOfPoint(Point point);
        ITetrisCup Cup { get; set; }
    }

    public class Scene : IScene
    {
        public ITetrisCup Cup { get; set; }
        public IFigure Figure;
        public Offset Offset;

        public void DropDown()
        {
            int y;
            for (y = Offset.Y; Figure.CurrentRotation.Fits(Cup, new Offset(Offset.X, y + 1)); y++)
            {
            }
            Offset = new Offset(Offset.X, y);
        }

        public void MoveLeft()
        {
            if (Figure.CurrentRotation.Fits(Cup, new Offset(Offset.X - 1, Offset.Y)))
                Offset = new Offset(Offset.X - 1, Offset.Y);
        }

        public void MoveRight()
        {
            if (Figure.CurrentRotation.Fits(Cup, new Offset(Offset.X + 1, Offset.Y)))
                Offset = new Offset(Offset.X + 1, Offset.Y);
        }

        public bool MoveDown()
        {
            if (Figure.CurrentRotation.Fits(Cup, new Offset(Offset.X, Offset.Y + 1)))
            {
                Offset = new Offset(Offset.X, Offset.Y + 1);
                return true;
            }
            return false;
        }

        public void Rotate()
        {
            while (Figure.PeekNextRotation().Fits2(Cup, Offset) == FitsResult.BottomObstacle)
                Offset = new Offset(Offset.X, Offset.Y - 1);
            while (Figure.PeekNextRotation().Fits2(Cup, Offset) == FitsResult.RightObstacle)
                Offset = new Offset(Offset.X - 1, Offset.Y);
            if (Figure.PeekNextRotation().Fits2(Cup, Offset) == FitsResult.Fits)
                Figure.NextRotation();
        }

        public bool NextFigure(IFigure figure)
        {
            int middle = this.Cup.Width / 2 - figure.CurrentRotation.Width / 2;
            bool fits = figure.CurrentRotation.Fits(this.Cup, new Offset(middle, 0));
            if (fits)
            {
                this.Figure = figure;
                this.Figure.ColorFigure();
                this.Offset = new Offset(middle, 0);
            }
            return fits;
        }

        public void Print()
        {
            Cup.CopyFrom(Figure.CurrentRotation, Offset, this.Figure.Color);
        }

        public int GetColorOfPoint(Point point)
        {
            /*if (point > Offset)
                return this.Figure.CurrentRotation.GetColorOfPoint(point - this.Offset);*/
            ITetrisCup cloneCup = this.Cup.Clone(-2);
            cloneCup.CopyFrom(Figure.CurrentRotation, Offset, this.Figure.Color);
            return cloneCup.GetColorOfPoint(point);
        }
        public int EraseFullLines()
        {
            int CountFullLines = 0;
            for (int i = 0; i < Cup.Height; i++)
                if (Cup.IsLineFull(i))
                {
                    Cup.EraseLine(i);
                    CountFullLines++;
                }
            return CountFullLines;
        }
    }

    public interface IRandomFigureSelector
    {
        IFigure RandomFigure();
    }

    public class RandomFigureSelector : IRandomFigureSelector
    {
        public IFigure RandomFigure()
        {
            var rnd = new Random();
            int patternNumber = rnd.Next(7);
            Pattern randomFigurePattern =
                new PatternLibrary().Patterns[patternNumber];
            var randomFigure = new Figure();
            randomFigure.RotationNumber = rnd.Next(4);
            randomFigure.Pattern = randomFigurePattern;
            return randomFigure;
        }
    }
}
