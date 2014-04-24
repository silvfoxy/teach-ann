using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class TestMyCollection
    {
        [TestMethod]
        public void _Test()
        {
            var actualResult = new List<int>();
            var rnd = new Random();
            var elements = Enumerable.Range(0, 100).Select(x => rnd.Next()).ToArray();

            var underTest = new MyCollection(elements);

            foreach (var x in underTest)
                actualResult.Add(x);

            /*var en = underTest.GetEnumerator();
            while (en.MoveNext())
                actualResult.Add(en.Current);*/

            /*while (underTest.MoveNext())
            {
                actualResult.Add(underTest.Current);
            }*/

            actualResult.Should().Equal(elements);
        }
        [TestMethod]
        public void Where_Should_Filter_Elements()
        {
            var elements = Enumerable.Range(0, 10);
            Where(elements, x => x % 2 == 0).Should().Equal(0, 2, 4, 6, 8);
            Where(elements, x => x > 7).Should().Equal(8, 9);
            Where(elements, x => IsPrime(x)).Should().Equal(0, 1, 2, 3, 5, 7);
            Where(elements, IsPrime).Should().Equal(0, 1, 2, 3, 5, 7);
        }
        [TestMethod]
        public void MyLast_Should_Return_The_Last_Element()
        {
            var elements = Enumerable.Range(0, 10);
            //elements.Last().Should().Be(9);
            MyLast(elements).Should().Be(9);
        }
        private int MyLast(IEnumerable<int> source)
        {
            var sourceEnumerator = source.GetEnumerator();
            int last = sourceEnumerator.Current;
            do { last = sourceEnumerator.Current; }
            while (sourceEnumerator.MoveNext());
            return last;
        }
        [TestMethod]
        public void MyElementAt_Should_Return_Element_From_The_Given_Index()
        {
            var elements = Enumerable.Range(0, 10);
            elements.ElementAt(0).Should().Be(0);
            MyElementAt(elements, 1).Should().Be(1);
        }
        private int MyElementAt(IEnumerable<int> source, int index)
        {
            var sourceEnumerator = source.GetEnumerator();
            int elementAtIndex = sourceEnumerator.Current;
            for (int i = 0; i <= index; i++)
            {
                sourceEnumerator.MoveNext();
                elementAtIndex = sourceEnumerator.Current;
            }
            return elementAtIndex;
        }
        [TestMethod]
        public void MyFirst_Should_Return_The_First_Element()
        {
            var elements = Enumerable.Range(0, 10);
            //elements.First().Should().Be(0);
            MyFirst(elements).Should().Be(0);
        }
        private int MyFirst(IEnumerable<int> source)
        {
            var sourceEnumerator = source.GetEnumerator();
            sourceEnumerator.MoveNext();
            return sourceEnumerator.Current;
        }
        private IEnumerable<int> Where(IEnumerable<int> source, Func<int, bool> predicate)
        {
            return new WhereEnumerable(source, predicate);
        }
        private bool IsPrime(int num)
        {
            /*for (int i = 2; i <= num/2; i++)
            {
                if (num % i == 0) return false;
            }
            return true;*/
            return num<=3 || Enumerable.Range(2, num/2+1).All(x => num % x != 0);
        }
        [TestMethod]
        public void All_When_All_Elements_True_Should_Return_True()
        {
            var elements = Enumerable.Range(5, 1000);
            All(elements.Where(IsPrime), x=>(x-1)%6==0 || (x+1)%6==0).Should().BeTrue();            
        }
        public bool All(IEnumerable<int> source, Func<int, bool> predicate)
        {
            foreach(var x in source)
            {
                if (!predicate(x))
                    return false;
            }
            return true;
        }
        [TestMethod]
        public void EnumRange_1_5_Should_Be_1_2_3_4_5()
        {
            EnumRange(1, 5).Should().Equal(1, 2, 3, 4, 5);
        }
        private IEnumerable<int> EnumRange(int start, int count)
        {
            return new EnumRangeEnumerable(start, count);
        }

        [TestMethod]
        public void Select_Should_Transform_Each_Element_In_The_Sequence()
        {
            var elements = Enumerable.Range(1, 3);
            Select(elements, x => x * 2).Should().Equal(2, 4, 6);
            Select(elements, x => x.ToString()).Should().Equal(new[] { "1", "2", "3" });
        }
        private IEnumerable<T> Select<T>(IEnumerable<int> source, Func<int, T> selector)
        {
            return new SelectEnumerable<T>(source, selector);
        }
    }
}
