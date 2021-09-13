using Set_Theory_Operator_Overloading_LIB.DTO_s;
using Set_Theory_Operator_Overloading_LIB.Methods;
using Set_Theory_Operator_Overloading_LIB.Singletons;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Set_Theory_Operator_Overloading_LIB.Sets
{

    public class BinaryTree<T>
    {

        public Node<T> Root { get; set; }
        public T[][] CartesianValue { get; set; } 

        public bool Add(int value, T Data)
        {
            Node<T> before = null, after = this.Root;

            while (after != null)
            {
                before = after;
                if (value < after.Id)
                    after = after.LeftNode;
                else if (value > after.Id)
                    after = after.RightNode;
                else
                {

                    return false;
                }
            }

            Node<T> newNode = new Node<T>();
            newNode.Id = value;
            newNode.Data = Data;

            if (this.Root == null)
                this.Root = newNode;
            else
            {
                if (value < before.Id)
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }

            return true;
        }

        public Node<T> Find(int value)
        {
            return this.Find(value, this.Root);
        }

        public void Remove(int value)
        {
            this.Root = Remove(this.Root, value);
        }

        public Node<T> Remove(Node<T> parent, int key)
        {
            if (parent == null) return parent;

            if (key < parent.Id) parent.LeftNode = Remove(parent.LeftNode, key);
            else if (key > parent.Id)
                parent.RightNode = Remove(parent.RightNode, key);

            else
            {
                if (parent.LeftNode == null)
                    return parent.RightNode;
                else if (parent.RightNode == null)
                    return parent.LeftNode;

                parent.Id = MinValue(parent.RightNode);

                parent.RightNode = Remove(parent.RightNode, parent.Id);
            }

            return parent;
        }

        public int MinValue(Node<T> node)
        {
            int minv = node.Id;

            while (node.LeftNode != null)
            {
                minv = node.LeftNode.Id;
                node = node.LeftNode;
            }

            return minv;
        }

        public Node<T> Find(int value, Node<T> parent)
        {
            if (parent != null)
            {
                if (value == parent.Id) return parent;
                if (value < parent.Id)
                    return Find(value, parent.LeftNode);
                else
                    return Find(value, parent.RightNode);
            }

            return null;
        }

        public int GetTreeDepth()
        {
            return this.GetTreeDepth(this.Root);
        }

        public int GetTreeDepth(Node<T> parent)
        {
            return parent == null ? 0 : Math.Max(GetTreeDepth(parent.LeftNode), GetTreeDepth(parent.RightNode)) + 1;
        }


        public void SetAt(BinaryTree<T> Collection, int index, T InputValue)
        {
            if (index > Collection.GetTreeDepth())
            {
                throw new ArgumentException("Faulty value");
            }
            else
            {
                var Item = Collection.Find(index);
                Item.Data = (dynamic)InputValue;
            }

        }



        public bool Contains(Node<T> parent, T Value)
        {
            {

                if (parent != null)
                {
                    if (parent.Data == (dynamic)Value)
                    {
                        return true;
                    }
                    Contains(parent.LeftNode, Value);
                    Contains(parent.RightNode, Value);
                }

                return false;
            }
        }

        public void RemoveAtIndex<T>(BinaryTree<T> Collection, int index)
        {
            Collection.Remove(index);
        }

        public static bool operator <(BinaryTree<T> MainSet, BinaryTree<T> Subset)
        {
            bool NOTFOUND = false;
            for (int i = 1; i <= Subset.GetTreeDepth(); i++)
            {
                if (MainSet.GetTreeDepth() == 0)
                {
                    return false;
                }
                if (!MainSet.Contains(MainSet.Find(1), MainSet.Find(i).Data))
                {
                    NOTFOUND = true;
                }
                if (NOTFOUND == true)
                {
                    return false;
                }
            }
            return true;
        }





        public static bool operator >(BinaryTree<T> SuperSet, BinaryTree<T> Subset)
        {
            bool NOTFOUND = false;
            for (int i = 0; i == Subset.GetTreeDepth(); i++)
            {
                if (SuperSet.GetTreeDepth() == 0)
                {
                    return false;
                }
                if (!SuperSet.Contains(SuperSet.Find(1), SuperSet.Find(i).Data))
                {
                    NOTFOUND = true;
                }
                if (NOTFOUND == true)
                {
                    return false;
                }
            }
            return true;
        }

        public bool ContainsValue(Node<T> parent, T Value)
        {
            {

                if (parent != null)
                {
                    if (parent.Data == (dynamic)Value)
                    {
                        return true;
                    }
                    Contains(parent.LeftNode, Value);
                    Contains(parent.RightNode, Value);
                }

                return false;
            }
        }
        /// <summary>
        /// /////////////////////////
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// 
        public static void Dosomething()
        {
            var BinaryTreeInstance = new BinaryTree<T>();
        }

        public static bool operator == (BinaryTree<T> a, BinaryTree<T> b)
        {
            BinaryTree<T> BinaryTreeInstance = new BinaryTree<T>();
            var CurrentNode = a.Root;
            if (a.GetTreeDepth() == b.GetTreeDepth())
            {
                if (CurrentNode.Id == 1)
                {
                    if (!((dynamic)b.Find(1).Data == (dynamic)a.Find(1).Data))
                    {
                        return false;
                    }
                }
                while (CurrentNode.LeftNode != null)
                {
                    if (!((dynamic)CurrentNode.Data == (dynamic)b.Find(CurrentNode.Id).Data))
                    {
                        return false;
                    }
                    CurrentNode = CurrentNode.LeftNode;
                }
                while (CurrentNode.RightNode != null)
                {
                    if (!((dynamic)CurrentNode.Data == (dynamic)b.Find(CurrentNode.Id).Data))
                    {
                        return false;
                    }
                    CurrentNode = CurrentNode.RightNode;
                }

                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool operator !=(BinaryTree<T> a, BinaryTree<T> b)
        {

            var BinaryTreeInstance = new BinaryTree<T>();
            var CurrentNode = a.Root;
            if (a.GetTreeDepth() == b.GetTreeDepth())
            {
                if (CurrentNode.Id == 1)
                {
                    if (!((dynamic)b.Find(1).Data == (dynamic)a.Find(1).Data))
                    {
                        return true;
                    }
                }
                while (CurrentNode.LeftNode != null)
                {
                    if (!((dynamic)CurrentNode.Data == (dynamic)b.Find(CurrentNode.Id).Data))
                    {
                        return true;
                    }
                    CurrentNode = CurrentNode.LeftNode;
                }
                while (CurrentNode.RightNode != null)
                {
                    if (!((dynamic)CurrentNode.Data == (dynamic)b.Find(CurrentNode.Id).Data))
                    {
                        return true;
                    }
                    CurrentNode = CurrentNode.RightNode;
                }

                return false;
            }
            else
            {
                return true;
            }

        }

        public A[] Intersection<A>(ref A[] ArrayA, ref A[] ArrayB)
        {
            Set<T> SetInstance = new Set<T>(new T[0]);

            A[] Array = new A[0];
            foreach (var Value in ArrayB)
            {
                if (Submethods<A[]>.Contains<A>(ArrayA, Value))
                {
                    SetInstance.Add<A>(ref Array, Value);
                }
            }
            return Array;
        }

        public A[] Add<A>(ref A[] ArrayA, A Value, int sizeincrease = 1)
        {
            A[] ReturnArray = new A[ArrayA.Length + sizeincrease];
            int index = 0;
            foreach (var AValue in ArrayA)
            {
                ReturnArray[index] = AValue;
                index = index + 1;
            }
            ReturnArray[ArrayA.Length + sizeincrease - 1] = Value;

            return ReturnArray;
        }

        public A[] AddWithoutReference<A>(A[] ArrayA, A Value, int sizeincrease = 1)
        {
            A[] ReturnArray = new A[ArrayA.Length + sizeincrease];
            int index = 0;
            foreach (var AValue in ArrayA)
            {
                ReturnArray[index] = AValue;
                index = index + 1;
            }
            ReturnArray[ArrayA.Length + sizeincrease - 1] = Value;

            return ReturnArray;
        }

        public BinaryTree<T> ConvertArrayToNodes(T[] Array)
        {
            BinaryTree<T> Nodes = new BinaryTree<T>();
            int Indexing = 0;
            foreach (var Value in Array)
            {
                Indexing = Indexing + 1;
                Nodes.Add(Indexing, Value);
            }
            return Nodes;
        }

        public BinaryTree<T> Complement<A>(ref A[] ArrayA, ref A[] ArrayB)
        {
            Set<T> SetInstance = new Set<T>(new T[0]);
            Node<T> Nodes = new Node<T>();
            foreach (var Value in ArrayB)
            {
                if (SetInstance.Contains<A>(ArrayA, Value))
                {
                    Remove<A>(ref ArrayA, Value);
                }
            }
            return ConvertArrayToNodes((dynamic)ArrayA);
        }

        public A[] Remove<A>(ref A[] ArrayA, A Value, int sizedecrease = 1)
        {
            if (Submethods<A>.Contains<A>(ArrayA, Value))
            {
                for (int i = Submethods<A[]>.GetLength(ArrayA) - 1; i > -1; i--)
                {
                    if ((dynamic)Value == ArrayA[i])
                    {
                        Submethods<A>.Remove<A>(ref ArrayA, i);
                    }
                }
                return ArrayA;
            }
            else
            {
                return ArrayA;
            }
        }



        public BinaryTree<T> PowerSet(ref T[] InputSet)
        {
            Node<T> Nodes = new Node<T>();
            double count = Math.Pow(2, InputSet.Length);
            for (int i = 1; i <= count - 1; i++)
            {
                string str = Convert.ToString(i, 2).PadLeft(InputSet.Length, '0');
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == '1')
                    {
                        this.Add(GetTreeDepth() + 1, InputSet[j]);
                    }
                }
                if (typeof(T).IsNumericType())
                {
                    this.Add(GetTreeDepth() + 1, (dynamic)(-1));
                }
                else if (typeof(T).IsLanguageType())
                {
                    this.Add(GetTreeDepth() + 1, (dynamic)(" "));
                }

            }
            BinaryTree<T> RetunValue = new BinaryTree<T>();
            RetunValue.Root = Nodes;
            return RetunValue;
        }

        public BinaryTree<T> CartesianProduct(T[] arr1, T[] arr2)
        {
            T[][] combos = new T[arr1.Length * arr2.Length][];

            int ii = 0;
            foreach (var Value in arr1)
            {
                foreach (var Value2 in arr2)
                {
                    T[] combo = new T[2];

                    combo[0] = Value;
                    combo[1] = Value2;
                    combos[ii] = combo;

                    ii++;
                }
            }

            return new BinaryTree<T>() { CartesianValue = combos };
        }


        public T[] Clear(ref T[] input)
        {
            input = new T[0];
            return input;
        }
        public bool Contains<A>(A[] input, A Value)
        {
            return Submethods<A[]>.Contains<A>(input, Value);
        }

        public T[] ToValueArray<A>(Node<T> StartingNode)
        {
            Node<T> CurrentNode = StartingNode.DeepClone();
            T[] Nodes = new T[0];
            if (CurrentNode.Id == 1)
            {
                Add<T>(ref Nodes, CurrentNode.Data);
            }
            while (CurrentNode.LeftNode != null)
            {
                CurrentNode = CurrentNode.LeftNode;
                Add<T>(ref Nodes, CurrentNode.Data);

            }
            while (CurrentNode.RightNode != null)
            {
                CurrentNode = CurrentNode.RightNode;
                Add<T>(ref Nodes, CurrentNode.Data);
            }
            return Nodes;
        }

        public Node<T>[] ToArray<A>(Node<T> Startingnode)
        {
            Node<T> CurrentNode = Startingnode.DeepClone();
            Node<T>[] Nodes = new Node<T>[0];
            if (CurrentNode.Id == 1)
            {
                Add<Node<T>>(ref Nodes,CurrentNode);
            }
            while (CurrentNode.LeftNode != null)
            {
                CurrentNode = CurrentNode.LeftNode;
                Add<Node<T>>(ref Nodes, CurrentNode);
            }
            while (CurrentNode.RightNode != null)
            {
                CurrentNode = CurrentNode.RightNode;
                Add<Node<T>>(ref Nodes, CurrentNode);
            }
            return Nodes;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }


        public int GetHashCode(Node<T> StartingNode)
        {
            Node<T> CurrentNode = StartingNode.DeepClone();
            Node<T>[] Nodes = new Node<T>[0];
            if (CurrentNode.Id == 1)
            {
                Add<Node<T>>(ref Nodes, CurrentNode);
            }
            while (CurrentNode.LeftNode != null)
            {
                CurrentNode = CurrentNode.LeftNode;
                Add<Node<T>>(ref Nodes, CurrentNode);
            }
            while (CurrentNode.RightNode != null)
            {
                CurrentNode = CurrentNode.RightNode;
                Add<Node<T>>(ref Nodes, CurrentNode);
            }
            return Nodes.GetHashCode();
        }


        public IEnumerator<T> GetEnumerator(Node<T> StartingNode)
        {
            Node<T> CurrentNode = StartingNode.DeepClone();
            Node<T>[] Nodes = new Node<T>[0];
            if (CurrentNode.Id == 1)
            {
                Add<Node<T>>(ref Nodes, CurrentNode);
            }
            while (CurrentNode.LeftNode != null)
            {
                CurrentNode = CurrentNode.LeftNode;
                Add<Node<T>>(ref Nodes, CurrentNode);
            }
            while (CurrentNode.RightNode != null)
            {
                CurrentNode = CurrentNode.RightNode;
                Add<Node<T>>(ref Nodes, CurrentNode);
            }
            return (IEnumerator<T>)Nodes.GetEnumerator();
        }
        ~BinaryTree()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
                GC.SuppressFinalize(this);

            this.Dispose();
        }
    }
}




