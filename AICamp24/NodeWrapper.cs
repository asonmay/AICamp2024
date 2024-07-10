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
        public Node<T> WrappedNode;
        public float DistanceFromStart { get; set; }
        public NodeWrapper<T> Founder { get; set; }

        public NodeWrapper(Node<T> node, float distanceFromStart) => (WrappedNode, DistanceFromStart) = (node, distanceFromStart);
    }
}
