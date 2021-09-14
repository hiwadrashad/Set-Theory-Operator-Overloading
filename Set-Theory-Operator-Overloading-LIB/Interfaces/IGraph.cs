using Set_Theory_Operator_Overloading_LIB.DTO_s;
using Set_Theory_Operator_Overloading_LIB.Sets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set_Theory_Operator_Overloading_LIB.Interfaces
{
    public interface IGraph<T>
    {

        public void AddVertex(Vertex<T> vertex, int sizeincrease = 1);
        public void RemoveVertex(Vertex<T> vertex);
        public bool HasVertex(Vertex<T> vertex);
        public bool HasVertexOptional(Vertex<T>[] Graph, Vertex<T> vertex);
        public void Search(Vertex<T> root);
        public Vertex<T>[] GetValues();
        public Vertex<T>[][] GetCartesian();
        public void InsertData(ref T[] Collection, int index, T InputValue);
        public void SetAt(ref T[] Collection, int index, T InputValue);
        public void RemoveAtIndex<T>(ref T[] Collection, int index);
        public Graph<A> Intersection<A>(ref Vertex<A>[] ArrayA, ref Vertex<A>[] ArrayB);
        public Graph<A> Add<A>(ref Vertex<A>[] ArrayA, Vertex<A> Value, int sizeincrease = 1);
        public Set<A> Add<A>(ref A[] ArrayA, A Value, int sizeincrease = 1);
        public A[] AddWithoutReference<A>(A[] ArrayA, A Value, int sizeincrease = 1);
        public Set<T> Complement<A>(ref A[] ArrayA, ref A[] ArrayB);
        public A[] Remove<A>(ref A[] ArrayA, A Value, int sizedecrease = 1);
        public Set<T> PowerSet(ref T[] InputSet);
        public Set<T> CartesianProduct(T[] arr1, T[] arr2);
        public int Count<A>(A[] Input);
        public T[] Clear(ref T[] input);
        public bool Contains<A>(A[] input, A Value);
        public Vertex<T>[] ToArray<A>(Graph<T> input);
        public bool Equals(object obj);
        public int GetHashCode();
        public IEnumerator GetEnumerator();
        public void Dispose();
        public void Dispose(bool disposing);
    }
}
