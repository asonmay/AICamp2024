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
        public float CumulitaveDistance { get; set; }
        public float DistanceFromStart { get; set; }

        public NodeWrapper(Node node, float distanceFromEnd, float cumulitiveDistance, NodeWrapper founder) => (WrappedNode, DistanceFromStart, CumulitaveDistance, Founder) = (node, cumulitiveDistance, distanceFromEnd, founder);
    }
}