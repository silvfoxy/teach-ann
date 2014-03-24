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
            Assert.AreEqual(-1, tetrisCup.GetColor(new Point(3, 4)));
            TetrisCup clone = tetrisCup.Clone();
        }
        [TestMethod]
        public void Clone_Should_Not_Return_Null()
        {
            TetrisCup tetrisCup = new TetrisCup(10, 20,
                new[] { new Point(3, 4), new Point(4, 3) });
            TetrisCup cloneTetrisCup = tetrisCup.Clone();
            Assert.IsNotNull(cloneTetrisCup);
        }
        [TestMethod]
        public void Clone_Should_Create_Another_Object()
        {
            TetrisCup tetrisCup = new TetrisCup(10, 20,
                new[] { new Point(3, 4), new Point(4, 3) });
            TetrisCup cloneTetrisCup = tetrisCup.Clone();
            Assert.AreNotSame(tetrisCup, cloneTetrisCup);
        }
        [TestMethod]
        public void Clone_Should_Replace_Minus_Ones_With_Random_Colors()
        {
            TetrisCup tetrisCup = new TetrisCup(2, 2,
                new[] { new Point(0, 1), new Point(1, 0) });
            TetrisCup cloneTetrisCup = tetrisCup.Clone();
            cloneTetrisCup.GetColor(new Point(0, 1)).Should().BeInRange(1, 16);
            cloneTetrisCup.GetColor(new Point(1, 0)).Should().BeInRange(1, 16);
            cloneTetrisCup.GetColor(new Point(0, 0)).Should().Be(0);
            cloneTetrisCup.GetColor(new Point(1, 1)).Should().Be(0);
        }
        [TestMethod]
        public void Clone_Should_Copy_Colors()
        {
            TetrisCup tetrisCup = new TetrisCup(2, 2,
                new[] { new Point(0, 1), new Point(1, 0) });
            tetrisCup = tetrisCup.Clone();
            TetrisCup cloneTetrisCup = tetrisCup.Clone();
            cloneTetrisCup.GetColor(new Point(0, 1)).Should().Be(tetrisCup.GetColor(new Point(0, 1)));
            cloneTetrisCup.GetColor(new Point(1, 0)).Should().Be(tetrisCup.GetColor(new Point(1, 0)));
            cloneTetrisCup.GetColor(new Point(0, 0)).Should().Be(0);
            cloneTetrisCup.GetColor(new Point(1, 1)).Should().Be(0);
        }
        [TestMethod]
        public void GetColor_Shoud_Return_Color_Of_Given_Point()
        {
            TetrisCup tetrisCup = new TetrisCup(10, 20,
                new[] { new Point(1, 2) });
            Assert.AreEqual(0, tetrisCup.GetColor(new Point(0, 0)));
        }
        [TestMethod]
        public void CopyFrom_Should_Copy_Colors_From_UpperLayer_To_LowerLayer()
        {
            TetrisCup upperLayer = new TetrisCup(2, 2, new[] { new Point(1, 0) });
            TetrisCup lowerLayer = new TetrisCup(2, 2, new Point[] { });
            lowerLayer.CopyFrom(upperLayer, new Offset(0, 0));
            lowerLayer.GetColor(new Point(1, 0)).Should().Be(-1);
            lowerLayer.GetColor(new Point(0, 0)).Should().Be(0);
            lowerLayer.GetColor(new Point(0, 1)).Should().Be(0);
            lowerLayer.GetColor(new Point(1, 1)).Should().Be(0);
        }
        [TestMethod]
        public void CopyFrom_When_LowerLayer_Is_Bigger_Then_UpperLayer_Should_Not_Throw()
        {
            TetrisCup upperLayer = new TetrisCup(1, 1, new[] { new Point(0, 0) });
            TetrisCup lowerLayer = new TetrisCup(2, 2, new Point[] { });
            lowerLayer.CopyFrom(upperLayer, new Offset(0, 0));
        }
        [TestMethod]
        public void CopyFrom_When_Cell_In_UpperLayer_Is_Empty_Should_Not_Reset_LowerLayer_Cell()
        {
            TetrisCup upperLayer = new TetrisCup(2, 2, new[] { new Point(1, 0) });
            TetrisCup lowerLayer = new TetrisCup(2, 2, new Point[] { new Point(1, 1) });
            lowerLayer.CopyFrom(upperLayer, new Offset(0, 0));
            lowerLayer.GetColor(new Point(1, 0)).Should().Be(-1);
            lowerLayer.GetColor(new Point(0, 0)).Should().Be(0);
            lowerLayer.GetColor(new Point(0, 1)).Should().Be(0);
            lowerLayer.GetColor(new Point(1, 1)).Should().Be(-1);
        }
        [TestMethod]
        public void CopyFrom_Should_Copy_With_Offset()
        {
            TetrisCup upperLayer = new TetrisCup(3, 2, new[] { new Point(1, 0) });
            TetrisCup lowerLayer = new TetrisCup(3, 2, new Point[] {});
            lowerLayer.CopyFrom(upperLayer, new Offset(1, 1));
            lowerLayer.GetColor(new Point(0, 0)).Should().Be(0);
            lowerLayer.GetColor(new Point(0, 1)).Should().Be(0);
            lowerLayer.GetColor(new Point(1, 0)).Should().Be(0); 
            lowerLayer.GetColor(new Point(1, 1)).Should().Be(0);
            lowerLayer.GetColor(new Point(2, 0)).Should().Be(0);
            lowerLayer.GetColor(new Point(2, 1)).Should().Be(-1);
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

    }
}
