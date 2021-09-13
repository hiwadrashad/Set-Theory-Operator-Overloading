using Set_Theory_Operator_Overloading_LIB.Methods;
using Set_Theory_Operator_Overloading_LIB.Singletons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set_Theory_Operator_Overloading_LIB.Sets
{
    public class List<T> : Set<T>, IDisposable, Interfaces.IList<T>
    {
        public new T[] Value;
        public new T[][] CartesianValue;

        public List(T[] Input, bool DoSet = true) : base(Input,DoSet)
        {
            Value = Input;
        }


        public new T[] GetValues()
        {
            return Value;
        }

        public new T[][] GetCartesian()
        {
            return CartesianValue;
        }
        public static bool operator <(List<T> MainSet, List<T> Subset)
        {
            Set<T> SetInstance = new Set<T>(new T[0]);

            bool NOTFOUND = false;
            foreach (var Value in Subset.Value)
            {
                if (!SetInstance.Contains<int>((dynamic)MainSet.Value, (dynamic)Value))
                {
                    NOTFOUND = true;
                }
                if (NOTFOUND == true)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator >(List<T> SuperSet, List<T> Subset)
        {
            Set<T> SetInstance = new Set<T>(new T[0]);

            bool NOTFOUND = false;
            foreach (var Value in Subset.Value)
            {
                if (!SetInstance.Contains<int>((dynamic)SuperSet.Value, (dynamic)Value))
                {
                    NOTFOUND = true;
                }
                if (NOTFOUND == true)
                {
                    return false;
                }
            }
            return true;
        }


        public static bool operator ==(List<T> a, List<T> b)
        {

            if (a == null || b == null)
            {
                return false;
            }

            if (a.Value.Length == b.Value.Length)
            {
                foreach (var index in (dynamic)a.Value)
                {
                    var BList = (dynamic)b.Value;
                    if (index == BList[index - 1])
                    {
                        return true;
                    }

                }
                return false;

            }
            else
            {
                return false;
            }

        }

        public static bool operator !=(List<T> a, List<T> b)
        {


            if (a.Value.Length == b.Value.Length)
            {
                foreach (var index in (dynamic)a.Value)
                {
                    var BList = (dynamic)b.Value;
                    if (index == BList[index - 1])
                    {
                        return false;
                    }

                }
                return true;

            }
            else
            {
                return true;
            }

        }

        public new List<A> Intersection<A>(ref A[] ArrayA, ref A[] ArrayB)
        {
            List<T> SetList = new List<T>(new T[0]);

            A[] Array = new A[0];
            foreach (var Value in ArrayB)
            {
                if (Submethods<A[]>.Contains<A>(ArrayA, Value))
                {
                    SetList.Add<A>(ref Array, Value);
                }
            }
            return new List<A>(Array);
        }

        public new List<A> Add<A>(ref A[] ArrayA, A Value, int sizeincrease = 1)
        {
            A[] ReturnArray = new A[ArrayA.Length + sizeincrease];
            int index = 0;
            foreach (var AValue in ArrayA)
            {
                ReturnArray[index] = AValue;
                index = index + 1;
            }
            ReturnArray[ArrayA.Length + sizeincrease - 1] = Value;

            ArrayA = ReturnArray;

            var Return = new List<A>(ReturnArray);

            return Return;
        }


        public new List<T> Complement<A>(ref A[] ArrayA, ref A[] ArrayB)
        {
            Set<T> SetInstance = new Set<T>(new T[0]);
            List<T> SetList = new List<T>(new T[0]);

            foreach (var Value in ArrayB)
            {
                if (SetInstance.Contains<A>(ArrayA, Value))
                {
                    SetList.Remove<A>(ref ArrayA, Value);
                }
            }
            return new List<T>((dynamic)ArrayA);
        }




        public new List<T> PowerSet(ref T[] InputSet)
        {
            T[] TempArray = new T[0];
            double count = Math.Pow(2, InputSet.Length);
            for (int i = 1; i <= count - 1; i++)
            {
                string str = Convert.ToString(i, 2).PadLeft(InputSet.Length, '0');
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == '1')
                    {
                        Add<T>(ref TempArray, InputSet[j]);
                    }
                }
                if (typeof(T).IsNumericType())
                {
                    Add<T>(ref TempArray, (dynamic)(-1));
                }
                else if (typeof(T).IsLanguageType())
                {
                    Add<T>(ref TempArray, (dynamic)(" "));
                }

            }
            InputSet = TempArray;
            return new List<T>(TempArray);
        }

        public new List<T> CartesianProduct(T[] arr1, T[] arr2)
        {
            T[][] combos = new T[arr1.Length * arr2.Length][];

            int ii = 0;
            foreach (var Value in arr1)
            {
                foreach (var Value2 in arr2)
                {
                    T[] combo = new T[2];

                    combo[0] = Value;
                    combo[1] = Value2;
                    combos[ii] = combo;

                    ii++;
                }
            }

            return new List<T>(new T[0]) { CartesianValue = combos };
        }


        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }


        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public new System.Collections.IEnumerator GetEnumerator()
        {
            return Value.GetEnumerator();
        }


        ~List()
        {
            this.Dispose(false);
        }

        public new  void Dispose()
        {
            this.Dispose(true);
        }

        private new void Dispose(bool disposing)
        {
            if (disposing)
                GC.SuppressFinalize(this);

            this.Dispose();
        }


        public bool IsReadOnly
        {
            get { return false; }
        }
    }
    public class ListEnumerator<T> : System.Collections.IEnumerator
    {
        private readonly IEnumerator<T> _inner;

        public ListEnumerator(IEnumerable<T> inner)
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

        object  System.Collections.IEnumerator.Current
        {
            get { return _inner.Current; }
        }

    }
}
