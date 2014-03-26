using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using UnitTestProject1.Tetris;
using Point = UnitTestProject1.Point;

namespace TetrisWpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Game Game;
        public DispatcherTimer DispatcherTimer;
        public MainWindow()
        {
            Game = new Game(new Scene(), new RandomFigureSelector());
            DispatcherTimer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.ApplicationIdle, OnTick, Dispatcher);
            InitializeComponent();
        }

        private void OnTick(object sender, EventArgs e)
        {
            Game.Tick();
            UpdateScreen();
        }

        private void UpdateScreen()
        {
            _uniformGrid.Children.Clear();
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 20; j++)
            {
                var color = Game.Scene.Cup.GetColor(new Point(i, j));
                var rectangle = new Rectangle();
                if (color == 0) rectangle.Fill = Brushes.Transparent;
                else rectangle.Fill = Brushes.Red;
                _uniformGrid.Children.Add(rectangle);
            }
        }
    }
}
