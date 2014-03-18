using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class TestCalculator
    {
        [TestMethod]
        public void Press1_Should_Set_DisplayValue_To_1()
        {
            var calc = new Calculator();
            calc.Press1();
            Assert.AreEqual(1, calc.DisplayValue);
        }
        [TestMethod]
        public void Press2_Should_Set_DisplayValue_To_2()
        {
            var calc = new Calculator();
            calc.Press2();
            Assert.AreEqual(2, calc.DisplayValue);
        }
        [TestMethod]
        public void PressPlus_Should_Change_Current_Operation_To_Plus()
        {
            var calc = new Calculator();
            calc.PressPlus();
            Assert.AreEqual("+", calc.CurrentOperation);
        }
        [TestMethod]
        public void PressMinus_Should_Change_Current_Operation_To_Minus()
        {
            var calc = new Calculator();
            calc.PressMinus();
            Assert.AreEqual("-", calc.CurrentOperation);
        }
        [TestMethod]
        public void PressEqual_Should_Reset_CurrentOperation()
        {
            var calc = new Calculator();
            calc.PressEqual();
            Assert.AreEqual(null, calc.CurrentOperation);
        }
        [TestMethod]
        public void Press1_Then_PressPlus_Should_Set_PreviousValue_To_1()
        {
            var calc = new Calculator();
            calc.Press1();
            calc.PressPlus();
            Assert.AreEqual(1, calc.PreviousValue);
        }
        [TestMethod]
        public void _1_Plus_2_Equals_Should_Set_DisplayValue_To_3()
        {
            var calc = new Calculator();
            calc.Press1();
            calc.PressPlus();
            calc.Press2();
            calc.PressEqual();
            Assert.AreEqual(3, calc.DisplayValue);
        }
        [TestMethod]
        public void Equal_Should_Set_DisplayValue_To_0()
        {
            var calc = new Calculator();
            calc.PressEqual();
            Assert.AreEqual(0, calc.DisplayValue);
        }
        [TestMethod] //hw
        public void PressC_Should_Set_DisplayValue_To_0()
        {
            var calc = new Calculator();
            calc.PressC();
            Assert.AreEqual(0, calc.DisplayValue);
        }
        [TestMethod] //hw
        public void PressC_Should_Reset_CurrentOperation()
        {
            var calc = new Calculator();
            calc.PressC();
            Assert.IsNull(calc.CurrentOperation);
        }
        [TestMethod] //hw
        public void PressC_Should_Set_PreviousValue_To_0()
        {
            var calc = new Calculator();
            calc.PressC();
            Assert.AreEqual(0, calc.PreviousValue);
        }
        [TestMethod] //hw
        public void PressCE_Should_Set_DisplayValue_To_0()
        {
            var calc = new Calculator();
            calc.PressCE();
            Assert.AreEqual(0, calc.DisplayValue);
        }
        [TestMethod] //hw
        public void PressBackspace_Should_Remove_Last_Number()
        {
            var calc = new Calculator();
            calc.Press1();
            calc.Press9();
            calc.PressBackspace();
            Assert.AreEqual(1, calc.DisplayValue);
        }
        public void PressBackspace_Should_Set_DisplayValue_To_0_If_DisplayValue_Less_Then_10()
        {
            var calc = new Calculator();
            calc.Press1();
            calc.PressBackspace();
            Assert.AreEqual(0, calc.DisplayValue);
        }
        public void Press1_Should_Set_Display_Value_To_DisplayValue_Multiply_10_Plus_1()
        {
            var calc = new Calculator();
            calc.Press9();
            calc.Press1();
            Assert.AreEqual(91, calc.DisplayValue);
        }
        public void Press1_Should_Reset_Display_Value_To_1_If_It_Is_Result_Of_Previous_Operations()
        {
            var calc = new Calculator();
            calc.Press9();
            calc.PressPlus();
            calc.Press2();
            calc.PressEqual();
            calc.Press1();
            Assert.AreEqual(1, calc.DisplayValue);
        }
    }
}
