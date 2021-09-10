using Set_Theory_Operator_Overloading_LIB.Methods;
using System;
using System.Collections;

namespace Set_Theory_Operator_Overloading_LIB.Sets
{
    public class Set<T> : IEnumerable
    {
        public Set(T input)
        {
            Value = input;
        }

        public T Value;

        public static bool operator == (Set<T> a , Set<T> b)
        {
            if (typeof(T).IsArray)
            {

                if (Submethods<T>.GetLength(a.Value) == Submethods<T>.GetLength(b.Value))
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
            else
            {
                throw new ArgumentException("Wrong input type");
            }
        }

        public static bool operator !=(Set<T> a, Set<T> b)
        {
            if (typeof(T).IsArray)
            {

                if (Submethods<T>.GetLength(a.Value) == Submethods<T>.GetLength(b.Value))
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
            else
            {
                throw new ArgumentException("Wrong input type");
            }
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
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
