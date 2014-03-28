using FakeItEasy;
using FluentAssertions.Numeric;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace UnitTestProject1.Tetris
{
    [TestClass]
    public class TestFigure
    {
        [TestMethod]
        public void CurrentRotation_Should_Return_Element_From_Pattern_By_RotationNumber()
        {
            var expected = new TetrisCup(1, 1, new Point[]{});
            var figure = new Figure
            {
                Pattern = new Pattern()
                {
                    Rotations = new TetrisCup[] { null, expected}
                },
                RotationNumber = 1,
            };
            figure.CurrentRotation.Should().Be(expected);
        }

        [TestMethod]
        public void NextRotation_Should_Increment_RotationNumber()
        {
            var figure = new Figure();
            figure.NextRotation();
            figure.RotationNumber.Should().Be(1);
        }
        [TestMethod]
        public void NextRotation_When_RotationNumber_Is_3_Should_Reset_To_0()
        {
            var figure = new Figure();
            figure.RotationNumber = 3;
            figure.NextRotation();
            figure.RotationNumber.Should().Be(0);
        }
        [TestMethod]
        public void ColorFigure_Should_Set_Color()
        {
            var figure = new Figure();
            figure.ColorFigure();
            figure.Color.Should().BeInRange(1,16);
        }
    }
}
