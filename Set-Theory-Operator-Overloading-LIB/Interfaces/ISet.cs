using Set_Theory_Operator_Overloading_LIB.Sets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set_Theory_Operator_Overloading_LIB.Interfaces
{
    public interface ISet<T>
    {

        T[] Value { get; set; }
        T[][] CartesianValue { get; set; }

        public T this[int index]
        {
            get;
            set;
        }

        void InsertData(ref T[] Collection, int index, T InputValue);
        void SetAt(ref T[] Collection, int index, T InputValue);
        void RemoveAtIndex<T>(ref T[] Collection, int index);
        Set<A> Intersection<A>(ref A[] ArrayA, ref A[] ArrayB);
        Set<A> Add<A>(ref A[] ArrayA, A Value, int sizeincrease = 1);
        A[] AddWithoutReference<A>(A[] ArrayA, A Value, int sizeincrease = 1);
        Set<T> Complement<A>(ref A[] ArrayA, ref A[] ArrayB);
        A[] Remove<A>(ref A[] ArrayA, A Value, int sizedecrease = 1);
        Set<T> PowerSet(ref T[] InputSet);
        Set<T> CartesianProduct(T[] arr1, T[] arr2);
        int Count<A>(A[] Input);
        T[] Clear(ref T[] input);
        bool Contains<A>(A[] input, A Value);
        public T[] ToArray<A>(Set<T> input);
        bool Equals(object obj);
        int GetHashCode();
        System.Collections.IEnumerator GetEnumerator();
        void Dispose();
        void Dispose(bool disposing);
    }
}
