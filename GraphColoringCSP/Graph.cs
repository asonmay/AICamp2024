using Library;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringCSP
{
    public class Graph<T>
    {
        public List<Node<T>> Nodes;

        public Graph() => Nodes = new List<Node<T>>();

        public void AddNode(Variable<T>[,] value) => Nodes.Add(new Node<T>(value));

        public void AddEdge(Node<T> startingNode, Node<T> endingNode)
        {
            startingNode.AddNeighbor(endingNode);
            endingNode.AddNeighbor(startingNode);
        }

        private bool Contains(List<Variable<T>[,]> list, Variable<T>[,] state)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Equals(state))
                {
                    return true;
                }
            }
            return false;
        }

        public Variable<T>[,] GetSolution(NodeWrapper<T> startingNode, Func<List<NodeWrapper<T>>, NodeWrapper<T>> selection)
        {
            List<Variable<T>[,]> visitedNodes = new List<Variable<T>[,]>();
            NodeWrapper<T> currentNode = startingNode;
            List<NodeWrapper<T>> frontier = new List<NodeWrapper<T>>();

            while (currentNode.currentLevel.Y < 3)
            {
                List<ISearchState<T>> successors = currentNode.GetSuccessors();
                for(int i = 0; i < successors.Count; i++)
                {
                    currentNode.WrappedNode.AddNeighbor(((NodeWrapper<T>)successors[i]).WrappedNode);
                }
                for (int i = 0; i < currentNode.WrappedNode.Neighbors.Count; i++)
                {
                    NodeWrapper<T> neighbor = ((NodeWrapper<T>)successors[i]);
                    if (!Contains(visitedNodes, neighbor.WrappedNode.Value))
                    {
                        frontier.Add(neighbor);
                    }
                }
                visitedNodes.Add(currentNode.WrappedNode.Value);
                currentNode = selection(frontier);
            }

            return currentNode.WrappedNode.Value;
        }
    }
}
