using Set_Theory_Operator_Overloading_LIB.Methods;
using Set_Theory_Operator_Overloading_LIB.Sets;
using System;

namespace Set_Theory_Operator_Overloading
{
    public class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> BTS = new BinaryTree<int>();
            BTS.Add(1,40);
            BTS.Add(2, 50);
            BTS.Add(3, 60);

            BinaryTree<int> BTS2 = new BinaryTree<int>();
            BTS2.Add(4, 10);
            BTS2.Add(5, 20);
            BTS2.Add(6, 30);

            BTS.Add(4, 70);

            //BinaryTree<int>.Dosomething();
            BinaryTree<int>.Dosomething();
            Console.WriteLine("");
        }
    }
}
