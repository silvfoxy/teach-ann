using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestProject1
{
    public class SelectEnumerable<T>: IEnumerable<T>
    {
        private IEnumerable<int> _source;
        private Func<int, T> _selector;

        public SelectEnumerable(IEnumerable<int> source, Func<int, T> selector)
        {
            this._source = source;
            this._selector = selector;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new SelectEnumerator<T>(_source, _selector);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class SelectEnumerator<T> : IEnumerator<T>
    {
        private Func<int, T> _selector;
        private IEnumerator<int> _sourceEnumerator;

        public SelectEnumerator(IEnumerable<int> _source, Func<int, T> _selector)
        {
            this._selector = _selector;
            _sourceEnumerator = _source.GetEnumerator();
        }
        public T Current
        {
            get { return _selector(_sourceEnumerator.Current); }
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
            return _sourceEnumerator.MoveNext();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
