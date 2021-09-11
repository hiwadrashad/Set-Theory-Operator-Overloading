﻿using Set_Theory_Operator_Overloading_LIB.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set_Theory_Operator_Overloading_LIB.Sets
{
    public class List<T> : IDisposable
    {
        public T[] Value;
        public T[][] CartesianValue;

        public List(T[] Input)
        {
            Value = Input;
        }

        public T this[int index]
        {
            get => (T)Value[index];
            set => Submethods<T[]>.IncreaseArray<T>(ref Value, value);
        }

        public static bool operator <(List<T> MainSet, List<T> Subset)
        {
            bool NOTFOUND = false;
            foreach (var Value in Subset.Value)
            {
                if (!Set<int>.Contains<int>((dynamic)MainSet.Value, (dynamic)Value))
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
            bool NOTFOUND = false;
            foreach (var Value in Subset.Value)
            {
                if (!Set<int>.Contains<int>((dynamic)SuperSet.Value, (dynamic)Value))
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

        public static Set<A> Intersection<A>(ref A[] ArrayA, ref A[] ArrayB)
        {
            A[] Array = new A[0];
            foreach (var Value in ArrayB)
            {
                if (Submethods<A[]>.Contains<A>(ArrayA, Value))
                {
                    Set<A>.Add<A>(ref Array, Value);
                }
            }
            return new Set<A>(Array);
        }

        public static Set<A> Add<A>(ref A[] ArrayA, A Value, int sizeincrease = 1)
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

            var Return = new Set<A>(ReturnArray);

            return Return;
        }

        public static A[] AddWithoutReference<A>(A[] ArrayA, A Value, int sizeincrease = 1)
        {
            A[] ReturnArray = new A[ArrayA.Length + sizeincrease];
            int index = 0;
            foreach (var AValue in ArrayA)
            {
                ReturnArray[index] = AValue;
                index = index + 1;
            }
            ReturnArray[ArrayA.Length + sizeincrease - 1] = Value;

            return ReturnArray;
        }

        public static Set<T> Complement<A>(ref A[] ArrayA, ref A[] ArrayB)
        {
            foreach (var Value in ArrayB)
            {
                if (Set<A>.Contains<A>(ArrayA, Value))
                {
                    Remove<A>(ref ArrayA, Value);
                }
            }
            return new Set<T>((dynamic)ArrayA);
        }

        public static A[] Remove<A>(ref A[] ArrayA, A Value, int sizedecrease = 1)
        {
            if (Submethods<A>.Contains<A>(ArrayA, Value))
            {
                for (int i = Submethods<A[]>.GetLength(ArrayA) - 1; i > -1; i--)
                {
                    if ((dynamic)Value == ArrayA[i])
                    {
                        Submethods<A>.Remove<A>(ref ArrayA, i);
                    }
                }
                return ArrayA;
            }
            else
            {
                return ArrayA;
            }
        }



        public static Set<T> PowerSet(ref T[] InputSet)
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
            return new Set<T>(TempArray);
        }

        public static Set<T> CartesianProduct(T[] arr1, T[] arr2)
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

            return new Set<T>(new T[0]) { CartesianValue = combos };
        }

        public static int Count<A>(A[] Input)
        {

            return Submethods<A[]>.GetLength(Input);
        }

        public static T[] Clear(ref T[] input)
        {
            input = new T[0];
            return input;
        }
        public static bool Contains<A>(A[] input, A Value)
        {
            return Submethods<A[]>.Contains<A>(input, Value);
        }

        public static T[] ToArray<A>(Set<T> input)
        {
            return input.Value;
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

        public System.Collections.IEnumerator GetEnumerator()
        {
            return Value.GetEnumerator();
        }


        ~List()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        private void Dispose(bool disposing)
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