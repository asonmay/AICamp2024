using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkovDecisionProcesses
{
    public class Node
    {
        public int value;
        public bool isInvalid;
        public List<Node> Neighbors;
        public Node BestNeighbor;

        public Node(int value, bool isInvalid)
        {
            this.value = value;
            this.isInvalid = isInvalid;
            Neighbors = new List<Node>();
        }

        public void AddNeighbor(Node neighbor) => Neighbors.Add(neighbor);
    }
}
