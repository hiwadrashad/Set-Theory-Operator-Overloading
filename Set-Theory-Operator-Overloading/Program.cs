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
            Set<int> b = new Set<int>(new int[] { 1 });
            Submethods<int[]>.RemoveRepeatingValue<int>(ref a.Value);
            Console.WriteLine(a.Value[0].ToString() + a.Value[1].ToString() + a.Value[2].ToString());
        }
    }
}
