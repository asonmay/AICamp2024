using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICamp2024
{
    public class Node<T>
    {
        public T Value;
        public List<Edge<T>> Neighbors;

        public Node(T value) => (Value, Neighbors) = (value, new List<Edge<T>>());

        public void AddNeighbor(Node<T> node) => Neighbors.Add(new Edge<T>(this, node));
    }
}
