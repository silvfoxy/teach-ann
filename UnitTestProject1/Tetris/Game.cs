using System;

namespace UnitTestProject1.Tetris
{
    public class Game
    {
        public IScene Scene;
        private readonly IRandomFigureSelector _randomFigureSelector;
        public int Score { get; set; }
        public IFigure NextFigure;
        public double SpeedInSeconds { get; set; }
        public int Level;
        public Game(IScene scene, IRandomFigureSelector randomFigureSelector)
        {
            scene.Cup = new TetrisCup(10, 20, new Point[] { });
            scene.NextFigure(randomFigureSelector.RandomFigure());
            this.NextFigure = randomFigureSelector.RandomFigure();
            Scene = scene;
            Level = 1;
            SpeedInSeconds = 0.5;
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
                Scene.NextFigure(NextFigure);
                this.NextFigure = _randomFigureSelector.RandomFigure();
                //Scene.NextFigure(_randomFigureSelector.RandomFigure());
                int counter = Scene.EraseFullLines();
                Score += counter * 10;
                SetLevel();
            }

        }
        public void SetLevel()
        {
            var levelsLib=new LevelsLibrary();
            if (this.Score >= levelsLib.LevelsTable[this.Level].Score)
            {
                this.Level++;
                this.SpeedInSeconds=levelsLib.LevelsTable[this.Level-1].SpeedInSeconds;
            }
        }
    }
    public class LevelsTable
    {
        public int Level;
        public int Score;
        public double SpeedInSeconds;
        public LevelsTable(int level, int score, double speedInSeconds)
        {
            Level = level;
            Score = score;
            SpeedInSeconds = speedInSeconds;
        }
    }
    public class LevelsLibrary
    {
        public LevelsTable[] LevelsTable = new LevelsTable[]{
            new LevelsTable(1, 0, 0.5),
            new LevelsTable(2, 100, 0.4),
            new LevelsTable(3, 300, 0.3),
            new LevelsTable(4, 600, 0.25),
            new LevelsTable(5, 1000, 0.2),
            new LevelsTable(6, 1700, 0.15),
            new LevelsTable(7, 2450, 0.1),
            new LevelsTable(8, 3000, 0.085),
            new LevelsTable(9, 4000, 0.065),
            new LevelsTable(10, 5100, 0.045),
            new LevelsTable(11, 6200, 0.03),
            new LevelsTable(12, 7500, 0.02),
            new LevelsTable(13, 9000, 0.01)
        };
    }
}