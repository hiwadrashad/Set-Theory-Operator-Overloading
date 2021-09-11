using Set_Theory_Operator_Overloading_LIB.Sets;
using System;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

namespace Set_Theory_Operator_Overloading_LIB.Methods
{
    public class Submethods<T>
    {
        public static bool ArrayDoesntRepeat<A>(T input)
        {
            if (typeof(T) == typeof(int[]) || typeof(T) == typeof(byte[]) || typeof(T) == typeof(sbyte[]) ||
            typeof(T) == typeof(short[]) || typeof(T) == typeof(ushort[]) || typeof(T) == typeof(uint[]) ||
            typeof(T) == typeof(long[]) || typeof(T) == typeof(ulong[]) || typeof(T) == typeof(string[])||
            typeof(T).IsAssignableFrom(typeof(IEnumerable)) || typeof(T).IsAssignableFrom(typeof(ICollection)))
            {
                var SetArray = input as A[];
                if (SetArray.Length == 0)
                {
                    return true;
                }
                foreach (var comparevalue in SetArray)
                {
                    int numbercount = 0;
                    foreach (var value in SetArray)
                    {
                        if ((dynamic)comparevalue == (dynamic)value)
                        {
                            numbercount = numbercount + 1;
                        }
                        if (numbercount == 2)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                throw new ArgumentException("Wrong input type");
            }
        }



        public static A[] RemoveRepeatingValue<A>(ref T input)
        {
            if (typeof(T) == typeof(int[]) || typeof(T) == typeof(byte[]) || typeof(T) == typeof(sbyte[]) ||
            typeof(T) == typeof(short[]) || typeof(T) == typeof(ushort[]) || typeof(T) == typeof(uint[]) ||
            typeof(T) == typeof(long[]) || typeof(T) == typeof(ulong[]) || typeof(T) == typeof(string[]) ||
            typeof(T).IsAssignableFrom(typeof(IEnumerable)) || typeof(T).IsAssignableFrom(typeof(ICollection)))
            {
                var SetArray = input as A[];
                if (SetArray.Length == 0)
                {
                    return input as A[];
                }
                foreach (var comparevalue in SetArray)
                {
                    int numbercount = 0;
                    int index = 0;
                    for (int i = Submethods<A[]>.GetLength(SetArray) - 1; i > -1; i--)
                    {
                        if ((dynamic)comparevalue == (dynamic)SetArray[i])
                        {
                            numbercount = numbercount + 1;
                            if (numbercount > 1)
                            {
                                Submethods<A[]>.Remove<A>(ref SetArray,i);
                            }
                        }
                        index = index + 1;
                    }
                }
                return input as A[];
            }
            else
            {
                throw new ArgumentException("Wrong input type");
            }
        }
        public static int GetLength(T input)
        {
            int length = 0;
            foreach (var index in (dynamic)input)
            {
                length = length + 1;
            }
            return length;
        }

        public static bool Contains<A>(A[] ArrayA, A Value)
        {
            foreach (var item in ArrayA)
            {
                if ((dynamic)item == (dynamic)Value)
                {
                    return true;
                }
            }
            return false;
        }

        public static A[] Remove<A>(ref A[] Array, int index)
        {
            A[] ReturnArray = new A[Array.Length - 1];
            for (int i = index; i <= Array.Length - 1; i++)
            {
                if (i == Array.Length - 1)
                {
                    int Index2 = 0;
                    foreach (var item in Array)
                    {
                        if (Index2 == Array.Length - 1)
                        {

                        }
                        else
                        {
                           ReturnArray[Index2] = Array[Index2];
                        }
                        Index2 = Index2 + 1;
                    }
                }
                else
                {
                    Array[i] = Array[i + 1];
                }
            }
            Array = ReturnArray;
            return Array;
        }

        public static A[] IncreaseArray<A>(ref A[] ArrayA, A Value, int sizeincrease = 1)
        {
            A[] ReturnArray = new A[ArrayA.Length + sizeincrease];
            int index = 0;
            foreach (var AValue in ArrayA)
            {
                ReturnArray[index] = AValue;
                index =  index + 1;
            }
            ReturnArray[ArrayA.Length + sizeincrease - 1] = Value;

            ArrayA = ReturnArray;
            return ArrayA;
        }

        public static Set<T> Union <A> (Set<T> a, Set<T> b)
        {
            if (typeof(T) != typeof(A))
            {
                var AList = a.Value as A[];
                var BList = b.Value as A[];
                int index = 0;
                if (BList.Length == 0)
                {
                    return new Set<T>((dynamic)AList);
                }
                foreach (var BValue in BList)
                {
                    var Returnvalue = IncreaseArray<A>(ref AList, BValue);
                    if (index == BList.Length - 1)
                    {
                        return new Set<T>((dynamic)Returnvalue);
                    }
                    index = index + 1;
                }
                return new Set<T>((dynamic)BList);
            }
            else
            {
                throw new ArgumentException("Wrong input type");
            }
        }
    }
}
