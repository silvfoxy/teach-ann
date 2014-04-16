using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            A.CallTo(() => scene.Figure.CurrentRotation.Fits(scene.Cup, new Offset(3, 6)))
                .Returns(true);
            A.CallTo(() => scene.Figure.CurrentRotation.Fits(scene.Cup, new Offset(3, 7)))
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
        public void Rotate_When_BottomObstacle_Should_Move_Up()
        {
            var scene = new Scene();
            scene.Figure = A.Fake<IFigure>();
            scene.Cup = A.Fake<ITetrisCup>();
            scene.Offset = new Offset(1, 1);
            ITetrisCup cup = A.Fake<ITetrisCup>();
            A.CallTo(() => scene.Figure.PeekNextRotation())
                .Returns(cup);
            A.CallTo(() => cup.Fits2(scene.Cup, new Offset(1, 1)))
                .Returns(FitsResult.BottomObstacle);
            scene.Rotate();
            scene.Offset.Y.Should().Be(0);
        }
        [TestMethod]
        public void Rotate_When_BottomObstacle_Should_Move_Up_Till_Fits()
        {
            var scene = new Scene();
            scene.Figure = A.Fake<IFigure>();
            scene.Cup = A.Fake<ITetrisCup>();
            scene.Offset = new Offset(1, 2);
            ITetrisCup cup = A.Fake<ITetrisCup>();
            A.CallTo(() => scene.Figure.PeekNextRotation())
                .Returns(cup);
            A.CallTo(() => cup.Fits2(scene.Cup, new Offset(1, 2)))
                .Returns(FitsResult.BottomObstacle);
            A.CallTo(() => cup.Fits2(scene.Cup, new Offset(1, 1)))
                .Returns(FitsResult.BottomObstacle);
            A.CallTo(() => cup.Fits2(scene.Cup, new Offset(1, 0)))
                 .Returns(FitsResult.Fits);
            scene.Rotate();
            scene.Offset.Y.Should().Be(0);
        }
        [TestMethod]
        public void Rotate_When_TopObstacle_Should_Do_Nothing()
        {
            var scene = new Scene();
            scene.Figure = A.Fake<IFigure>();
            scene.Cup = A.Fake<ITetrisCup>();
            scene.Offset = new Offset(1, 1);
            A.CallTo(() => scene.Figure.PeekNextRotation().Fits2(scene.Cup, new Offset(1, 1)))
                .Returns(FitsResult.TopObstacle);
            scene.Rotate();
            scene.Offset.Y.Should().Be(1);
            scene.Offset.X.Should().Be(1);
        }
        [TestMethod]
        public void Rotate_When_Fits2_Returns_RightObstacle_Should_MoveLeft()
        {
            var scene = new Scene();
            scene.Cup = A.Fake<ITetrisCup>();
            scene.Figure = A.Fake<IFigure>();
            scene.Offset = new Offset(1, 2);
            ITetrisCup cup = A.Fake<ITetrisCup>();
            A.CallTo(() => scene.Figure.PeekNextRotation())
                .Returns(cup);
            A.CallTo(() => cup.Fits2(scene.Cup, new Offset(1, 2)))
                .Returns(FitsResult.RightObstacle);
            A.CallTo(() => cup.Fits2(scene.Cup, new Offset(0, 2)))
                 .Returns(FitsResult.Fits);
            scene.Rotate();
            scene.Offset.X.Should().Be(0);
        }

        [TestMethod]
        public void MoveDown_When_Fits_Return_True_Should_Increment_OffsetY()
        {
            var scene = new Scene();
            scene.Cup = A.Fake<ITetrisCup>();
            scene.Figure = A.Fake<IFigure>();
            scene.Offset = new Offset(3, 5);
            A.CallTo(() => scene.Figure.CurrentRotation.Fits(scene.Cup, new Offset(3, 6)))
                .Returns(true);
            scene.MoveDown().Should().BeTrue();
            scene.Offset.Y.Should().Be(6);
        }
        [TestMethod]
        public void MoveDown_When_Fits_Return_False_Should_Not_Change_OffsetY()
        {
            var scene = new Scene();
            scene.Cup = A.Fake<ITetrisCup>();
            scene.Figure = A.Fake<IFigure>();
            scene.Offset = new Offset(3, 5);
            A.CallTo(() => scene.Cup.Fits(scene.Figure.CurrentRotation, new Offset(3, 6)))
                .Returns(false);
            scene.MoveDown().Should().BeFalse();
            scene.Offset.Y.Should().Be(5);
        }
        [TestMethod]
        public void MoveRight_When_Fits_Return_True_Should_Increment_OffsetX()
        {
            var scene = new Scene();
            scene.Cup = A.Fake<ITetrisCup>();
            scene.Figure = A.Fake<IFigure>();
            scene.Offset = new Offset(3, 5);
            A.CallTo(() => scene.Figure.CurrentRotation.Fits(scene.Cup, new Offset(4, 5)))
                .Returns(true);
            scene.MoveRight();
            scene.Offset.X.Should().Be(4);
        }
        [TestMethod]
        public void MoveRight_When_Fits_Return_False_Should_Not_Change_OffsetX()
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
        public void MoveLeft_When_Fits_Return_True_Should_Deccrement_OffsetX()
        {
            var scene = new Scene();
            scene.Cup = A.Fake<ITetrisCup>();
            scene.Figure = A.Fake<IFigure>();
            scene.Offset = new Offset(3, 5);
            A.CallTo(() => scene.Figure.CurrentRotation.Fits(scene.Cup, new Offset(2, 5)))
                .Returns(true);
            scene.MoveLeft();
            scene.Offset.X.Should().Be(2);
        }
        [TestMethod]
        public void MoveLeft_When_Fits_Return_False_Should_Not_Change_OffsetX()
        {
            var scene = new Scene();
            scene.Cup = A.Fake<ITetrisCup>();
            scene.Figure = A.Fake<IFigure>();
            scene.Offset = new Offset(3, 5);
            scene.MoveLeft();
            scene.Offset.X.Should().Be(3);
        }

        [TestMethod]
        public void NextFigure_When_The_Given_Figure_Fits_Should_Return_True()
        {
            var scene = new Scene();
            scene.Cup = A.Fake<ITetrisCup>();
            var figure = A.Fake<IFigure>();
            A.CallTo(() => scene.Cup.Width).Returns(10);
            A.CallTo(() => figure.CurrentRotation.Width).Returns(4);
            A.CallTo(() => figure.CurrentRotation.Fits(scene.Cup, new Offset(3, 0)))
                .Returns(true);
            scene.NextFigure(figure).Should().Be(true);
        }
        [TestMethod]
        public void NextFigure_When_The_Given_Figure_Fits_Should_Assign_It()
        {
            var scene = new Scene();
            scene.Cup = A.Fake<ITetrisCup>();
            var dummyFigure = A.Dummy<IFigure>();
            A.CallTo(() => dummyFigure.CurrentRotation.Fits(null, null))
                .WithAnyArguments().Returns(true);
            scene.NextFigure(dummyFigure);
            scene.Figure.Should().Be(dummyFigure);
        }
        [TestMethod]
        public void NextFigure_When_The_Given_Figure_DoesNot_Fit_ShouldNot_Assign_It()
        {
            var scene = new Scene();
            scene.Cup = A.Fake<ITetrisCup>();
            var dummyFigure = A.Dummy<IFigure>();
            A.CallTo(() => scene.Cup.Fits(null, null))
                .WithAnyArguments().Returns(false);
            scene.NextFigure(dummyFigure);
            scene.Figure.Should().NotBe(dummyFigure);
        }
        [TestMethod]
        public void NextFigure_When_The_Given_Figure_Fits_Should_Assign_Offset()
        {
            var scene = new Scene();
            scene.Cup = A.Fake<ITetrisCup>();
            var figure = A.Fake<IFigure>();
            A.CallTo(() => scene.Cup.Width).Returns(10);
            A.CallTo(() => figure.CurrentRotation.Width).Returns(4);
            A.CallTo(() => figure.CurrentRotation.Fits(scene.Cup, new Offset(3, 0)))
                .Returns(true);
            scene.NextFigure(figure);
            scene.Offset.Should().Be(new Offset(3, 0));
        }
        [TestMethod]
        public void NextFigure_When_The_Given_Figure_DoesNot_Fit_ShouldNot_Assign_Offset()
        {
            var scene = new Scene();
            scene.Cup = A.Fake<ITetrisCup>();
            var figure = A.Fake<IFigure>();
            A.CallTo(() => scene.Cup.Width).Returns(10);
            A.CallTo(() => figure.CurrentRotation.Width).Returns(4);
            A.CallTo(() => scene.Cup.Fits(figure.CurrentRotation, new Offset(3, 0)))
                .Returns(false);
            scene.NextFigure(figure);
            scene.Offset.Should().NotBe(new Offset(3, 0));
        }
        [TestMethod]
        public void NextFigure_Should_Color_Figure()
        {
            var scene = new Scene();
            scene.Cup = A.Fake<ITetrisCup>();
            var figure = A.Fake<IFigure>();
            A.CallTo(() => scene.Cup.Width).Returns(10);
            A.CallTo(() => figure.CurrentRotation.Width).Returns(4);
            A.CallTo(() => figure.CurrentRotation.Fits(scene.Cup, new Offset(3, 0)))
                .Returns(true);
            scene.NextFigure(figure);
            A.CallTo(() => scene.Figure.ColorFigure()).MustHaveHappened();
        }

        [TestMethod]
        public void Print_Should_Copy_CurrentRotation_To_The_Cup()
        {
            var scene = new Scene();
            scene.Cup = A.Fake<ITetrisCup>();
            scene.Figure = A.Fake<IFigure>();
            scene.Figure.Color = 42;
            scene.Offset = new Offset(9, 2);
            var dummyCup = A.Dummy<ITetrisCup>();
            A.CallTo(() => scene.Figure.CurrentRotation).Returns(dummyCup);
            scene.Print();
            A.CallTo(() => scene.Cup.CopyFrom(dummyCup, new Offset(9, 2), 42))
                .MustHaveHappened();
        }

        [TestMethod]
        public void GetColorOfPoint_Should_Return_Color_From_Cup_Or_Figure()
        {
            var scene = new Scene();
            scene.Figure = A.Fake<IFigure>();
            scene.Figure.Color = 42;
            scene.Cup = A.Fake<ITetrisCup>();
            scene.Offset = new Offset(9, 2);
            var cloneCup = A.Fake<ITetrisCup>();
            A.CallTo(() => scene.Cup.Clone(-2)).Returns(cloneCup);
            A.CallTo(() => cloneCup.GetColorOfPoint(new Point(9, 2))).Returns(24);
            scene.GetColorOfPoint(new Point(9, 2)).Should().Be(24);
            A.CallTo(() => cloneCup.CopyFrom(scene.Figure.CurrentRotation, scene.Offset, 42))
                .MustHaveHappened();
        }
        [TestMethod]
        public void EraseFullLines_Should_Delete_Full_Lines()
        {
            var scene = new Scene();
            scene.Cup = A.Fake<ITetrisCup>();
            A.CallTo(() => scene.Cup.IsLineFull(0)).Returns(true);
            A.CallTo(() => scene.Cup.IsLineFull(1)).Returns(false);
            A.CallTo(() => scene.Cup.IsLineFull(2)).Returns(true);
            A.CallTo(() => scene.Cup.Height).Returns(3);
            scene.EraseFullLines();
            A.CallTo(() => scene.Cup.EraseLine(0)).MustHaveHappened();
            A.CallTo(() => scene.Cup.EraseLine(2)).MustHaveHappened();
        }
    }
}
