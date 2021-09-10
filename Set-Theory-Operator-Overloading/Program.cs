using Set_Theory_Operator_Overloading_LIB.Methods;
using Set_Theory_Operator_Overloading_LIB.Sets;
using System;

namespace Set_Theory_Operator_Overloading
{
    public class Program
    {
        static void Main(string[] args)
        {
            Set<int[]> a = new Set<int[]>( new int[] {1, 1});
            Set<int[]> b = new Set<int[]>(new int[] { 1 });
            var ConcatenatedSet = Submethods<int[]>.Concatenate<int>(a,b);
            bool doesntrepeat = Submethods<int[]>.ArrayDoesntRepeat<int>(a.Value);
            Console.WriteLine(doesntrepeat);
        }
    }
}
