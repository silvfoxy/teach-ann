using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AskExpert_When_Mama_Is_Fat_Should_Return_No()
        {
            string result = AskExpert(new Answers("yes"));
            MyAssert.AreEqual("no", result);
        }
        public class MyAssert
        {
            public static void AreEqual(string expected, string actual)
            {
                if (expected != actual)
                    throw new Exception();
            }
            public static void IsFalse(bool actual)
            {
                if (actual)
                    throw new Exception();
            }
        }

        [TestMethod]
        public void AskExpert_When_Mama_IsNot_Fat_Should_Return_True()
        {
            string result = AskExpert(new Answers("no"));
            Assert.AreEqual("yes", result);
        }
        string AskExpert(Answers answers)
        {
            //if (answers.IsYourMamaFat == "yes") //rewrite this method without words true, false, else, if
            //    return "no";
            //else
            //    return "yes";
            string ExpertsAnswer = answers.IsYourMamaFat == "yes" ? "no" : "yes";
            return ExpertsAnswer;
        }
        public bool Fuck_Off_All_This_Shit()
        {
            bool DoYouThinkThatLifeIsPain;
            DoYouThinkThatLifeIsPain = true;
            return DoYouThinkThatLifeIsPain;
        }
        [TestMethod]
        public void Static_Method_Should_Be_Called_With_Class_Name()
        {
            X.F();
        }
        [TestMethod]
        public void Instance_Method_Should_Be_Called_With_Variable_Name()
        {
            new Y().G();
            Y y = new Y();
            y.G();
        }
        [TestMethod]
        public void If_Class_Has_Only_Privat_Constructor_Should_Not_Be_Able_To_New_It()
        {
            //new X();
        }
        [TestMethod]
        public void I_Know_How_To_Call_Instance_Method()
        {
            AskExpert_When_Mama_IsNot_Fat_Should_Return_True();
        }
    }

    class X
    {
        public void E()
        {
        }
        public static void F()
        {
            X x = new X();
            x.E();
        }
        X()
        { }
    }
    class Y
    {
        public static void H()
        {
            X.F();
        }
        public void G()
        { }
    }
    class Answers
    {
        public string IsYourMamaFat;
        bool DoYouRespectMe;
        int HowLongItIs;
        public Answers(string isYourMamaFat)
        {
            this.IsYourMamaFat = isYourMamaFat;
        }
    }
}
