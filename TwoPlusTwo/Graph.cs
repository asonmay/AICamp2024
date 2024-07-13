using Library;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TwoPlusTwo.Program;

namespace TwoPlusTwo
{
    public class Graph
    {
        public List<Node> Nodes;

        public Graph() => Nodes = new List<Node>();

        public void AddNode(GameState value) => Nodes.Add(new Node(value));

        public void AddEdge(Node startingNode, Node endingNode) => startingNode.AddNeighbor(endingNode);

        private void AddSuccessors(NodeWrapper node)
        {
            List<ISearchState<GameState>> successors = node.GetSuccessors();
            for (int i = 0; i < successors.Count; i++)
            {
                node.WrappedNode.AddNeighbor(((NodeWrapper)successors[i]).WrappedNode);
                Nodes.Add(((NodeWrapper)successors[i]).WrappedNode);
            }
        }

        private bool Contains(List<GameState> list, GameState state)
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

        public List<Node> Search(NodeWrapper startingNode, NodeWrapper endingNode, Func<List<NodeWrapper>, NodeWrapper> selection, Func<NodeWrapper, NodeWrapper, float> heuristic)
        {
            List<GameState> visitedNodes = new List<GameState>();
            NodeWrapper currentNode = startingNode;
            List<NodeWrapper> frontier = new List<NodeWrapper>();

            while (!currentNode.Equals(endingNode.WrappedNode.Value))
            {
                AddSuccessors(currentNode);
                for (int i = 0; i < currentNode.WrappedNode.Neighbors.Count; i++)
                {
                    float distanceFromStart = currentNode.DistanceFromStart + 1;
                    float cumulitiveDistance = distanceFromStart + heuristic(currentNode, endingNode);
                    NodeWrapper neighbor = new NodeWrapper(currentNode.WrappedNode.Neighbors[i], cumulitiveDistance, distanceFromStart, currentNode);
                    if (!Contains(visitedNodes, neighbor.WrappedNode.Value))
                    {
                        frontier.Add(neighbor);
                    }
                }
                visitedNodes.Add(currentNode.WrappedNode.Value);
                currentNode = selection(frontier);
            }

            return GeneratePath(currentNode, startingNode);
        }

        private List<Node> GeneratePath(NodeWrapper node, NodeWrapper startingNode)
        {
            List<Node> path = new List<Node>();
            while (!node.Equals(startingNode.WrappedNode.Value))
            {
                path.Add(node.WrappedNode);
                node = node.Founder;
            }
            path.Add(node.WrappedNode);
            path.Reverse();

            return path;
        }
    }
}
