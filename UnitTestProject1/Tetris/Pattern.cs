using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Tetris
{
    public class Pattern
    {
        public ITetrisCup[] Rotations;
        //private static Random rnd = new Random();

        public Pattern Clone(int color)
        {
            //int color = rnd.Next(16) + 1;
            var pattern = new Pattern();
            pattern.Rotations = new TetrisCup[4];
            for (int i = 0; i < 4; i++)
            {
                pattern.Rotations[i] = pattern.Rotations[i].Clone(color);
            }
            return pattern;
        }
    }

    public class PatternLibrary
    {
        public Pattern[] Patterns = new Pattern[]
        {
            new Pattern
            {
                Rotations = new []
                {
                    new TetrisCup(2,3, new []{new Point(0,0), new Point(1,0), new Point(0,1), new Point(0,2) }),
                    new TetrisCup(3,2, new []{new Point(0,0), new Point(1,0), new Point(2,0), new Point(2,1) }),
                    new TetrisCup(2,3, new []{new Point(1,0), new Point(1,1), new Point(1,2), new Point(0,2) }),
                    new TetrisCup(3,2, new []{new Point(0,0), new Point(0,1), new Point(1,1), new Point(2,1) })
                }
            },
            new Pattern
            {
                Rotations = new []
                {
                    new TetrisCup(3,2, new []{new Point(0,1), new Point(1,0), new Point(1,1), new Point(2,1) }),
                    new TetrisCup(2,3, new []{new Point(0,0), new Point(0,1), new Point(0,2), new Point(1,1) }),
                    new TetrisCup(3,2, new []{new Point(0,0), new Point(1,0), new Point(1,1), new Point(2,0) }),
                    new TetrisCup(2,3, new []{new Point(0,1), new Point(1,0), new Point(1,1), new Point(1,2) })     
                }
            },            
            new Pattern
            {
                Rotations = new []
                {
                    new TetrisCup(2,3, new []{new Point(0,0), new Point(1,0), new Point(1,1), new Point(1,2) }),
                    new TetrisCup(3,2, new []{new Point(0,1), new Point(1,1), new Point(2,0), new Point(2,1) }),
                    new TetrisCup(2,3, new []{new Point(0,0), new Point(0,1), new Point(0,2), new Point(1,2) }),
                    new TetrisCup(3,2, new []{new Point(0,0), new Point(0,1), new Point(1,0), new Point(2,0) })     
                }
            },            
            new Pattern
            {
                Rotations = new []
                {
                    new TetrisCup(1,4, new []{new Point(0,0), new Point(0,1), new Point(0,2), new Point(0,3) }),
                    new TetrisCup(4,1, new []{new Point(0,0), new Point(1,0), new Point(2,0), new Point(3,0) }),
                    new TetrisCup(1,4, new []{new Point(0,0), new Point(0,1), new Point(0,2), new Point(0,3) }),
                    new TetrisCup(4,1, new []{new Point(0,0), new Point(1,0), new Point(2,0), new Point(3,0) })
                        
                }
            },            
            new Pattern
            {
                Rotations = new []
                {
                    new TetrisCup(2,2, new []{new Point(0,0), new Point(0,1), new Point(1,0), new Point(1,1) }),
                    new TetrisCup(2,2, new []{new Point(0,0), new Point(0,1), new Point(1,0), new Point(1,1) }),
                    new TetrisCup(2,2, new []{new Point(0,0), new Point(0,1), new Point(1,0), new Point(1,1) }),
                    new TetrisCup(2,2, new []{new Point(0,0), new Point(0,1), new Point(1,0), new Point(1,1) })    
                }
            },            
            new Pattern
            {
                Rotations = new []
                {
                    new TetrisCup(3,2, new []{new Point(0,0), new Point(1,0), new Point(1,1), new Point(2,1) }),
                    new TetrisCup(2,3, new []{new Point(0,1), new Point(0,2), new Point(1,0), new Point(1,1) }),
                    new TetrisCup(3,2, new []{new Point(0,0), new Point(1,0), new Point(1,1), new Point(2,1) }),
                    new TetrisCup(2,3, new []{new Point(0,1), new Point(0,2), new Point(1,0), new Point(1,1) })    
                }
            },            
            new Pattern
            {
                Rotations = new []
                {
                    new TetrisCup(3,2, new []{new Point(0,1), new Point(1,0), new Point(1,1), new Point(2,0) }),
                    new TetrisCup(2,3, new []{new Point(0,0), new Point(0,1), new Point(1,1), new Point(1,2) }),
                    new TetrisCup(3,2, new []{new Point(0,1), new Point(1,0), new Point(1,1), new Point(2,0) }),
                    new TetrisCup(2,3, new []{new Point(0,0), new Point(0,1), new Point(1,1), new Point(1,2) })     
                }
            },
        };
    }
}
