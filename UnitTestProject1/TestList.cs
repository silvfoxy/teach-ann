using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class TestList
    {
        [TestMethod]
        public void Add_Should_Add_Elements_To_List()
        {
            int n = 10;
            List<int> listOfNumbers = new List<int>();
            listOfNumbers.Add(5);
            List<string> listOfStrings = new List<string>();
            CollectionAssert.AreEqual(new string[0], listOfStrings);
            // listOfStrings.Add(4); wrong!
            listOfStrings.Add("hello!");
            CollectionAssert.AreEqual(new[] { "hello!" }, listOfStrings);
            listOfStrings.Add("hello!");
            CollectionAssert.AreEqual(new[] { "hello!", "hello!" }, listOfStrings);
        }
        [TestMethod]
        public void Remove_Should_Find_The_First_Matching_Element_And_Remove_It()
        {
            List<int> listOfNumbers = new List<int> { 5, 6, 7 };
            listOfNumbers.Remove(5);
            CollectionAssert.AreEqual(new[] { 6, 7 }, listOfNumbers);
        }
        [TestMethod]
        public void RemoveAt_Should_Find_The_Element_With_Given_Index_And_Remove_It()
        {
            List<int> listOfNumbers = new List<int> { 5, 6, 7 };
            listOfNumbers.RemoveAt(1);
            CollectionAssert.AreEqual(new[] { 5, 7 }, listOfNumbers);
        }
        [TestMethod]
        public void IndexOf_Should_Return_Index_Of_Given_Element()
        {
            List<int> listOfNumbers = new List<int> { 5, 6, 7 };
            int index = 2;
            Assert.AreEqual(2, index);
        }
        [TestMethod]
        public void Contains_Should_Return_True_If_There_Is_Such_Element()
        {
            List<int> listOfNumbers = new List<int> { 5, 6, 7 };
            Assert.IsTrue(listOfNumbers.Contains(5));
        }     // список списков чисел, Insert(i, ??);  
        [TestMethod]
        public void Contains_Should_Return_False_If_There_Is_No_Such_Element()
        {
            List<int> listOfNumbers = new List<int> { 5, 6, 7 };
            Assert.IsFalse(listOfNumbers.Contains(8));
        }
        [TestMethod]
        public void AddRange_Should_Add_In_ListOfStrings_Such_Elements()
        {
            List<string> listOfStrings = new List<string>();
            listOfStrings.AddRange(new[] { "a", "b", "c" });
            CollectionAssert.AreEqual(new[] { "a", "b", "c" }, listOfStrings);
        }
        [TestMethod]
        public void Insert_Should_Insert_Given_Element_At_Given_Index()
        {
            List<List<int>> listOfLists = new List<List<int>> { new List<int> { 0 } };
            listOfLists.Insert(0, new List<int> { });
            List<int>[] x = new[] { new List<int> { }, new List<int> { 0 } };
            // CollectionAssert.AreEqual(new []{new List<int>{}, new List<int>{0}}, listOfLists);
        }
        /* Arrays syntax:
             new string[4];
             new string[] { "a" };
             new string[1] { "b" };
             // new string[1] { "v", "u"}; WTF?
             new [] { "a" }
             new string[0] {};
             new [0] {};
          */
        [TestMethod]
        public void Min_Should_Return_Min_Element()
        {
            List<int> listOfNumbers = new List<int> { 5, 6, 7 };
            Assert.AreEqual(5, listOfNumbers.Min());
        }
        [TestMethod]//HW
        public void Trim_Should_Delete_Gaps_From_Start_And_From_Finish()
        {
            String word = "    word  ";
            Assert.AreEqual("word", word.Trim());
        }
        [TestMethod]//HW
        public void ToCharArray_Should_Copy_String_To_Char_Array()
        {
            String word = "word";
            CollectionAssert.AreEqual(new char[] { 'w', 'o', 'r', 'd' }, word.ToCharArray(0, 4));
        }
        [TestMethod]//HW
        public void Reverse_Should_Inverse_Order()
        {
            List<int> listOfNumbers = new List<int> { 5, 6, 7 };
            listOfNumbers.Reverse(0,2);
            CollectionAssert.AreEqual(new[] { 6, 5, 7 }, listOfNumbers);
        }
    }
}