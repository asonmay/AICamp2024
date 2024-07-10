using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICamp2024
{
    public class Node<T>
    {
        public T Value;
        public List<Edge<T>> Neighbors;
        public Point Pos;

        public Node(T value, Point pos) => (Value, Neighbors, Pos) = (value, new List<Edge<T>>(), pos);

        public void AddNeighbor(Node<T> node) => Neighbors.Add(new Edge<T>(this, node, 1));
    }
}
