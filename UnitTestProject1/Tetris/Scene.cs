using System;
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
        bool NextFigure(IFigure figure);
        void Print();
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
            for (y = Offset.Y; Cup.Fits(Figure.CurrentRotation, new Offset(Offset.X, y + 1)); y++)
            {
            }
            Offset = new Offset(Offset.X, y);
        }

        public void MoveLeft()
        {
            if (Cup.Fits(Figure.CurrentRotation, new Offset(Offset.X - 1, Offset.Y)))
                Offset = new Offset(Offset.X - 1, Offset.Y);
        }

        public void MoveRight()
        {
            if (Cup.Fits(Figure.CurrentRotation, new Offset(Offset.X + 1, Offset.Y)))
                Offset = new Offset(Offset.X + 1, Offset.Y);
        }

        public bool MoveDown()
        {
            if (Cup.Fits(Figure.CurrentRotation, new Offset(Offset.X, Offset.Y + 1)))
            {
                Offset = new Offset(Offset.X, Offset.Y + 1);
                return true;
            }
            return false;
        }

        public void Rotate()
        {
            Figure.NextRotation();
        }

        public bool NextFigure(IFigure figure)
        {
            int middle = this.Cup.Width / 2 - figure.CurrentRotation.Width / 2;
            bool fits = this.Cup.Fits(figure.CurrentRotation, new Offset(middle, 0));
            if (fits)
            {
                this.Figure = figure;
                this.Offset = new Offset(middle, 0);
            }
            return fits;
        }

        public void Print()
        {
            Cup.CopyFrom(Figure.CurrentRotation, Offset);
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
