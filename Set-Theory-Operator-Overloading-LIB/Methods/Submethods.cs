using Set_Theory_Operator_Overloading_LIB.Sets;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Set_Theory_Operator_Overloading_LIB.Methods
{
    public class Submethods<T> where T :  class
    {
        public static int GetLength(T input)
        {
            int length = 0;
            foreach (var index in (dynamic)input)
            {
                length = length + 1;
            }
            return length;
        }

        public static Set<T> Concatenate <A> (Set<T> a, Set<T> b)
        {
            var AList = a.Value as A[];
            var BList = b.Value as A[];
            AList.CopyTo(BList, AList.Length);
            a.Value = (dynamic)AList;
            return a;
        }
    }
}
