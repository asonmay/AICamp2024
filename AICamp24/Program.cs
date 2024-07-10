using AICamp2024;
using Graph;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace AICamp2024
{
    class Program
    {
        static Graph<int> GenerateGraph(Point size)
        {
            Graph<int> graph = new Graph<int>();

            for(int x = 0; x < size.X * size.Y; x++)
            {             
                graph.AddNode(x, new Point(1,1));                
            }

            for (int y = 0; y < size.Y; y++)
            {
                for (int x = 0; x < size.X; x++)
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

        static NodeWrapper<int> DFSSelection(List<NodeWrapper<int>> nodes)
        {
            NodeWrapper<int> node = nodes[^1];
            nodes.Remove(node);
            return node;
        }

        static NodeWrapper<int> BFSSelection(List<NodeWrapper<int>> nodes)
        {
            NodeWrapper<int> node = nodes[0];
            nodes.Remove(node);
            return node;
        }

        static NodeWrapper<int> DijstrasSelection(List<NodeWrapper<int>> nodes)
        {
            NodeWrapper<int> node = nodes[0];

            for(int i = 0; i < nodes.Count; i++)
            {
                if(nodes[i].DistanceFromStart < node.DistanceFromStart)
                {
                    node = nodes[i];
                }
            }
            nodes.Remove(node);

            return node;
        }

        static NodeWrapper<int> AStarSelection(List<NodeWrapper<int>> nodes)
        {
            NodeWrapper<int> node = nodes[0];

            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].DistanceFromEnd < node.DistanceFromEnd)
                {
                    node = nodes[i];
                }
            }
            nodes.Remove(node);

            return node;
        }

        static float ManhattanHeuristic(NodeWrapper<int> startingNode, NodeWrapper<int> endingNode)
        {
            float dx = Math.Abs(startingNode.WrappedNode.Pos.X - endingNode.WrappedNode.Pos.X);
            float dy = Math.Abs(startingNode.WrappedNode.Pos.Y - endingNode.WrappedNode.Pos.Y);
            return dx + dy;
        }

        static void Main(string[] args)
        {
            Graph<int> graph = GenerateGraph(new Point(4, 3));

            Func<List<NodeWrapper<int>>, NodeWrapper<int>> selection = DijstrasSelection;
            Func<NodeWrapper<int>, NodeWrapper<int>, float> heuristic = ManhattanHeuristic;

            List<Node<int>> path = graph.Search(new NodeWrapper<int>(graph.Nodes[0], 0, float.MaxValue, null), new NodeWrapper<int>(graph.Nodes[11], float.MaxValue, 0, null), selection, heuristic);
            ;
        }
    }
}
