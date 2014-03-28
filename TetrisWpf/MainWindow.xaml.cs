using System;
using System.Collections.Generic;
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
        public Dictionary<int, Brush> Brushes = new Dictionary<int, Brush>
        {
            {0, System.Windows.Media.Brushes.Transparent},
            {1, System.Windows.Media.Brushes.Red},
            {2, System.Windows.Media.Brushes.Blue},
            {3, System.Windows.Media.Brushes.Yellow},
            {4, System.Windows.Media.Brushes.Green},
            {5, System.Windows.Media.Brushes.DarkViolet},
            {6, System.Windows.Media.Brushes.Orange},
            {7, System.Windows.Media.Brushes.DeepSkyBlue},
            {8, System.Windows.Media.Brushes.LimeGreen},
            {9, System.Windows.Media.Brushes.DeepPink},
            {10, System.Windows.Media.Brushes.MediumTurquoise},
            {11, System.Windows.Media.Brushes.MediumOrchid},
            {12, System.Windows.Media.Brushes.IndianRed},
            {13, System.Windows.Media.Brushes.Coral},
            {14, System.Windows.Media.Brushes.DodgerBlue},
            {15, System.Windows.Media.Brushes.MediumSeaGreen},
        };  
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
                var color = Game.Scene.GetColorOfPoint(new Point(j, i));
                var rectangle = new Rectangle();
                rectangle.Fill = Brushes[color];
                _uniformGrid.Children.Add(rectangle);
            }
        }
    }
}
