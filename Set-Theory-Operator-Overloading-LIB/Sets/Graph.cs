using Set_Theory_Operator_Overloading_LIB.DTO_s;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Set_Theory_Operator_Overloading_LIB.Sets
{
    public class Graph<T>
    {
        // The list of vertices in the graph
        private List<Vertex<T>> vertices;

        // The number of vertices
        int size;

        public List<Vertex<T>> Vertices { get { return vertices; } }
        public int Size { get { return vertices.Count; } }


        public Graph(int initialSize)
        {
            if (size < 0)
            {
                throw new ArgumentException("Number of vertices cannot be negative");
            }

            size = initialSize;

            vertices = new List<Vertex<T>>(initialSize);

        }

        public Graph(List<Vertex<T>> initialNodes)
        {
            vertices = initialNodes;
            size = vertices.Count;
        }

        public void AddVertex(Vertex<T> vertex)
        {
            vertices.Add(vertex);
        }

        public void RemoveVertex(Vertex<T> vertex)
        {
            vertices.Remove(vertex);
        }

        public bool HasVertex(Vertex<T> vertex)
        {
            return vertices.Contains(vertex);
        }

        public void Search(Vertex<T> root)
        {
            if (!root.IsVisited)
            {
                root.Visit();

                foreach (Vertex<T> neighbor in root.Neighbors)
                {
                    Search(neighbor);
                }

            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="EdgeCollection"></param>
        /// <param name="Edge"></param>
        /// <param name="sizeincrease"></param>
        /// <returns></returns>
        public Vertex<T>[] AddEdge<T>(ref Vertex<T>[] EdgeCollection, Vertex<T> Edge, int sizeincrease = 1)
        {
            Vertex<T>[] ReturnArray = new Vertex<T>[EdgeCollection.Length + sizeincrease];
            int index = 0;
            foreach (var AValue in EdgeCollection)
            {
                ReturnArray[index] = AValue;
                index = index + 1;
            }
            ReturnArray[EdgeCollection.Length + sizeincrease - 1] = Edge;

            EdgeCollection = ReturnArray;


            return EdgeCollection;
        }



        public static A[] RemoveEdge<A>(Vertex<A>[] Array, int index)
        {
            A[] ReturnArray = new A[Array.Length - 1];
            for (int i = index; i <= Array.Length - 1; i++)
            {
                if (i == Array.Length - 1)
                {
                    int Index2 = 0;
                    foreach (var item in Array)
                    {
                        if (Index2 == Array.Length - 1)
                        {

                        }
                        else
                        {
                            ReturnArray[Index2] = Array[Index2];
                        }
                        Index2 = Index2 + 1;
                    }
                }
                else
                {
                    Array[i] = Array[i + 1];
                }
            }
            Array = ReturnArray;
            return Array;
        }

        public T[] GetValues()
        {
            return Value;
        }

        public T[][] GetCartesian()
        {
            return CartesianValue;
        }

        public void InsertData(ref T[] Collection, int index, T InputValue)
        {
            T[] TempCollection = new T[0] { };
            for (int i = 0; i < index; i++)
            {
                Add<T>(ref TempCollection, Collection[i]);
            }
            Add<T>(ref TempCollection, InputValue);
            for (int i = index; i < Collection.Length; i++)
            {
                Add<T>(ref TempCollection, Collection[i]);
            }

            Collection = TempCollection;
        }

        public void SetAt(ref T[] Collection, int index, T InputValue)
        {
            if (index > Collection.Length || index < Collection.Length)
            {
                throw new ArgumentException("Faulty value");
            }
            else
            {

                Collection[index] = InputValue;
            }

        }

        public void RemoveAtIndex<T>(ref T[] Collection, int index)
        {
            Submethods<int>.Remove(ref Collection, index);
        }

        public static bool operator <(Set<T> MainSet, Set<T> Subset)
        {
            Set<T> SetInstance = new Set<T>(new T[0]);

            bool NOTFOUND = false;
            foreach (var Value in Subset.Value)
            {
                if (!SetInstance.Contains<int>((dynamic)MainSet.Value, (dynamic)Value))
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

        public static bool operator >(Set<T> SuperSet, Set<T> Subset)
        {
            Set<T> SetInstance = new Set<T>(new T[0]);

            bool NOTFOUND = false;
            foreach (var Value in Subset.Value)
            {
                if (!SetInstance.Contains<int>((dynamic)SuperSet.Value, (dynamic)Value))
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


        public static bool operator ==(Set<T> a, Set<T> b)
        {


            if (a.Value.Length == b.Value.Length)
            {
                foreach (var index in (dynamic)a.Value)
                {
                    var BList = (dynamic)b.Value;
                    if (index == BList[index - 1])
                    {
                        return true;
                    }

                }
                return false;

            }
            else
            {
                return false;
            }

        }

        public static bool operator !=(Set<T> a, Set<T> b)
        {


            if (a.Value.Length == b.Value.Length)
            {
                foreach (var index in (dynamic)a.Value)
                {
                    var BList = (dynamic)b.Value;
                    if (index == BList[index - 1])
                    {
                        return false;
                    }

                }
                return true;

            }
            else
            {
                return true;
            }

        }

        public Set<A> Intersection<A>(ref A[] ArrayA, ref A[] ArrayB)
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
            return new Set<A>(Array);
        }

        public Set<A> Add<A>(ref A[] ArrayA, A Value, int sizeincrease = 1)
        {
            A[] ReturnArray = new A[ArrayA.Length + sizeincrease];
            int index = 0;
            foreach (var AValue in ArrayA)
            {
                ReturnArray[index] = AValue;
                index = index + 1;
            }
            ReturnArray[ArrayA.Length + sizeincrease - 1] = Value;

            ArrayA = ReturnArray;

            var Return = new Set<A>(ReturnArray);

            return Return;
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

        public Set<T> Complement<A>(ref A[] ArrayA, ref A[] ArrayB)
        {
            Set<T> SetInstance = new Set<T>(new T[0]);
            foreach (var Value in ArrayB)
            {
                if (SetInstance.Contains<A>(ArrayA, Value))
                {
                    Remove<A>(ref ArrayA, Value);
                }
            }
            return new Set<T>((dynamic)ArrayA);
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



        public Set<T> PowerSet(ref T[] InputSet)
        {
            T[] TempArray = new T[0];
            double count = Math.Pow(2, InputSet.Length);
            for (int i = 1; i <= count - 1; i++)
            {
                string str = Convert.ToString(i, 2).PadLeft(InputSet.Length, '0');
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == '1')
                    {
                        Add<T>(ref TempArray, InputSet[j]);
                    }
                }
                if (typeof(T).IsNumericType())
                {
                    Add<T>(ref TempArray, (dynamic)(-1));
                }
                else if (typeof(T).IsLanguageType())
                {
                    Add<T>(ref TempArray, (dynamic)(" "));
                }

            }
            InputSet = TempArray;
            return new Set<T>(TempArray);
        }

        public Set<T> CartesianProduct(T[] arr1, T[] arr2)
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

            return new Set<T>(new T[0]) { CartesianValue = combos };
        }

        public int Count<A>(A[] Input)
        {

            return Submethods<A[]>.GetLength(Input);
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

        public T[] ToArray<A>(Set<T> input)
        {
            return input.Value;
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


        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public IEnumerator GetEnumerator()
        {
            return Value.GetEnumerator();
        }

        ~Set()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
                GC.SuppressFinalize(this);

            this.Dispose();
        }
    }
}
