using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public class MySelectManyEnumerable : IEnumerable<char>
    {
        public Func<string, IEnumerable<char>> Selector;
        public IEnumerable<string> Source;
        public MySelectManyEnumerable(IEnumerable<string> source, Func<string, IEnumerable<char>> selector)
        {
            Selector = selector;
            Source = source;
        }

        public IEnumerator<char> GetEnumerator()
        {
            return new MySelectManyEnumerator(Source, Selector);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class MySelectManyEnumerator : IEnumerator<char>
    {
        public Func<string, IEnumerable<char>> Selector;
        public IEnumerator<string> SequenceOfSequences;
        public IEnumerator<char> CurrentSequence;
        public MySelectManyEnumerator(IEnumerable<string> source, Func<string, IEnumerable<char>> selector)
        {
            Selector = selector;
            SequenceOfSequences = source.GetEnumerator();

        }
        public char Current
        {
            get { return CurrentSequence.Current; }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        object System.Collections.IEnumerator.Current
        {
            get { throw new NotImplementedException(); }
        }

        public bool MoveNext()
        {
            if (CurrentSequence == null || !CurrentSequence.MoveNext())
                if (SequenceOfSequences.MoveNext())
                    CurrentSequence = Selector(SequenceOfSequences.Current).GetEnumerator();
                else return false;
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
