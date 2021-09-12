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


            var BTSArray = BinaryTree<int>.ToValueArray<int>(BTS.Root);
            var BTS2Array = BinaryTree<int>.ToValueArray<int>(BTS2.Root);
            var Complement = BinaryTree<int>.Complement<int>(ref BTSArray, ref BTS2Array);
            var Array = BinaryTree<int>.ToValueArray<int>(Complement.Root);

            Console.WriteLine(Array[0].ToString()  + Array[1].ToString() + Array[2].ToString());
        }
    }
}
