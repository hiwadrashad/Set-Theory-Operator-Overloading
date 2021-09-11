using Set_Theory_Operator_Overloading_LIB.Methods;
using System;
using System.Collections;

namespace Set_Theory_Operator_Overloading_LIB.Sets
{
    public class Set<T> : IEnumerable 
    {
        public Set(T[] input)
        {
            Value = input;
        }

        public Set()
        {

        }

        public T[] Value;

        public T this[int index]
        {
            get => (T)Value[index];
            set => Submethods<T[]>.IncreaseArray<T>(ref Value, value);
        }


        public static bool operator == (Set<T> a , Set<T> b)
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

        public static bool operator !=(Set<T> a, Set<T> b)
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

        public static Set<A> Add<A>(ref A[] ArrayA,A Value, int sizeincrease = 1)
        {
            A[] ReturnArray = new A[ArrayA.Length + sizeincrease];
            int index = 0;
            foreach (var AValue in ArrayA)
            {
                ReturnArray[index] = AValue;
                index = index + 1;
            }
            ReturnArray[ArrayA.Length + sizeincrease - 1] = Value;

            var Return = new Set<A>(ReturnArray);

            return Return;
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

        public static int Count<A>(A[] Input)
        {

            return Submethods<A[]>.GetLength(Input);
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

        public IEnumerator GetEnumerator()
        {
            return Value.GetEnumerator();
        }
    }
}
