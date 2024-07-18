using Library;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC3Implimentation
{
    public class Graph<T>
    {
        public List<Node<T>> Nodes;

        public Graph() => Nodes = new List<Node<T>>();

        public void AddNode(Variable<T>[] value) => Nodes.Add(new Node<T>(value));

        public void AddEdge(Node<T> startingNode, Node<T> endingNode)
        {
            startingNode.AddNeighbor(endingNode);
            endingNode.AddNeighbor(startingNode);
        }

        private bool Contains(List<Variable<T>[]> list, Variable<T>[] state)
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

        private void FilterStartingNode(NodeWrapper<T> node)
        {
            Arc<T>[] arcs = new Arc<T>[node.WrappedNode.Value.Length];
            for(int i = 0; i < arcs.Length; i++)
            {
                Constrant<T> constrant = node.Constrants[0];
                for (int j = 0; j < node.Constrants[i].Values.Count; j++)
                {
                    if (node.Constrants[i].Values[j] == i)
                    {
                        constrant = node.Constrants[i];
                    }
                }

                if(i < node.WrappedNode.Value.Length - 1)
                {
                    arcs[i] = new Arc<T>(constrant.Function, node.WrappedNode.Value[i], node.WrappedNode.Value[i + 1]);
                }
                else
                {
                    arcs[i] = new Arc<T>(constrant.Function, node.WrappedNode.Value[i], node.WrappedNode.Value[0]);
                }
            }

            int index = 0;
            while (!AreArcsConsistant(arcs))
            {
                if (!arcs[index].isChecked)
                {
                    if (index > 0 && index < arcs.Length - 1)
                    {
                        arcs[index].PreformAC3(arcs[index - 1], arcs[index + 1]);
                    }
                    else if(index > 0)
                    {
                        arcs[index].PreformAC3(arcs[index - 1], arcs[index]);
                    }
                    else if(index < arcs.Length - 1)
                    {
                        arcs[index].PreformAC3(arcs[index], arcs[index + 1]);
                    }
                }
                index++;
                if(index >= arcs.Length)
                {
                    index = 0;
                }
            }
            ;
        }

        private bool AreArcsConsistant(Arc<T>[] arcs)
        {
            for(int i = 0; i < arcs.Length; i++)
            {
                if (!arcs[i].isChecked)
                {
                    return false;
                }
            }
            return true;
        }

        public Variable<T>[] GetSolution(NodeWrapper<T> startingNode, Func<List<NodeWrapper<T>>, NodeWrapper<T>> selection)
        {
            FilterStartingNode(startingNode);
            List<Variable<T>[]> visitedNodes = new List<Variable<T>[]>();
            NodeWrapper<T> currentNode = startingNode;
            List<NodeWrapper<T>> frontier = new List<NodeWrapper<T>>();

            while (currentNode.currentLevel < 3)
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
