using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    class TestBalanceCalculator
    {
    }
    public class Account
    {
        public string Name;
        public Account Parent;
    }
    public class Transaction
    {
        public Account Credit;
        public Account Debit;
        public decimal Amount;
        public DateTime Timestamp;
    }
    class Exercise
    {
        void Main()
        {
            int i = 17;
            while (i != 1)
            {
                Console.Write("{0}", i);
                i = 3 * i + 1;
                while (i % 2 == 0) i /= 2;
            }
        }
    }
}
