﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Tetris
{
    public class Scene
    {
        public ITetrisCup Cup;
        public IFigure Figure;
        public Offset Offset;

        public void DropDown()
        {
            int y;
            for (y = Offset.Y; Cup.Fits(Figure.CurrentRotation, new Offset(Offset.X, y+1)); y++){}
            Offset = new Offset( Offset.X, y);
        }

        public void MoveLeft()
        {
            if (Cup.Fits(Figure.CurrentRotation, new Offset(Offset.X-1, Offset.Y)))
                Offset = new Offset(Offset.X-1, Offset.Y);
        }

        public void MoveRight()
        {
            if (Cup.Fits(Figure.CurrentRotation, new Offset(Offset.X+1, Offset.Y)))
                Offset = new Offset(Offset.X+1, Offset.Y);
        }

        public void MoveDown()
        {
            if (Cup.Fits(Figure.CurrentRotation, new Offset(Offset.X, Offset.Y+1)))
                Offset = new Offset(Offset.X, Offset.Y+1);
        }

        public void Rotate()
        {
            Figure.NextRotation();
        }
        public bool NextFigure(Figure figure) 
        {
            throw new NotImplementedException();
        }
    }
}
