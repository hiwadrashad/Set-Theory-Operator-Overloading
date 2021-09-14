using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set_Theory_Operator_Overloading_LIB.DTO_s
{
    public class Vertex<T>
    {
        Vertex<T>[] neighbors;
        T value;
        bool isVisited;

        public Vertex<T>[] Neighbors { get { return neighbors; } set { neighbors = value; } }
        public T Value { get { return value; } set { this.value = value; } }
        public bool IsVisited { get { return isVisited; } set { isVisited = value; } }
        public int NeighborsCount { get { return neighbors.Length; } }

        public Vertex(T value)
        {
            this.value = value;
            isVisited = false;
            neighbors = new Vertex<T>[0];
        }

        public Vertex(T value, Vertex<T>[] neighbors)
        {
            this.value = value;
            isVisited = false;
            this.neighbors = neighbors;
        }

        public void Visit()
        {
            isVisited = true;
        }

#pragma warning disable CS0693 // Type parameter has the same name as the type parameter from outer type
        public Vertex<T>[] AddEdge<T>(Vertex<T> Edge, int sizeincrease = 1)
#pragma warning restore CS0693 // Type parameter has the same name as the type parameter from outer type
        {
            Vertex<T>[] ReturnArray = new Vertex<T>[neighbors.Length + sizeincrease];
            int index = 0;
            foreach (var AValue in neighbors)
            {
                ReturnArray[index] = (dynamic)AValue;
                index = index + 1;
            }
            ReturnArray[neighbors.Length + sizeincrease - 1] = Edge;

            neighbors = (dynamic)ReturnArray;


            return (dynamic)neighbors;
        }

        public void RemoveEdge<T>(Vertex<T> vertex)
        {
            int index = 0;
            foreach (var item in Neighbors)
            {
                if ((dynamic)item == (dynamic)vertex)
                {
                    break;
                }
                index = index + 1;
            }
            Vertex<T>[] ReturnArray = new Vertex<T>[Neighbors.Length - 1];
            for (int i = index; i <= Neighbors.Length - 1; i++)
            {
                if (i == Neighbors.Length - 1)
                {
                    int Index2 = 0;
                    foreach (var item in Neighbors)
                    {
                        if (Index2 == Neighbors.Length - 1)
                        {

                        }
                        else
                        {
                            ReturnArray[Index2] = (dynamic)Neighbors[Index2];
                        }
                        Index2 = Index2 + 1;
                    }
                }
                else
                {
                    Neighbors[i] = Neighbors[i + 1];
                }
            }
        }


    }
}
