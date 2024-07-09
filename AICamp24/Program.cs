using System;
using System.Collections.Generic;
using System.Drawing;

namespace AICamp2024
{
    class Program
    {
        static Graph<int> generateGraph(Point size)
        {
            Graph<int> graph = new Graph<int>();

            for (int i = 0; i < size.X * size.Y; i++)
            {
                graph.AddNode(i);
            }

            for (int x = 0; x < size.X; x++)
            {
                for (int y = 0; y < size.Y; y++)
                {
                    if (x + 1 < size.X)
                    {
                        graph.Nodes[y * size.X + x].AddNeighbor(graph.Nodes[y * size.X + x + 1]);
                    }
                    if (y + 1 < size.Y)
                    {
                        graph.Nodes[y * size.X + x].AddNeighbor(graph.Nodes[(y + 1) * size.X + x]);
                    }
                }
            }

            return graph;
        }

        static Node<int> DFSSelection(List<Node<int>> nodes)
        {
            Node<int> node = nodes[^1];
            nodes.Remove(node);
            return node;
        }

        static Node<int> BFSSelection(List<Node<int>> nodes)
        {
            Node<int> node = nodes[0];
            nodes.Remove(node);
            return node;
        }

        static void Main(string[] args)
        {
            Graph<int> graph = generateGraph(new Point(4, 3));

            Func<List<Node<int>>, Node<int>> selection = DFSSelection;

            List<Node<int>> path = graph.Search(graph.Nodes[0], graph.Nodes[8], selection);
            ;
        }
    }
}
