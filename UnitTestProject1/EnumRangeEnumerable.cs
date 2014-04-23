using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestProject1
{
    public class EnumRangeEnumerable : IEnumerable<int>
    {
        public int Start;
        public int Count;
        public EnumRangeEnumerable(int start, int count)
        {
            Start = start;
            Count = count;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new EnumRangeEnumerator(Start, Count);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class EnumRangeEnumerator : IEnumerator<int>
    {
        public int Start;
        public int Count;
        public int Current { get; set; }
        public EnumRangeEnumerator(int Start, int Count)
        {
            this.Start = Start;
            this.Count = Count;
            this.Current = Start-1;
        }
        public void Dispose()
        {
        }

        object System.Collections.IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            Current++;
            return (Current < Start+Count);
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
