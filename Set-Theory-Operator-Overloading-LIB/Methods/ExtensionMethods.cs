using System;
using System.Text;
using System.Threading.Tasks;

namespace Set_Theory_Operator_Overloading_LIB.Methods
{
    public static class ExtensionMethods
    {
        public static T IndexOf<T>(T Generic, int index )
        {
           var DynamicGeneric = (dynamic)Generic;
            return DynamicGeneric[index];
        }
    }
}
