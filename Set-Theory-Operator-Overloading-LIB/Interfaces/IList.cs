using Set_Theory_Operator_Overloading_LIB.Sets;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set_Theory_Operator_Overloading_LIB.Interfaces
{
    public interface IList<T>
    {
        T[] GetValues();
        T[][] GetCartesian();
        List<A> Intersection<A>(ref A[] ArrayA, ref A[] ArrayB);
        List<A> Add<A>(ref A[] ArrayA, A Value, int sizeincrease = 1);
        List<T> Complement<A>(ref A[] ArrayA, ref A[] ArrayB);
        List<T> PowerSet(ref T[] InputSet);
        List<T> CartesianProduct(T[] arr1, T[] arr2);
        bool Equals(object obj);
        int GetHashCode();
        System.Collections.IEnumerator GetEnumerator();
        void Dispose();
        void Dispose(bool disposing);
        public bool IsReadOnly { get; }
    }
}
