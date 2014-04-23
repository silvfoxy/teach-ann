using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public class MyCollection
    {
        private IEnumerable<int> _elements;
        int position = -1;

        public MyCollection(int[] elements)
        {
            this._elements = elements;
        }
        //IEnumerator and IEnumerable require these methods.
        public IEnumerator<int> GetEnumerator()
        {
            return _elements.GetEnumerator();
        }
        /*//IEnumerator
        public bool MoveNext()
        {
            position++;
            return (position < _elements.Length);
        }
        //IEnumerable
        public void Reset()
        { position = 0; }
        //IEnumerable
        public int Current
        {
            get { return _elements[position]; }
        }*/
    }
}
