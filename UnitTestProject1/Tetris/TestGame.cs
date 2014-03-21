using System;
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
            A.CallTo(()=>scene.MoveDown()).MustHaveHappened();
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
            A.CallTo(()=>scene.NextFigure(dummyFigure)).MustHaveHappened();
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
        public void Tick_When_MoveDown_Is_Not_Possible_Should_Select_NextFigure()
        {
            var scene = A.Fake<IScene>();
            var dummyFigure = A.Dummy<IFigure>();
            var randomFigureSelector = A.Fake<IRandomFigureSelector>();
            var game = new Game(scene, randomFigureSelector);
            A.CallTo(() => randomFigureSelector.RandomFigure()).Returns(dummyFigure);
            A.CallTo(() => scene.MoveDown()).Returns(false);
            game.Tick();
            A.CallTo(() => scene.NextFigure(dummyFigure)).MustHaveHappened();
        }
    }
}
