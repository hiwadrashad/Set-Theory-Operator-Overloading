using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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

        public static T DeepClone<T>(this T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                formatter.Serialize(ms, obj);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
                ms.Position = 0;

#pragma warning disable SYSLIB0011 // Type or member is obsolete
                return (T)formatter.Deserialize(ms);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
            }
        }

        public static bool IsNumericType(this object o)
        {
            switch (Type.GetTypeCode(o as Type))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsLanguageType(this object o)
        {
            switch (Type.GetTypeCode(o as Type))
            {
                case TypeCode.String:
                case TypeCode.Char:
                    return true;
                default:
                    return false;
            }
        }
    }
}
