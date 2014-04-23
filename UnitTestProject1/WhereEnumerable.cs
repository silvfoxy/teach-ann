using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestProject1
{
    public class WhereEnumerable : IEnumerable<int>
    {
        IEnumerable<int> Source;
        public Func<int, bool> Predicate;
        public WhereEnumerable(IEnumerable<int> source, Func<int, bool> predicate)
        {
            Source = source;
            Predicate = predicate;
        }
        public IEnumerator<int> GetEnumerator()
        {
            return new WhereEnumerator(Source, Predicate);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class WhereEnumerator : IEnumerator<int>
    {
        public IEnumerator<int> SourceEnumerator;
        public Func<int, bool> Predicate;
        public int Current
        {
            get { return SourceEnumerator.Current; }
        }
        public WhereEnumerator(IEnumerable<int> source, Func<int, bool> predicate)
        {
            Predicate = predicate;
            SourceEnumerator = source.GetEnumerator();
        }
        public bool MoveNext()
        {
            do
            {
                if (!SourceEnumerator.MoveNext())
                    return false;
            }
            while (!Predicate(SourceEnumerator.Current));
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
}
