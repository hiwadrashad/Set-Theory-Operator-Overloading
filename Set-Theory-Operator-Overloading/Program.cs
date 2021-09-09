using Set_Theory_Operator_Overloading_LIB.Methods;
using Set_Theory_Operator_Overloading_LIB.Sets;
using System;

namespace Set_Theory_Operator_Overloading
{
    public class Program
    {
        static void Main(string[] args)
        {
            Set<int[]> a = new Set<int[]>( new int[] {1});
            Set<int[]> b = new Set<int[]>(new int[] { 1 });
            var concatenated = Submethods<int[]>.Concatenate<int>(a, b);
            Console.WriteLine(Submethods<int[]>.GetLength(concatenated.Value));
        }
    }
}
