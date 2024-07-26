using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkovDecisionProcesses
{
    public class Grid
    {
        public Point Size;
        public Node[,] Nodes;

        public Grid(Point size)
        {
            Nodes = new Node[size.X, size.Y];
            Size = size;
        }

        public void DetermineBestNeighbors()
        {

        }

        public Node GetBestNode(Point index)
        {

        }
    }
}