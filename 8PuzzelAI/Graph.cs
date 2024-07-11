using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8PuzzelAI
{
    public class Graph
    {
        public List<Node> Nodes;
        
        public Graph() => Nodes = new List<Node>();

        public void AddNode(int[,] value) => Nodes.Add(new Node(value));

        public void AddEdge(Node startingNode, Node endingNode) => startingNode.AddNeighbor(endingNode);

        private List<Node> GenerateSuccessors(Node node)
        {
            Point sliderIndex = new Point();
            for(int x = 0; x < node.Value.GetLength(0); x++)
            {
                for(int y = 0; y < node.Value.GetLength(1); y++)
                {
                    if (node.Value[x,y] == 0)
                    {
                        sliderIndex = new Point(x, y);
                    }
                }
            }

            List<Node> nodes = new List<Node>();
            if(sliderIndex.X - 1  >= 0)
            {
                nodes.Add(new Node(SwapValues(node.Value, sliderIndex, new Point(sliderIndex.X - 1, sliderIndex.Y))));
            }
            if (sliderIndex.X + 1 < 3)
            {
                nodes.Add(new Node(SwapValues(node.Value, sliderIndex, new Point(sliderIndex.X + 1, sliderIndex.Y))));
            }
            if (sliderIndex.Y - 1 >= 0)
            {
                nodes.Add(new Node(SwapValues(node.Value, sliderIndex, new Point(sliderIndex.X, sliderIndex.Y - 1))));
            }
            if (sliderIndex.Y + 1 < 3)
            {
                nodes.Add(new Node(SwapValues(node.Value, sliderIndex, new Point(sliderIndex.X, sliderIndex.Y + 1))));
            }
            
            return nodes;
        }

        private int[,] SwapValues(int[,] array, Point index1, Point index2)
        {
            int[,] newArray = new int[3,3];
            for(int x = 0; x < 3; x++)
            {
                for(int y = 0; y < 3; y++)
                {
                    newArray[x, y] = array[x, y];
                }
            }

            int temp = newArray[index1.X, index1.Y];
            newArray[index1.X, index1.Y] = newArray[index2.X, index2.Y];
            newArray[index2.X, index2.Y] = temp;

            return newArray;
        }

        private void AddSuccessors(Node node, List<Node> successors)
        {
            for(int i = 0; i< successors.Count; i++)
            {
                node.AddNeighbor(successors[i]);
                Nodes.Add(successors[i]);
            }
        }

        private bool Contains(List<int[,]> list, int[,] state)
        {
            for(int i = 0; i < list.Count; i++)
            {
                if(state.Equals(list[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public List<Node> Search(NodeWrapper startingNode, NodeWrapper endingNode, Func<List<NodeWrapper>, NodeWrapper> selection, Func<NodeWrapper, NodeWrapper, float> heuristic)
        {
            List<int[,]> visitedNodes = new List<int[,]>();
            NodeWrapper currentNode = startingNode;
            List<NodeWrapper> frontier = new List<NodeWrapper>();

            while (currentNode.WrappedNode != endingNode.WrappedNode)
            {
                AddSuccessors(currentNode.WrappedNode, GenerateSuccessors(currentNode.WrappedNode));
                for (int i = 0; i < currentNode.WrappedNode.Neighbors.Count; i++)
                {
                    NodeWrapper neighbor = new NodeWrapper(currentNode.WrappedNode.Neighbors[i], heuristic(startingNode, endingNode), currentNode);
                    if (!Contains(visitedNodes, neighbor.WrappedNode.Value))
                    {
                        frontier.Add(neighbor);
                    }
                }

                visitedNodes.Add(currentNode.WrappedNode.Value);
                currentNode = selection(frontier);
            }

            List<Node> path = new List<Node>();
            while (currentNode.WrappedNode != startingNode.WrappedNode)
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
