using Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICamp2024
{
    public class Graph<T>
    {
        public List<Node<T>> Nodes;
        
        public Graph() => Nodes = new List<Node<T>>();

        public void AddNode(T value) => Nodes.Add(new Node<T>(value));

        public void AddEdge(Node<T> startingNode, Node<T> endingNode) => startingNode.AddNeighbor(endingNode);

        public List<Node<T>> Search(NodeWrapper<T> startingNode, NodeWrapper<T> endingNode, Func<List<NodeWrapper<T>>, NodeWrapper<T>> selection)
        {
            List<NodeWrapper<T>> nodes = new List<NodeWrapper<T>>();
            NodeWrapper<T> currentNode = startingNode;
            List<NodeWrapper<T>> frontier = new List<NodeWrapper<T>>();

            while (currentNode.WrappedNode != endingNode.WrappedNode)
            {
                for (int i = 0; i < currentNode.WrappedNode.Neighbors.Count; i++)
                {
                    float distanceFromStart = currentNode.DistanceFromStart + currentNode.WrappedNode.Neighbors[i].Weight;
                    NodeWrapper<T> neighbor = new NodeWrapper<T>(currentNode.WrappedNode.Neighbors[i].EndingNode, distanceFromStart);
                    if (!frontier.Contains(neighbor) && !nodes.Contains(neighbor))
                    {
                        frontier.Add(neighbor);
                        neighbor.Founder = currentNode;
                    }
                }
                nodes.Add(currentNode);
                currentNode = selection(frontier);
            }
            nodes.Add(currentNode);

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
