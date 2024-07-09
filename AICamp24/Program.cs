using System;
using System.Collections.Generic;

namespace AICamp2024
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<int> graph = new Graph<int>();

            for (int i = 0; i < 12; i++)
            {
                graph.AddNode(i);
            }

            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (x + 1 != 4)
                    {
                        graph.Nodes[x * 3 + y].AddNeighbor(graph.Nodes[(x + 1) * 3 + y]);
                    }
                    if (y + 1 != 3)
                    {
                        graph.Nodes[x * 3 + y].AddNeighbor(graph.Nodes[x * 3 + y + 1]);
                    }
                }
            }

            List<Node<int>> depthFirstSearch = graph.DepthFirstSearch(graph.Nodes[0], graph.Nodes[8]);
            List<Node<int>> breathFirstSearch = graph.BreathFirstSearch(graph.Nodes[0], graph.Nodes[8]);
            ;
        }
    }
}
