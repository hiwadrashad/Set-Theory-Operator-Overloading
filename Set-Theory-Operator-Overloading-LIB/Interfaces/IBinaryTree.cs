using Set_Theory_Operator_Overloading_LIB.DTO_s;
using Set_Theory_Operator_Overloading_LIB.Sets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set_Theory_Operator_Overloading_LIB.Interfaces
{
    public interface IBinaryTree<T>
    {
        public bool Add(int value, T Data);
        public Node<T> Find(int value);
        public void Remove(int value);
        public Node<T> Remove(Node<T> parent, int key);
        public int MinValue(Node<T> node);
        public Node<T> Find(int value, Node<T> parent);
        public int GetTreeDepth();
        public int GetTreeDepth(Node<T> parent);
        public void SetAt(BinaryTree<T> Collection, int index, T InputValue);
        public bool Contains(Node<T> parent, T Value);
        public void RemoveAtIndex<T>(BinaryTree<T> Collection, int index);
        public bool ContainsValue(Node<T> parent, T Value);
        public A[] Intersection<A>(ref A[] ArrayA, ref A[] ArrayB);
        public A[] Add<A>(ref A[] ArrayA, A Value, int sizeincrease = 1);
        public A[] AddWithoutReference<A>(A[] ArrayA, A Value, int sizeincrease = 1);
        public BinaryTree<T> ConvertArrayToNodes(T[] Array);
        public BinaryTree<T> Complement<A>(ref A[] ArrayA, ref A[] ArrayB);
        public A[] Remove<A>(ref A[] ArrayA, A Value, int sizedecrease = 1);
        public BinaryTree<T> PowerSet(ref T[] InputSet);
        public BinaryTree<T> CartesianProduct(T[] arr1, T[] arr2);
        public T[] Clear(ref T[] input);
        public bool Contains<A>(A[] input, A Value);
        public T[] ToValueArray<A>(Node<T> StartingNode);
        public Node<T>[] ToArray<A>(Node<T> Startingnode);
        public bool Equals(object obj);
        public int GetHashCode(Node<T> StartingNode);
        public IEnumerator<T> GetEnumerator(Node<T> StartingNode);
        public void Dispose();
        public void Dispose(bool disposing);
    }
}
