using AICamp2024;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class NodeWrapper<T>
    {
        public Node<T> WrappedNode { get; set; }
        public float DistanceFromStart { get; set; }
        public NodeWrapper<T> Founder { get; set; }
        public float DistanceFromEnd { get; set; }

        public NodeWrapper(Node<T> node, float distanceFromStart, float distanceFromEnd, NodeWrapper<T> founder) => (WrappedNode, DistanceFromStart, DistanceFromEnd, Founder) = (node, distanceFromStart, distanceFromEnd, founder);
    }
}
