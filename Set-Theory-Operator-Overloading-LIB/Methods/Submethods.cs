using Set_Theory_Operator_Overloading_LIB.Sets;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Set_Theory_Operator_Overloading_LIB.Methods
{
    public class Submethods<T> where T :  class
    {
        public static bool ArrayDoesntRepeat<A>(T input)
        {
            if (typeof(T) == typeof(int[]) || typeof(T) == typeof(byte[]) || typeof(T) == typeof(sbyte[]) ||
            typeof(T) == typeof(short[]) || typeof(T) == typeof(ushort[]) || typeof(T) == typeof(uint[]) ||
            typeof(T) == typeof(long[]) || typeof(T) == typeof(ulong[]) || typeof(T) == typeof(string[]))
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

        public static A[] RemoveValue<A>(A[] input, A ValueToRemove)
        { 
           
        }

        public static A[] RemoveRepeatingValue<A>(T input)
        {
            if (typeof(T) == typeof(int[]) || typeof(T) == typeof(byte[]) || typeof(T) == typeof(sbyte[]) ||
            typeof(T) == typeof(short[]) || typeof(T) == typeof(ushort[]) || typeof(T) == typeof(uint[]) ||
            typeof(T) == typeof(long[]) || typeof(T) == typeof(ulong[]) || typeof(T) == typeof(string[]))
            {
                var SetArray = input as A[];
                if (SetArray.Length == 0)
                {
                    return SetArray;
                }
                foreach (var comparevalue in SetArray)
                {
                    int numbercount = 0;
                    int index = 0;
                    for (var i = SetArray.Length; i == 0; i--)
                    { 
                       if ((dynamic)comparevalue)
                    }
                    foreach (var value in SetArray)
                    {
                        if ((dynamic)comparevalue == (dynamic)value)
                        {
                            numbercount = numbercount + 1;
                        }
                        if (numbercount > 1)
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
        public static int GetLength(T input)
        {
            int length = 0;
            foreach (var index in (dynamic)input)
            {
                length = length + 1;
            }
            return length;
        }

        public static A[] IncreaseArray<A>( A[] ArrayA, A Value, int sizeincrease = 1)
        {
            A[] ReturnArray = new A[ArrayA.Length + sizeincrease];
            int index = 0;
            foreach (var AValue in ArrayA)
            {
                ReturnArray[index] = AValue;
                index =  index + 1;
            }
            ReturnArray[ArrayA.Length + sizeincrease - 1] = Value;

            return ReturnArray;
        }

        public static Set<T> Concatenate <A> (Set<T> a, Set<T> b)
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
                    var Returnvalue = IncreaseArray<A>(AList, BValue);
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
