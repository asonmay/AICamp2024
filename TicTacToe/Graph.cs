using Library;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Graph
    {
        public List<Node> Nodes;

        public Graph() => Nodes = new List<Node>();

        public void AddNode(Node node) => Nodes.Add(node);

        public void AddEdge(Node startingNode, Node endingNode)
        {
            startingNode.AddNeighbor(endingNode);
        }
    }
}
