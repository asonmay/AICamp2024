using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringCSP
{
    public class Node<T>
    {
        public Variable<T>[,] Value;
        public List<Node<T>> Neighbors;

        public Node(Variable<T>[,] value) => (Value, Neighbors) = (value, new List<Node<T>>());

        public void AddNeighbor(Node<T> node) => Neighbors.Add(node);
    }
}
