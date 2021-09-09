using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
