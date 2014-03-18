using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class TestDictionary
    {  // Remove, словарь bool по int
        [TestMethod]
        public void Dictionary_Should_Associate_Keys_With_Values()
        {
            var dic = new Dictionary<string, int>();
            dic["blah"] = 5;
            Assert.AreEqual(5, dic["blah"]);
        }

        [TestMethod]
        public void Remove_Should_Remove_Pair_By_Given_Key()
        {
            var dic = new Dictionary<int, bool>();
            dic[2] = true;
            dic.Remove(2);
            Assert.AreEqual(false, dic.ContainsKey(2));
        }
        [TestMethod]
        public void Count_Should_Return_Number_Of_Pairs()
        {
            var dic = new Dictionary<int, bool>();
            dic[2] = true;
            Assert.AreEqual(1, dic.Count);
        }
        [TestMethod]
        public void Values_Should_Return_Collection_Of_Values()
        {
            var dic = new Dictionary<int, bool>();
            dic[2] = true;
            CollectionAssert.AreEqual(new[] {true}, dic.Values);
        }
        [TestMethod] //homework method №1
        public void Keys_Should_Return_Collection_Of_Keys()
        {
            var dic = new Dictionary<int, bool>();
            dic[2] = true;
            CollectionAssert.AreEqual(new[] {2}, dic.Keys);
        }
        [TestMethod] //homework method №2.1
        public void ContainsValue_Should_Return_True_If_There_Is_Given_Value()
        {
            var dic = new Dictionary<int, bool>();
            dic[2] = true;
            Assert.AreEqual(true, dic.ContainsValue(true));
        }
        [TestMethod] //homework method №2.2
        public void ContainsValue_Should_Return_False_If_There_Is_No_Given_Value()
        {
            var dic = new Dictionary<int, bool>();
            dic[2] = true;
            Assert.AreEqual(false, dic.ContainsValue(false));
        }
        [TestMethod] //homework method №3
        public void Add_Should_Add_Given_Element()
        {
            var dic = new Dictionary<int, bool>();
            dic[2] = true;
            dic.Add(666, false);
            Assert.AreEqual(false, dic[666]);
        }
        /*
         * задать илье вопросы: "Если словарь определен таким образом, 
         * что ключом является bool, а значением - int, то, получается, 
         * больше двух элементов в этом словаре быть не может?", 
         * "Что делает функция TryGetValue? судя по описанию, она делает 
         * то же, что и обычный вызов значения в словаре по ключу"
         */
    }
}