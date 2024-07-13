using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TwoPlusTwo.Program;

namespace TwoPlusTwo
{
    public class Node
    {
        public GameState Value;
        public List<Node> Neighbors;

        public Node(GameState value) => (Value, Neighbors) = (value, new List<Node>());

        public void AddNeighbor(Node node) => Neighbors.Add(node);
    }
}
