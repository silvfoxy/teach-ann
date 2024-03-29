﻿using FakeItEasy;
using FakeItEasy.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace UnitTestProject1
{
    [TestClass]
    public class TestTetrisCup
    {
        [TestMethod]
        public void How_To_Work()
        {
            TetrisCup tetrisCup = new TetrisCup(10, 20,
                new[] { new Point(3, 4), new Point(4, 3) });
            Assert.AreEqual(-1, tetrisCup.GetColorOfPoint(new Point(3, 4)));
            var clone = tetrisCup.Clone(5);
        }
        [TestMethod]
        public void Clone_Should_Not_Return_Null()
        {
            ITetrisCup tetrisCup = new TetrisCup(10, 20,
                new[] { new Point(3, 4), new Point(4, 3) });
            var cloneTetrisCup = tetrisCup.Clone(6);
            Assert.IsNotNull(cloneTetrisCup);
        }
        [TestMethod]
        public void Clone_Should_Create_Another_Object()
        {
            ITetrisCup tetrisCup = new TetrisCup(10, 20,
                new[] { new Point(3, 4), new Point(4, 3) });
            var cloneTetrisCup = tetrisCup.Clone(7);
            Assert.AreNotSame(tetrisCup, cloneTetrisCup);
        }
        [TestMethod]
        public void Clone_Should_Replace_Minus_Ones_With_Random_Colors()
        {
            ITetrisCup tetrisCup = new TetrisCup(2, 2,
                new[] { new Point(0, 1), new Point(1, 0) });
            var cloneTetrisCup = tetrisCup.Clone(8);
            cloneTetrisCup.GetColorOfPoint(new Point(0, 1)).Should().Be(8);
            cloneTetrisCup.GetColorOfPoint(new Point(1, 0)).Should().Be(8);
            cloneTetrisCup.GetColorOfPoint(new Point(0, 0)).Should().Be(0);
            cloneTetrisCup.GetColorOfPoint(new Point(1, 1)).Should().Be(0);
        }
        [TestMethod]
        public void Clone_Should_Copy_Colors()
        {
            ITetrisCup tetrisCup = new TetrisCup(2, 2,
                new[] { new Point(0, 1), new Point(1, 0) });
            tetrisCup = tetrisCup.Clone(9);
            var cloneTetrisCup = tetrisCup.Clone(9);
            cloneTetrisCup.GetColorOfPoint(new Point(0, 1)).Should().Be(tetrisCup.GetColorOfPoint(new Point(0, 1)));
            cloneTetrisCup.GetColorOfPoint(new Point(1, 0)).Should().Be(tetrisCup.GetColorOfPoint(new Point(1, 0)));
            cloneTetrisCup.GetColorOfPoint(new Point(0, 0)).Should().Be(0);
            cloneTetrisCup.GetColorOfPoint(new Point(1, 1)).Should().Be(0);
        }
        [TestMethod]
        public void GetColorOfPoint_Shoud_Return_Color_Of_Given_Point()
        {
            TetrisCup tetrisCup = new TetrisCup(10, 20,
                new[] { new Point(1, 2) });
            Assert.AreEqual(0, tetrisCup.GetColorOfPoint(new Point(0, 0)));
        }
        [TestMethod]
        public void CopyFrom_Should_Copy_Colors_From_UpperLayer_To_LowerLayer()
        {
            TetrisCup upperLayer = new TetrisCup(2, 2, new[] { new Point(1, 0) });
            TetrisCup lowerLayer = new TetrisCup(2, 2, new Point[] { });
            lowerLayer.CopyFrom(upperLayer, new Offset(0, 0), 42);
            lowerLayer.GetColorOfPoint(new Point(1, 0)).Should().Be(42);
            lowerLayer.GetColorOfPoint(new Point(0, 0)).Should().Be(0);
            lowerLayer.GetColorOfPoint(new Point(0, 1)).Should().Be(0);
            lowerLayer.GetColorOfPoint(new Point(1, 1)).Should().Be(0);
        }
        [TestMethod]
        public void CopyFrom_When_LowerLayer_Is_Bigger_Then_UpperLayer_Should_Not_Throw()
        {
            TetrisCup upperLayer = new TetrisCup(1, 1, new[] { new Point(0, 0) });
            TetrisCup lowerLayer = new TetrisCup(2, 2, new Point[] { });
            lowerLayer.CopyFrom(upperLayer, new Offset(0, 0), 42);
        }
        [TestMethod]
        public void CopyFrom_When_Cell_In_UpperLayer_Is_Empty_Should_Not_Reset_LowerLayer_Cell()
        {
            TetrisCup upperLayer = new TetrisCup(2, 2, new[] { new Point(1, 0) });
            TetrisCup lowerLayer = new TetrisCup(2, 2, new Point[] { new Point(1, 1) });
            lowerLayer.CopyFrom(upperLayer, new Offset(0, 0), 42);
            lowerLayer.GetColorOfPoint(new Point(1, 0)).Should().Be(42);
            lowerLayer.GetColorOfPoint(new Point(0, 0)).Should().Be(0);
            lowerLayer.GetColorOfPoint(new Point(0, 1)).Should().Be(0);
            //CopyFrom не трогает то, что уже было нарисовано в нижней чашке.
            lowerLayer.GetColorOfPoint(new Point(1, 1)).Should().Be(-1);
        }
        [TestMethod]
        public void CopyFrom_Should_Copy_With_Offset()
        {
            TetrisCup upperLayer = new TetrisCup(3, 2, new[] { new Point(1, 0) });
            TetrisCup lowerLayer = new TetrisCup(3, 2, new Point[] {});
            lowerLayer.CopyFrom(upperLayer, new Offset(1, 1), 42);
            lowerLayer.GetColorOfPoint(new Point(0, 0)).Should().Be(0);
            lowerLayer.GetColorOfPoint(new Point(0, 1)).Should().Be(0);
            lowerLayer.GetColorOfPoint(new Point(1, 0)).Should().Be(0); 
            lowerLayer.GetColorOfPoint(new Point(1, 1)).Should().Be(0);
            lowerLayer.GetColorOfPoint(new Point(2, 0)).Should().Be(0);
            lowerLayer.GetColorOfPoint(new Point(2, 1)).Should().Be(42);
        }
        [TestMethod]
        public void Fits_When_Upper_Is_Bigger_Then_Lower_Should_Return_False()
        {
            TetrisCup upper = new TetrisCup(4, 2, new[] { new Point(1, 0) });
            TetrisCup lower = new TetrisCup(3, 2, new Point[] { });
            upper.Fits(lower, new Offset(0, 0)).Should().BeFalse();
        }
        [TestMethod]
        public void Fits_When_Upper_IsNot_Bigger_Then_Lower_Should_Return_True()
        {
            TetrisCup upper = new TetrisCup(3, 2, new[] { new Point(1, 0) });
            TetrisCup lower = new TetrisCup(3, 2, new Point[] { });
            upper.Fits(lower, new Offset(0, 0)).Should().BeTrue();
        }
        [TestMethod]
        public void Fits_When_Upper_With_Offset_Is_Bigger_Then_Lower_Should_Return_False()
        {
            TetrisCup upper = new TetrisCup(3, 2, new[] { new Point(1, 0) });
            TetrisCup lower = new TetrisCup(3, 2, new Point[] { });
            upper.Fits(lower, new Offset(1, 0)).Should().BeFalse();
        }
        [TestMethod]
        public void Fits_When_Some_Bricks_From_Upper_And_Lower_Collide_Should_Return_False()
        {
            TetrisCup upper = new TetrisCup(3, 2, new[] { new Point(1, 0) });
            TetrisCup lower = new TetrisCup(3, 2, new[] { new Point(1, 0) });
            upper.Fits(lower, new Offset(0, 0)).Should().BeFalse();
        }
        [TestMethod]
        public void Fits_When_Some_Bricks_From_Upper_And_Lower_Collide_With_Offset_Should_Return_False()
        {
            TetrisCup upper = new TetrisCup(2, 2, new[] { new Point(1, 0) });
            TetrisCup lower = new TetrisCup(3, 2, new[] { new Point(2, 0) });
            upper.Fits(lower, new Offset(1, 0)).Should().BeFalse();
        }
        [TestMethod]
        public void Fits_When_Offset_Is_Less_Then_0_Should_Return_False()
        {
            TetrisCup upper = new TetrisCup(2, 2, new[] { new Point(1, 0) });
            TetrisCup lower = new TetrisCup(3, 3, new[] { new Point(2, 0) });
            upper.Fits(lower, new Offset(-1, 0)).Should().BeFalse();
        }

        [TestMethod]
        public void Fits2_When_There_Is_No_Obstacles_Return_Fits()
        {
            TetrisCup upper = new TetrisCup(2, 2, new Point[] { });
            TetrisCup lower = new TetrisCup(3, 3, new[] { new Point(2, 0) });
            upper.Fits2(lower, new Offset(1, 0)).Should().Be(FitsResult.Fits);
        }
        [TestMethod]
        public void Fits2_When_There_Is_RightObstacle_Return_RightObstacle()
        {
            TetrisCup upper = new TetrisCup(3, 2, new Point[] { });
            TetrisCup lower = new TetrisCup(3, 3, new Point[] {});
            upper.Fits2(lower, new Offset(1, 0)).Should().Be(FitsResult.RightObstacle);
        }
        [TestMethod]
        public void Fits2_When_Fits_Is_False_Return_BottomObstacle()
        {
            TetrisCup upper = new TetrisCup(3, 2, new[] { new Point(1, 0) });
            TetrisCup lower = new TetrisCup(3, 2, new[] { new Point(1, 0) });
            upper.Fits2(lower, new Offset(0, 0)).Should().Be(FitsResult.BottomObstacle);
        }
        [TestMethod]
        public void IsLineFull_Should_Return_Bool_Value_Is_Line_Full_Or_Not()
        {
            TetrisCup cup = new TetrisCup(2, 3, new[] { new Point(0, 0), new Point(1, 0), new Point(1, 1), new Point(1, 2), new Point(0, 2) });
            cup.IsLineFull(0).Should().BeTrue();
            cup.IsLineFull(1).Should().BeFalse();
            cup.IsLineFull(2).Should().BeTrue();
        }
        [TestMethod]
        public void EraseLine_Should_Reset_All_Cells_In_Line_And_Shift_Others_Down()
        {
            TetrisCup cup = new TetrisCup(2, 3, new[] { new Point(0, 0), new Point(1, 0), new Point(1, 1), new Point(1, 2), new Point(0, 2) });
            cup.EraseLine(0);
            cup.EraseLine(2);
            cup.GetColorOfPoint(new Point(0, 0)).Should().Be(0);
            cup.GetColorOfPoint(new Point(1, 0)).Should().Be(0);
            cup.GetColorOfPoint(new Point(0, 1)).Should().Be(0);
            cup.GetColorOfPoint(new Point(1, 1)).Should().Be(0); 
            cup.GetColorOfPoint(new Point(0, 2)).Should().Be(0);
            cup.GetColorOfPoint(new Point(1, 2)).Should().Be(-1);
        }
    }
}
