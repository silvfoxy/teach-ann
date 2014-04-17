using System;

namespace UnitTestProject1.Tetris
{
    public class Game
    {
        public IScene Scene;
        private readonly IRandomFigureSelector _randomFigureSelector;
        public int Score {get; set;}
        public Game(IScene scene, IRandomFigureSelector randomFigureSelector)
        {
            scene.Cup = new TetrisCup(15, 25, new Point[] {});
            scene.NextFigure(randomFigureSelector.RandomFigure());
            Scene = scene;
            _randomFigureSelector = randomFigureSelector;
        }

        /// <summary>
        /// occures every time timer ticks
        /// 1. moves figure down
        /// 2. if it isn't possible - prints it
        /// 3. if when prints, chooses the next one
        /// 4. if when it's the first tick - starts the game by choosen the next figure
        /// </summary>
        public void Tick()
        {
            var isPossible = Scene.MoveDown();
            if (!isPossible)
            {
                Scene.Print();
                Score++;
                Scene.NextFigure(_randomFigureSelector.RandomFigure());
                int counter = Scene.EraseFullLines();
                Score += counter * 10;
            }
        }

    }
}