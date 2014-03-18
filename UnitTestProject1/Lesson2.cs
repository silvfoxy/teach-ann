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
    public class Lesson2
    {
        [TestMethod]
        public void Solve_Should_Find_Roots()
        {
            Roots roots = Solve(1, -2, -3);
            Assert.AreEqual(3, roots.X1);
            Assert.AreEqual(-1, roots.X2);
        }
        public Roots Solve(double a, double b, double c)
        {
            double d = b * b - (4 * a * c);
            Roots roots = new Roots();
            roots.X1 = (-b + Math.Sqrt(d)) / (2 * a);
            roots.X2 = (-b - Math.Sqrt(d)) / (2 * a);
            return roots;
        }
        [TestMethod]
        public void Solve_When_Determinant_Is_Negative_Should_Return_No_Roots()
        {
            Roots roots = Solve(5, 3, 7);
            Assert.AreEqual(double.NaN, roots.X1);
            Assert.AreEqual(double.NaN, roots.X2);
        }
        [TestMethod]
        public void Solve_When_Determinant_Is_Zero_Should_Return_Equal_Roots()
        {
            Roots roots = Solve(1, 12, 36);
            Assert.AreEqual(-6, roots.X1);
            Assert.AreEqual(-6, roots.X2);
        }
        public class Roots
        {
            public double X1;
            public double X2;
        }
    }
}
