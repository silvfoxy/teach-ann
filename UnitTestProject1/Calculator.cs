using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestProject1
{
    public class Calculator
    {
        public int DisplayValue;
        public string CurrentOperation;
        public int PreviousValue;
        Boolean IsItResult;//т.е когда на дисплей выводится результат вычислений, то, если набирать новое число, оно набирается "поверх" старого результата вычислений.

        public void Press1()
        {
            if (IsItResult)
            {
                DisplayValue = 1;
                IsItResult = false;
            }
            else DisplayValue = DisplayValue * 10 + 1;
        }
        public void Press2()
        {
            if (IsItResult)
            {
                DisplayValue = 2;
                IsItResult = false;
            }
            else DisplayValue = DisplayValue * 10 + 2;
        }
        public void Press3()
        {
            if (IsItResult)
            {
                DisplayValue = 3;
                IsItResult = false;
            }
            else DisplayValue = DisplayValue * 10 + 3;
        }
        public void Press4()
        {
            if (IsItResult)
            {
                DisplayValue = 4;
                IsItResult = false;
            }
            else DisplayValue = DisplayValue * 10 + 4;
        }
        public void Press5()
        {
            if (IsItResult)
            {
                DisplayValue = 5;
                IsItResult = false;
            }
            else DisplayValue = DisplayValue * 10 + 5;
        }
        public void Press6()
        {
            if (IsItResult)
            {
                DisplayValue = 6;
                IsItResult = false;
            }
            else DisplayValue = DisplayValue * 10 + 6;
        }
        public void Press7()
        {
            if (IsItResult)
            {
                DisplayValue = 7;
                IsItResult = false;
            }
            else DisplayValue = DisplayValue * 10 + 7;
        }
        public void Press8()
        {
            if (IsItResult)
            {
                DisplayValue = 8;
                IsItResult = false;
            }
            else DisplayValue = DisplayValue * 10 + 8;
        }
        public void Press9()
        {
            if (IsItResult)
            {
                DisplayValue = 9;
                IsItResult = false;
            }
            else DisplayValue = DisplayValue * 10 + 9;
        }
        public void Press0()
        {
            if (IsItResult)
            {
                DisplayValue = 0;
                IsItResult = false;
            }
            else DisplayValue = DisplayValue * 10;
        }
        public void PressPlus()
        {
            PreviousValue = DisplayValue;
            CurrentOperation = "+";
            IsItResult = true;
        }
        public void PressMinus()
        {
            PreviousValue = DisplayValue;
            CurrentOperation = "-";
            IsItResult = true;
        }
        public void PressMultiply()
        {
            PreviousValue = DisplayValue;
            CurrentOperation = "*";
            IsItResult = true;
        }
        public void PressDivision()
        {
            PreviousValue = DisplayValue;
            CurrentOperation = "/";
            IsItResult = true;
        }
        public void PressEqual()
        {
            if (CurrentOperation == "*")
                DisplayValue = PreviousValue * DisplayValue;
            if (CurrentOperation == "/")
                DisplayValue = PreviousValue / DisplayValue;
            if (CurrentOperation == "+")
                DisplayValue = PreviousValue + DisplayValue;
            if (CurrentOperation == "-")
                DisplayValue = PreviousValue - DisplayValue;
            CurrentOperation = null;
            PreviousValue = 0;
            IsItResult = true;
        }
        public void PressC()
        {
            DisplayValue = 0;
            CurrentOperation = null;
            PreviousValue = 0;
        }
        public void PressCE()
        {
            DisplayValue = 0;
        }
        public void PressBackspace()
        {
            DisplayValue = DisplayValue / 10;
        }
    }
}
