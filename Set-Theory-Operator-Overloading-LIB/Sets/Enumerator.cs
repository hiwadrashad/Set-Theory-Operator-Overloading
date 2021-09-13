using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set_Theory_Operator_Overloading_LIB.Sets
{
    public class Enumerator<T> : System.Collections.IEnumerator
    {
        private readonly IEnumerator<T> _inner;

        public Enumerator(IEnumerable<T> inner)
        {
            this._inner = inner.GetEnumerator();
        }

        public bool MoveNext()
        {
            return _inner.MoveNext();
        }

        public void Reset()
        {
            _inner.Reset();
        }

        public T Current
        {
            get { return _inner.Current; }
        }

        object System.Collections.IEnumerator.Current
        {
            get { return _inner.Current; }
        }

    }
}
