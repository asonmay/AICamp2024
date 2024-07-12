using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStuff
{
    internal class Graph<T>
    {
        public List<Node<T>> Nodes;
        
        public Graph() => Nodes = new List<Node<T>>();

        public void AddNode(T value, Point pos) => Nodes.Add(new Node<T>(value, pos));

        public void AddEdge(Node<T> startingNode, Node<T> endingNode) => startingNode.AddNeighbor(endingNode);

        public List<Node<T>> Search(NodeWrapper<T> startingNode, NodeWrapper<T> endingNode, Func<List<NodeWrapper<T>>, NodeWrapper<T>> selection, Func<NodeWrapper<T>, NodeWrapper<T>, float> heuristic)
        {
            List<NodeWrapper<T>> visitedNodes = new List<NodeWrapper<T>>();
            NodeWrapper<T> currentNode = startingNode;
            List<NodeWrapper<T>> frontier = new List<NodeWrapper<T>>();

            while (currentNode.WrappedNode != endingNode.WrappedNode)
            {
                for (int i = 0; i < currentNode.WrappedNode.Neighbors.Count; i++)
                {
                    float distanceFromStart = currentNode.DistanceFromStart + currentNode.WrappedNode.Neighbors[i].Weight;
                    float distanceFromEnd = distanceFromStart + heuristic(currentNode, endingNode);
                    NodeWrapper<T> neighbor = new NodeWrapper<T>(currentNode.WrappedNode.Neighbors[i].EndingNode, distanceFromStart, distanceFromEnd, currentNode);
                    if (!visitedNodes.Contains(neighbor))
                    {
                        frontier.Add(neighbor);
                    }
                }

                visitedNodes.Add(currentNode);
                currentNode = selection(frontier);
            }

            List<Node<T>> path = new List<Node<T>>();
            while(currentNode.WrappedNode != startingNode.WrappedNode)
            {
                path.Add(currentNode.WrappedNode);
                currentNode = currentNode.Founder;
            }
            path.Add(currentNode.WrappedNode);
            path.Reverse();

            return path;
        }
    }
}
