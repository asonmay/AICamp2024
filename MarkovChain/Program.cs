using MarkovDecisionProcesses;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Threading.Tasks.Dataflow;

namespace MarkovDecisionProcesses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point size = new Point(4, 3);
            Grid grid = new Grid(size);

            grid.Nodes = new Node[,]
            {
                { new Node(-1, true), new Node(-1, true), new Node(-1, true), new Node(-1, true), new Node(10, true), new Node(-1, true), },
                { new Node(-1, true), new Node(-1, false), new Node(-1, false), new Node(-1, false), new Node(10, false), new Node(-1, true), },
                { new Node(-1, true), new Node(-1, false), new Node(-1, true), new Node(-1, false), new Node(-100, false), new Node(-1, true), },
                { new Node(-1, true), new Node(-1, false), new Node(-1, false), new Node(-1, false), new Node(-1, false), new Node(-1, true), },
                { new Node(-1, true), new Node(-1, true), new Node(-1, true), new Node(-1, true), new Node(10, true), new Node(-1, true), },
            };

            for(int x = 0; x < grid.Nodes.GetLength(0); x++)
            {
                for(int y = 0; y < grid.Nodes.GetLength(1); y++)
                {
                    if(x + 1 < grid.Nodes.GetLength(0))
                    {
                        grid.Nodes[x, y].AddNeighbor(grid.Nodes[x + 1, y]);
                        grid.Nodes[x + 1, y].AddNeighbor(grid.Nodes[x, y]);
                    }
                    if (y + 1 < grid.Nodes.GetLength(0))
                    {
                        grid.Nodes[x, y].AddNeighbor(grid.Nodes[x, y + 1]);
                        grid.Nodes[x, y + 1].AddNeighbor(grid.Nodes[x, y]);
                    }
                }
            }
            ;
        }
    }
}
