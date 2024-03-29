﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
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
            {16, System.Windows.Media.Brushes.HotPink},
        };
        public MainWindow()
        {
            Game = new Game(new Scene(), new RandomFigureSelector());
            DispatcherTimer = new DispatcherTimer(TimeSpan.FromSeconds(Game.SpeedInSeconds), DispatcherPriority.ApplicationIdle, OnTick, Dispatcher);
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
            //for (int i = 0; i < 25; i++)
                //for (int j = 0; j < 15; j++)
            foreach (var point in Game.Scene.Cup.AllCells)
                {
                    var color = Game.Scene.GetColorOfPoint(point);
                    var rectangle = new Rectangle();
                    rectangle.Fill = Brushes[color];
                    rectangle.Margin = new Thickness(1, 1, 0, 0);
                    _uniformGrid.Children.Add(rectangle);
                }
            if (DispatcherTimer.Interval != TimeSpan.FromSeconds(Game.SpeedInSeconds))
                DispatcherTimer.Interval = TimeSpan.FromSeconds(Game.SpeedInSeconds);
            _score.Text = Game.Score.ToString();
            _level.Text = Game.Level.ToString();
            _speed.Text = Game.SpeedInSeconds.ToString();
        }

        private void MainWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left: Game.Scene.MoveLeft();
                    break;
                case Key.Up: Game.Scene.Rotate();
                    break;
                case Key.Down: Game.Scene.MoveDown();
                    break;
                case Key.Right: Game.Scene.MoveRight();
                    break;
                case Key.Space: Game.Scene.DropDown();
                    break;
            }
            UpdateScreen();
        }
    }
}
