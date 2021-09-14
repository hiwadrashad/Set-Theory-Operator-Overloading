using Set_Theory_Operator_Overloading_LIB.DTO_s;
using Set_Theory_Operator_Overloading_LIB.Methods;
using Set_Theory_Operator_Overloading_LIB.Sets;
using System;

namespace Set_Theory_Operator_Overloading
{
    public class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> BTS = new BinaryTree<int>();
            BTS.Add(1,40);
            BTS.Add(2, 50);
            BTS.Add(3, 60);

            BinaryTree<int> BTS2 = new BinaryTree<int>();
            BTS2.Add(1, 40);
            BTS2.Add(2, 50);
            BTS2.Add(3, 60);

            Vertex<int> Vertex = new Vertex<int>(1);
            Vertex<int> Vertex2 = new Vertex<int>(2);
            Vertex.AddEdge(Vertex2);

            Graph<int> GRAPH = new Graph<int>(0);
            Vertex<int> VERTEX = new Vertex<int>(10);
            Vertex<int> VERTEX2 = new Vertex<int>(11);
            GRAPH.AddVertex(VERTEX);
            Console.WriteLine(GRAPH.HasVertex(VERTEX));
        }
    }
}
