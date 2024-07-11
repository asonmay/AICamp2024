using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8PuzzelAI
{
    public class NodeWrapper
    {
        public Node WrappedNode { get; set; }
        public NodeWrapper Founder { get; set; }
        public float DistanceFromEnd { get; set; }

        public NodeWrapper(Node node, float distanceFromEnd, NodeWrapper founder) => (WrappedNode, DistanceFromEnd, Founder) = (node, distanceFromEnd, founder);
    }
}