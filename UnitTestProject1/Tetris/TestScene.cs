﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;

namespace UnitTestProject1.Tetris
{
    [TestClass]
    public class TestScene
    {
        [TestMethod]
        public void DropDown_Should_Shift_Down_By_Changing_Offset_Till_It_Is_Possible()
        {
            var scene = new Scene();
            scene.Cup = A.Fake<ITetrisCup>();
            scene.Figure = A.Fake<IFigure>();
            scene.Offset = new Offset(3, 5);
            A.CallTo(() => scene.Cup.Fits(scene.Figure.CurrentRotation, new Offset(3, 6)))
                .Returns(true);
            A.CallTo(() => scene.Cup.Fits(scene.Figure.CurrentRotation, new Offset(3, 7)))
                .Returns(false);
            scene.DropDown();
            scene.Offset.Y.Should().Be(6);
        }
        [TestMethod]
        public void Rotate_Should_Call_NextRotation()
        {
            var scene = new Scene();
            scene.Figure = A.Fake<IFigure>();
            scene.Rotate();
            A.CallTo(() => scene.Figure.NextRotation())
                .MustHaveHappened();
        }

        [TestMethod]
        public void MoveDown_Should_Increment_OffsetY_If_Fits_Return_True()
        {
            var scene = new Scene();
            scene.Cup = A.Fake<ITetrisCup>();
            scene.Figure = A.Fake<IFigure>();
            scene.Offset = new Offset(3, 5);
            A.CallTo(() => scene.Cup.Fits(scene.Figure.CurrentRotation, new Offset(3, 6)))
                .Returns(true);
            scene.MoveDown();
            scene.Offset.Y.Should().Be(6);
        }
        [TestMethod]
        public void MoveDown_Should_Not_Change_OffsetY_If_Fits_Return_False()
        {
            var scene = new Scene();
            scene.Cup = A.Fake<ITetrisCup>();
            scene.Figure = A.Fake<IFigure>();
            scene.Offset = new Offset(3, 5);
            A.CallTo(() => scene.Cup.Fits(scene.Figure.CurrentRotation, new Offset(3, 6)))
                .Returns(false);
            scene.MoveDown();
            scene.Offset.Y.Should().Be(5);
        }
        [TestMethod]
        public void MoveRight_Should_Increment_OffsetX_If_Fits_Return_True()
        {
            var scene = new Scene();
            scene.Cup = A.Fake<ITetrisCup>();
            scene.Figure = A.Fake<IFigure>();
            scene.Offset = new Offset(3, 5);
            A.CallTo(() => scene.Cup.Fits(scene.Figure.CurrentRotation, new Offset(4, 5)))
                .Returns(true);
            scene.MoveRight();
            scene.Offset.X.Should().Be(4);
        }
        [TestMethod]
        public void MoveRight_Should_Not_Change_OffsetX_If_Fits_Return_False()
        {
            var scene = new Scene();
            scene.Cup = A.Fake<ITetrisCup>();
            scene.Figure = A.Fake<IFigure>();
            scene.Offset = new Offset(3, 5);
            A.CallTo(() => scene.Cup.Fits(scene.Figure.CurrentRotation, new Offset(4, 5)))
                .Returns(false);
            scene.MoveRight();
            scene.Offset.X.Should().Be(3);
        }
        [TestMethod]
        public void MoveLeft_Should_Deccrement_OffsetX_If_Fits_Return_True()
        {
            var scene = new Scene();
            scene.Cup = A.Fake<ITetrisCup>();
            scene.Figure = A.Fake<IFigure>();
            scene.Offset = new Offset(3, 5);
            A.CallTo(() => scene.Cup.Fits(scene.Figure.CurrentRotation, new Offset(2, 5)))
                .Returns(true);
            scene.MoveLeft();
            scene.Offset.X.Should().Be(2);
        }
        [TestMethod]
        public void MoveLeft_Should_Not_Change_OffsetX_If_Fits_Return_False()
        {
            var scene = new Scene();
            scene.Cup = A.Fake<ITetrisCup>();
            scene.Figure = A.Fake<IFigure>();
            scene.Offset = new Offset(3, 5);
            A.CallTo(() => scene.Cup.Fits(scene.Figure.CurrentRotation, new Offset(2, 5)))
                .Returns(false);
            scene.MoveLeft();
            scene.Offset.X.Should().Be(3);
        }
    }
}
