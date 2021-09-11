using Set_Theory_Operator_Overloading_LIB.Methods;
using Set_Theory_Operator_Overloading_LIB.Sets;
using System;

namespace Set_Theory_Operator_Overloading
{
    public class Program
    {
        static void Main(string[] args)
        {
            Set<int> a = new Set<int>( new int[] {1,2,2,3});
            Set<int> b = new Set<int>(new int[] { 1, 2,4});
            bool issubsetof = a < b;
            Console.WriteLine(issubsetof);
        }
    }
}
