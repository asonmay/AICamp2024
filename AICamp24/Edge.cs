using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphStuff
{
    public class Edge<T>
    {
        public Node<T> StartingNode;
        public Node<T> EndingNode;
        public float Weight;

        public Edge(Node<T> startingNode, Node<T> endingNode, float weight) => (StartingNode, EndingNode, Weight) = (startingNode, endingNode, weight);
    }
}
