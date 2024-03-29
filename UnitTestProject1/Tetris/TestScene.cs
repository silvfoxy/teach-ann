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
        Scene _scene;
        [TestInitialize]
        public void SetUp()
        {
            _scene = new Scene();
            _scene.Cup = A.Fake<ITetrisCup>();
            _scene.Figure = A.Fake<IFigure>();
        }
        [TestMethod]
        public void DropDown_Should_Shift_Down_By_Changing_Offset_Till_It_Is_Possible()
        {
            _scene.Offset = new Offset(3, 5);
            A.CallTo(() => _scene.Figure.CurrentRotation.Fits(_scene.Cup, new Offset(3, 6)))
                .Returns(true);
            A.CallTo(() => _scene.Figure.CurrentRotation.Fits(_scene.Cup, new Offset(3, 7)))
                .Returns(false);
            _scene.DropDown();
            _scene.Offset.Y.Should().Be(6);
        }
        [TestMethod]
        public void Rotate_Should_Call_NextRotation()
        {
            _scene.Rotate();
            A.CallTo(() => _scene.Figure.NextRotation())
                .MustHaveHappened();
        }
        [TestMethod]
        public void Rotate_When_BottomObstacle_Should_Move_Up()
        {
            _scene.Offset = new Offset(1, 1);
            ITetrisCup cup = A.Fake<ITetrisCup>();
            A.CallTo(() => _scene.Figure.PeekNextRotation())
                .Returns(cup);
            A.CallTo(() => cup.Fits2(_scene.Cup, new Offset(1, 1)))
                .Returns(FitsResult.BottomObstacle);
            _scene.Rotate();
            _scene.Offset.Y.Should().Be(0);
        }
        [TestMethod]
        public void Rotate_When_BottomObstacle_Should_Move_Up_Till_Fits()
        {


            _scene.Offset = new Offset(1, 2);
            ITetrisCup cup = A.Fake<ITetrisCup>();
            A.CallTo(() => _scene.Figure.PeekNextRotation())
                .Returns(cup);
            A.CallTo(() => cup.Fits2(_scene.Cup, new Offset(1, 2)))
                .Returns(FitsResult.BottomObstacle);
            A.CallTo(() => cup.Fits2(_scene.Cup, new Offset(1, 1)))
                .Returns(FitsResult.BottomObstacle);
            A.CallTo(() => cup.Fits2(_scene.Cup, new Offset(1, 0)))
                 .Returns(FitsResult.Fits);
            _scene.Rotate();
            _scene.Offset.Y.Should().Be(0);
        }
        [TestMethod]
        public void Rotate_When_TopObstacle_Should_Do_Nothing()
        {


            _scene.Offset = new Offset(1, 1);
            A.CallTo(() => _scene.Figure.PeekNextRotation().Fits2(_scene.Cup, new Offset(1, 1)))
                .Returns(FitsResult.TopObstacle);
            _scene.Rotate();
            _scene.Offset.Y.Should().Be(1);
            _scene.Offset.X.Should().Be(1);
        }
        [TestMethod]
        public void Rotate_When_Fits2_Returns_RightObstacle_Should_MoveLeft()
        {


            _scene.Offset = new Offset(1, 2);
            ITetrisCup cup = A.Fake<ITetrisCup>();
            A.CallTo(() => _scene.Figure.PeekNextRotation())
                .Returns(cup);
            A.CallTo(() => cup.Fits2(_scene.Cup, new Offset(1, 2)))
                .Returns(FitsResult.RightObstacle);
            A.CallTo(() => cup.Fits2(_scene.Cup, new Offset(0, 2)))
                 .Returns(FitsResult.Fits);
            _scene.Rotate();
            _scene.Offset.X.Should().Be(0);
        }

        [TestMethod]
        public void MoveDown_When_Fits_Return_True_Should_Increment_OffsetY()
        {


            _scene.Offset = new Offset(3, 5);
            A.CallTo(() => _scene.Figure.CurrentRotation.Fits(_scene.Cup, new Offset(3, 6)))
                .Returns(true);
            _scene.MoveDown().Should().BeTrue();
            _scene.Offset.Y.Should().Be(6);
        }
        [TestMethod]
        public void MoveDown_When_Fits_Return_False_Should_Not_Change_OffsetY()
        {


            _scene.Offset = new Offset(3, 5);
            A.CallTo(() => _scene.Cup.Fits(_scene.Figure.CurrentRotation, new Offset(3, 6)))
                .Returns(false);
            _scene.MoveDown().Should().BeFalse();
            _scene.Offset.Y.Should().Be(5);
        }
        [TestMethod]
        public void MoveRight_When_Fits_Return_True_Should_Increment_OffsetX()
        {


            _scene.Offset = new Offset(3, 5);
            A.CallTo(() => _scene.Figure.CurrentRotation.Fits(_scene.Cup, new Offset(4, 5)))
                .Returns(true);
            _scene.MoveRight();
            _scene.Offset.X.Should().Be(4);
        }
        [TestMethod]
        public void MoveRight_When_Fits_Return_False_Should_Not_Change_OffsetX()
        {


            _scene.Offset = new Offset(3, 5);
            A.CallTo(() => _scene.Cup.Fits(_scene.Figure.CurrentRotation, new Offset(4, 5)))
                .Returns(false);
            _scene.MoveRight();
            _scene.Offset.X.Should().Be(3);
        }
        [TestMethod]
        public void MoveLeft_When_Fits_Return_True_Should_Deccrement_OffsetX()
        {


            _scene.Offset = new Offset(3, 5);
            A.CallTo(() => _scene.Figure.CurrentRotation.Fits(_scene.Cup, new Offset(2, 5)))
                .Returns(true);
            _scene.MoveLeft();
            _scene.Offset.X.Should().Be(2);
        }
        [TestMethod]
        public void MoveLeft_When_Fits_Return_False_Should_Not_Change_OffsetX()
        {


            _scene.Offset = new Offset(3, 5);
            _scene.MoveLeft();
            _scene.Offset.X.Should().Be(3);
        }

        [TestMethod]
        public void NextFigure_When_The_Given_Figure_Fits_Should_Return_True()
        {

            var figure = A.Fake<IFigure>();
            A.CallTo(() => _scene.Cup.Width).Returns(10);
            A.CallTo(() => figure.CurrentRotation.Width).Returns(4);
            A.CallTo(() => figure.CurrentRotation.Fits(_scene.Cup, new Offset(3, 0)))
                .Returns(true);
            _scene.NextFigure(figure).Should().Be(true);
        }
        [TestMethod]
        public void NextFigure_When_The_Given_Figure_Fits_Should_Assign_It()
        {

            var dummyFigure = A.Dummy<IFigure>();
            A.CallTo(() => dummyFigure.CurrentRotation.Fits(null, null))
                .WithAnyArguments().Returns(true);
            _scene.NextFigure(dummyFigure);
            _scene.Figure.Should().Be(dummyFigure);
        }
        [TestMethod]
        public void NextFigure_When_The_Given_Figure_DoesNot_Fit_ShouldNot_Assign_It()
        {

            var dummyFigure = A.Dummy<IFigure>();
            A.CallTo(() => _scene.Cup.Fits(null, null))
                .WithAnyArguments().Returns(false);
            _scene.NextFigure(dummyFigure);
            _scene.Figure.Should().NotBe(dummyFigure);
        }
        [TestMethod]
        public void NextFigure_When_The_Given_Figure_Fits_Should_Assign_Offset()
        {

            var figure = A.Fake<IFigure>();
            A.CallTo(() => _scene.Cup.Width).Returns(10);
            A.CallTo(() => figure.CurrentRotation.Width).Returns(4);
            A.CallTo(() => figure.CurrentRotation.Fits(_scene.Cup, new Offset(3, 0)))
                .Returns(true);
            _scene.NextFigure(figure);
            _scene.Offset.Should().Be(new Offset(3, 0));
        }
        [TestMethod]
        public void NextFigure_When_The_Given_Figure_DoesNot_Fit_ShouldNot_Assign_Offset()
        {

            var figure = A.Fake<IFigure>();
            A.CallTo(() => _scene.Cup.Width).Returns(10);
            A.CallTo(() => figure.CurrentRotation.Width).Returns(4);
            A.CallTo(() => _scene.Cup.Fits(figure.CurrentRotation, new Offset(3, 0)))
                .Returns(false);
            _scene.NextFigure(figure);
            _scene.Offset.Should().NotBe(new Offset(3, 0));
        }
        [TestMethod]
        public void NextFigure_Should_Color_Figure()
        {

            var figure = A.Fake<IFigure>();
            A.CallTo(() => _scene.Cup.Width).Returns(10);
            A.CallTo(() => figure.CurrentRotation.Width).Returns(4);
            A.CallTo(() => figure.CurrentRotation.Fits(_scene.Cup, new Offset(3, 0)))
                .Returns(true);
            _scene.NextFigure(figure);
            A.CallTo(() => _scene.Figure.ColorFigure()).MustHaveHappened();
        }

        [TestMethod]
        public void Print_Should_Copy_CurrentRotation_To_The_Cup()
        {


            _scene.Figure.Color = 42;
            _scene.Offset = new Offset(9, 2);
            var dummyCup = A.Dummy<ITetrisCup>();
            A.CallTo(() => _scene.Figure.CurrentRotation).Returns(dummyCup);
            _scene.Print();
            A.CallTo(() => _scene.Cup.CopyFrom(dummyCup, new Offset(9, 2), 42))
                .MustHaveHappened();
        }

        [TestMethod]
        public void GetColorOfPoint_Should_Return_Color_From_Cup_Or_Figure()
        {

            _scene.Figure.Color = 42;

            _scene.Offset = new Offset(9, 2);
            var cloneCup = A.Fake<ITetrisCup>();
            A.CallTo(() => _scene.Cup.Clone(-2)).Returns(cloneCup);
            A.CallTo(() => cloneCup.GetColorOfPoint(new Point(9, 2))).Returns(24);
            _scene.GetColorOfPoint(new Point(9, 2)).Should().Be(24);
            A.CallTo(() => cloneCup.CopyFrom(_scene.Figure.CurrentRotation, _scene.Offset, 42))
                .MustHaveHappened();
        }
        [TestMethod]
        public void EraseFullLines_Should_Delete_Full_Lines()
        {

            A.CallTo(() => _scene.Cup.IsLineFull(0)).Returns(true);
            A.CallTo(() => _scene.Cup.IsLineFull(1)).Returns(false);
            A.CallTo(() => _scene.Cup.IsLineFull(2)).Returns(true);
            A.CallTo(() => _scene.Cup.Height).Returns(3);
            _scene.EraseFullLines();
            A.CallTo(() => _scene.Cup.EraseLine(0)).MustHaveHappened();
            A.CallTo(() => _scene.Cup.EraseLine(2)).MustHaveHappened();
        }
        [TestMethod]
        public void EraseFullLines_Should_Return_Number_Of_Full_Lines()
        {

            A.CallTo(() => _scene.Cup.IsLineFull(0)).Returns(true);
            A.CallTo(() => _scene.Cup.IsLineFull(1)).Returns(false);
            A.CallTo(() => _scene.Cup.IsLineFull(2)).Returns(true);
            A.CallTo(() => _scene.Cup.Height).Returns(3);
            _scene.EraseFullLines().Should().Be(2);
        }
    }
}
