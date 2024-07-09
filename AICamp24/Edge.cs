using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICamp2024
{
    public class Edge<T>
    {
        public Node<T> StartingNode;
        public Node<T> EndingNode;

        public Edge(Node<T> startingNode, Node<T> endingNode) => (StartingNode, EndingNode) = (startingNode, endingNode);
    }
}
