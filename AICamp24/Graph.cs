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

        public List<Node<T>> DepthFirstSearch(Node<T> startingNode, Node<T> endingNode)
        {
            List<Node<T>> nodes = new List<Node<T>>();
            Node<T> currentNode = startingNode;
            Stack<Node<T>> frontier = new Stack<Node<T>>();

            while(currentNode != endingNode)
            {
                for(int i = 0; i < currentNode.Neighbors.Count; i++)
                {
                    Node<T> neighbor = currentNode.Neighbors[i].EndingNode;
                    if (!nodes.Contains(neighbor))
                    {
                        frontier.Push(neighbor);
                    }
                }
                nodes.Add(currentNode);
                currentNode = frontier.Pop();
            }

            nodes.Add(currentNode);
            return nodes;
        }

        public List<Node<T>> BreathFirstSearch(Node<T> startingNode, Node<T> endingNode)
        {
            List<Node<T>> nodes = new List<Node<T>>();
            Node<T> currentNode = startingNode;
            Queue<Node<T>> frontier = new Queue<Node<T>>(); 

            while (currentNode != endingNode)
            {
                for (int i = 0; i < currentNode.Neighbors.Count; i++)
                {
                    Node<T> neighbor = currentNode.Neighbors[i].EndingNode;
                    if (!frontier.Contains(neighbor) && !nodes.Contains(neighbor))
                    {
                        frontier.Enqueue(neighbor);
                    }
                }
                nodes.Add(currentNode);
                currentNode = frontier.Dequeue();
            }

            nodes.Add(currentNode);
            return nodes;
        }

        public List<Node<T>> Search(Node<T> startingNode, Node<T> endingNode, Func<List<Node<T>>, Node<T>> selection)
        {
            List<Node<T>> nodes = new List<Node<T>>();
            Node<T> currentNode = startingNode;
            List<Node<T>> frontier = new List<Node<T>>();

            while (currentNode != endingNode)
            {
                for (int i = 0; i < currentNode.Neighbors.Count; i++)
                {
                    Node<T> neighbor = currentNode.Neighbors[i].EndingNode;
                    if (!frontier.Contains(neighbor) && !nodes.Contains(neighbor))
                    {
                        frontier.Add(neighbor);
                    }
                }
                nodes.Add(currentNode);
                currentNode = selection(frontier);
            }

            nodes.Add(currentNode);
            return nodes;
        }

    }
}
