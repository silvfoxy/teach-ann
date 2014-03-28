using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Tetris
{
    public class Figure : IFigure
    {
        public Pattern Pattern { get; set; }

        public int RotationNumber { get; set; }
        public int Color { get; set; }
        public static Random rnd = new Random();
        public void ColorFigure()
        {
            Color = rnd.Next(16) + 1;
        }

        public ITetrisCup CurrentRotation
        {
            get
            {
                return Pattern.Rotations[RotationNumber];
            }
        }

        public void NextRotation()
        {
            RotationNumber = (RotationNumber + 1) % 4;
        }
    }

    public interface IFigure
    {
        ITetrisCup CurrentRotation { get; }
        void NextRotation();
        Pattern Pattern { get; set; }
        int RotationNumber { get; set; }
        void ColorFigure();
        int Color { get; set; }
    }
}
