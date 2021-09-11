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
            var c = Set<int>.CartesianProduct(a.Value,b.Value);
            foreach (var Value in c)
            {
                foreach (var Value2 in Value)
                {
                    Console.WriteLine(Value2);
                }
                Console.WriteLine(" ");
            }
            //Console.WriteLine(c.Value[0].ToString()  + c.Value[1].ToString() + c.Value[2].ToString() + c.Value[3].ToString() + c.Value[4].ToString() + c.Value[5].ToString() + c.Value[6].ToString());
        }
    }
}
