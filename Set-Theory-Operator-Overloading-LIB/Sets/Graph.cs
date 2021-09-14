using Set_Theory_Operator_Overloading_LIB.DTO_s;
using Set_Theory_Operator_Overloading_LIB.Interfaces;
using Set_Theory_Operator_Overloading_LIB.Methods;
using System;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

namespace Set_Theory_Operator_Overloading_LIB.Sets
{
    public class Graph<T> : IGraph<T>
    {
        public Vertex<T>[] vertices;

        public Vertex<T>[][] CartesianValue;

        int size;

        public Vertex<T>[] Vertices { get { return vertices; } }
        public int Size { get { return vertices.Length; } }


        public Graph(int initialSize)
        {
            if (size < 0)
            {
                throw new ArgumentException("Number of vertices cannot be negative");
            }

            size = initialSize;

            vertices = new Vertex<T>[initialSize];

        }

        public Graph(Vertex<T>[] initialNodes)
        {
            vertices = initialNodes;
            size = vertices.Length;
        }

        public void AddVertex(Vertex<T> vertex, int sizeincrease = 1)
        {
            Vertex<T>[] ReturnArray = new Vertex<T>[vertices.Length + sizeincrease];
            int index = 0;
            foreach (var AValue in vertices)
            {
                ReturnArray[index] = AValue;
                index = index + 1;
            }
            ReturnArray[vertices.Length + sizeincrease - 1] = vertex;

            vertices = ReturnArray;
        }

        public void RemoveVertex(Vertex<T> vertex)
        {
            int index = 0;
            foreach (var item in Vertices)
            {
                if ((dynamic)item == (dynamic)vertex)
                {
                    break;
                }
                index = index + 1;
            }
            Vertex<T>[] ReturnArray = new Vertex<T>[Vertices.Length - 1];
            for (int i = index; i <= Vertices.Length - 1; i++)
            {
                if (i == Vertices.Length - 1)
                {
                    int Index2 = 0;
                    foreach (var item in Vertices)
                    {
                        if (Index2 == Vertices.Length - 1)
                        {

                        }
                        else
                        {
                            ReturnArray[Index2] = (dynamic)Vertices[Index2];
                        }
                        Index2 = Index2 + 1;
                    }
                }
                else
                {
                    Vertices[i] = Vertices[i + 1];
                }
            }
        }

        public bool HasVertex(Vertex<T> vertex)
        {
            foreach (var Item in Vertices)
            {
                if (Item == vertex)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasVertexOptional(Vertex<T>[] Graph, Vertex<T> vertex)
        {
            foreach (var Node in Graph)
            {
                if (Node == vertex)
                {
                    return true;
                }

            }
            return false;

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

        public Vertex<T>[] GetValues()
        {
            return vertices;
        }

        public Vertex<T>[][] GetCartesian()
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

        public static bool operator <(Graph<T> MainSet, Graph<T> Subset)
        {
            Set<T> SetInstance = new Set<T>(new T[0]);

            bool NOTFOUND = false;
            foreach (var Value in Subset.vertices)
            {
                if (!SetInstance.Contains<int>((dynamic)MainSet.vertices, (dynamic)Value))
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

        public static bool operator >(Graph<T> SuperSet, Graph<T> Subset)
        {
            Set<T> SetInstance = new Set<T>(new T[0]);

            bool NOTFOUND = false;
            foreach (var Value in Subset.vertices)
            {
                if (!SetInstance.Contains<int>((dynamic)SuperSet.vertices, (dynamic)Value))
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


        public static bool operator ==(Graph<T> a, Graph<T> b)
        {


            if (a.vertices.Length == b.vertices.Length)
            {
                foreach (var index in (dynamic)a.vertices)
                {
                    var BList = (dynamic)b.vertices;
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

        public static bool operator !=(Graph<T> a, Graph<T> b)
        {


            if (a.Vertices.Length == b.vertices.Length)
            {
                foreach (var index in (dynamic)a.vertices)
                {
                    var BList = (dynamic)b.vertices;
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

        public Graph<A> Intersection<A>(ref Vertex<A>[] ArrayA, ref Vertex<A>[] ArrayB)
        {
            Graph<T> SetInstance = new Graph<T>(0);

            Vertex<A>[] Array = new Vertex<A>[0];
            foreach (var Value in ArrayB)
            {
                if ( HasVertexOptional((dynamic)ArrayA,(dynamic)Value))
                {
                    SetInstance.Add<A>(ref Array, Value);
                }
            }
            Graph<A> GRAPH = new Graph<A>(0);
             
            return new Graph<A>(Array);
        }

        public Graph<A> Add<A>(ref Vertex<A>[] ArrayA, Vertex<A> Value, int sizeincrease = 1)
        {
            Vertex<A>[] ReturnArray = new Vertex<A>[ArrayA.Length + sizeincrease];
            int index = 0;
            foreach (var AValue in ArrayA)
            {
                ReturnArray[index] = AValue;
                index = index + 1;
            }
            ReturnArray[ArrayA.Length + sizeincrease - 1] = Value;

            ArrayA = ReturnArray;

            var Return = new Graph<A>(ReturnArray);

            return Return;
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
                if ( SetInstance.Contains<A>(ArrayA, Value))
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

        public Vertex<T>[] ToArray<A>(Graph<T> input)
        {
            return input.Vertices;
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
            return Vertices.GetHashCode();
        }

        public IEnumerator GetEnumerator()
        {
            return Vertices.GetEnumerator();
        }
        ~Graph()
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
