﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1.Tetris
{
    [TestClass]
    public class TestGame
    {
        [TestMethod]
        public void Tick_Should_Call_Scene_MoveDown()
        {
            var scene = A.Fake<IScene>();
            var randomFigureSelector = A.Fake<IRandomFigureSelector>();
            var game = new Game(scene, randomFigureSelector);
            game.Tick();
            A.CallTo(() => scene.MoveDown()).MustHaveHappened();
        }

        [TestMethod]
        public void Constructor_Should_Set_Fields()
        {
            var scene = A.Fake<IScene>();
            var randomFigureSelector = A.Fake<IRandomFigureSelector>();
            var game = new Game(scene, randomFigureSelector);
            game.Scene.Should().Be(scene);
        }
        [TestMethod]
        public void Constructor_Should_Call_Scene_NextFigure()
        {
            var scene = A.Fake<IScene>();
            var dummyFigure = A.Dummy<IFigure>();
            var randomFigureSelector = A.Fake<IRandomFigureSelector>();
            A.CallTo(() => randomFigureSelector.RandomFigure()).Returns(dummyFigure);
            var game = new Game(scene, randomFigureSelector);
            A.CallTo(() => scene.NextFigure(dummyFigure)).MustHaveHappened();
        }
        [TestMethod]
        public void Constructor_Should_Set_NextFigure()
        {
            var scene = A.Fake<IScene>();
            var dummyFigure = A.Dummy<IFigure>();
            var randomFigureSelector = A.Fake<IRandomFigureSelector>();
            A.CallTo(() => randomFigureSelector.RandomFigure()).Returns(dummyFigure);
            var game = new Game(scene, randomFigureSelector);
            game.NextFigure.Should().Be(dummyFigure);
        }
        public void Constructor_Should_Set_Level_And_SpeedInSeconds()
        {
            var scene = A.Fake<IScene>();
            var randomFigureSelector = A.Fake<IRandomFigureSelector>();
            var game = new Game(scene, randomFigureSelector);
            game.Level.Should().Be(1);
            game.SpeedInSeconds.Should().Be(0.5);
        }
        [TestMethod]
        public void Tick_Should_Set_NextFigure()
        {
            var scene = A.Fake<IScene>();
            var dummyFigure = A.Dummy<IFigure>();
            var nextDummyFigure = A.Dummy<IFigure>();
            var randomFigureSelector = A.Fake<IRandomFigureSelector>();
            var game = new Game(scene, randomFigureSelector);
            game.NextFigure = dummyFigure;
            A.CallTo(()=> randomFigureSelector.RandomFigure()).Returns(nextDummyFigure);
            game.Tick();
            A.CallTo(()=> scene.NextFigure(dummyFigure)).MustHaveHappened();
            game.NextFigure.Should().Be(nextDummyFigure);
        }

        [TestMethod]
        public void Tick_When_MoveDown_Is_Not_Possible_Should_Print()
        {
            var scene = A.Fake<IScene>();
            var randomFigureSelector = A.Fake<IRandomFigureSelector>();
            var game = new Game(scene, randomFigureSelector);
            A.CallTo(() => scene.MoveDown()).Returns(false);
            game.Tick();
            A.CallTo(() => scene.Print()).MustHaveHappened();
        }
        [TestMethod]
        public void Tick_When_Print_Should_EraseFullLines()
        {
            var scene = A.Fake<IScene>();
            var randomFigureSelector = A.Fake<IRandomFigureSelector>();
            var game = new Game(scene, randomFigureSelector);
            A.CallTo(() => scene.MoveDown()).Returns(false);
            game.Tick();
            A.CallTo(() => scene.EraseFullLines()).MustHaveHappened();
        }
        [TestMethod]
        public void Tick_When_EraseFullLines_Should_Set_Score()
        {
            var scene = A.Fake<IScene>();
            var randomFigureSelector = A.Fake<IRandomFigureSelector>();
            var game = new Game(scene, randomFigureSelector);
            game.Score = 100;
            A.CallTo(() => scene.MoveDown()).Returns(false);
            A.CallTo(() => scene.EraseFullLines()).Returns(1);
            game.Tick();
            A.CallTo(() => scene.EraseFullLines()).MustHaveHappened();
            game.Score.Should().Be(111);
        }
        [TestMethod]
        public void Tick_When_Print_Should_Increment_Score()
        {
            var scene = A.Fake<IScene>();
            var randomFigureSelector = A.Fake<IRandomFigureSelector>();
            var game = new Game(scene, randomFigureSelector);
            A.CallTo(() => scene.MoveDown()).Returns(false);
            game.Score = 100;
            game.Tick();
            game.Score.Should().Be(101);
        }
        public void Tick_Should_Call_SetLevel()
        {
            var scene = A.Fake<IScene>();
            var randomFigureSelector = A.Fake<IRandomFigureSelector>();
            var game = new Game(scene, randomFigureSelector);
            game.Tick();
            A.CallTo(() => game.SetLevel()).MustHaveHappened();
        }
        [TestMethod]
        public void Tick_When_MoveDown_Is_Not_Possible_Should_Select_NextFigure()
        {
            var scene = A.Fake<IScene>();
            var dummyFigure = A.Dummy<IFigure>();
            var randomFigureSelector = A.Fake<IRandomFigureSelector>();
            var game = new Game(scene, randomFigureSelector);
            game.NextFigure = dummyFigure;
            A.CallTo(() => scene.MoveDown()).Returns(false);
            game.Tick();
            A.CallTo(() => scene.NextFigure(dummyFigure)).MustHaveHappened();
        }
        [TestMethod]
        public void SetLevel_When_Score_Is_Enough_Should_Set_Level_And_SpeedInSeconds()
        {
            var scene = A.Fake<IScene>();
            var dummyFigure = A.Dummy<IFigure>();
            var randomFigureSelector = A.Fake<IRandomFigureSelector>();
            var game = new Game(scene, randomFigureSelector);
            game.Level=1;
            game.Score = 101;
            game.Tick();
            game.Level.Should().Be(2);
            game.SpeedInSeconds.Should().Be(0.4);
        }
        [TestMethod]
        public void Constructor_Should_Initialize_Cup_With_Width_10_And_Height_20()
        {
            var scene = A.Fake<IScene>();
            var randomFigureSelector = A.Fake<IRandomFigureSelector>();
            new Game(scene, randomFigureSelector);
            scene.Cup.Height.Should().Be(20);
            scene.Cup.Width.Should().Be(10);
            for (int x=0; x<scene.Cup.Width; x++)
                for (int y = 0; y < scene.Cup.Height; y++)
                    scene.Cup.GetColorOfPoint(new Point(x, y)).Should().Be(0);
        }
    }
}
