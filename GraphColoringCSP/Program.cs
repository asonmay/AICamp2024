using GraphColoringCSP;
using System.Drawing;
using System.Security.Cryptography;

namespace GraphColoringCSP
{
    internal class Program
    {
        static NodeWrapper<Color> DFSSelection(List<NodeWrapper<Color>> nodes)
        {
            NodeWrapper<Color> node = nodes[^1];
            nodes.Remove(node);
            return node;
        }

        static void Main(string[] args)
        {
            Size graphSize = new Size(3, 3);

            Variable<Color>[,] variables = new Variable<Color>[3, 3];

            for (int x = 0; x < graphSize.Width; x++)
            {
                for (int y = 0; y < graphSize.Height; y++)
                {
                    variables[x, y] = new Variable<Color>(new List<Color> { Color.Red, Color.Green, Color.Blue });
                }
            }

            Func<List<Color>, bool> isEqual = (List<Color> colors) => { return colors[0] == colors[1]; };

            Constrant<Color>[] constrants = new Constrant<Color>[]
            {
                new Constrant<Color>(isEqual, new List<Point>{new Point(0,0), new Point(1,0)}),
                new Constrant<Color>(isEqual, new List<Point>{new Point(2,0), new Point(1,0)}),
                new Constrant<Color>(isEqual, new List<Point>{new Point(0,1), new Point(1,0)}),
                new Constrant<Color>(isEqual, new List<Point>{new Point(1,1), new Point(1,0)}),
                new Constrant<Color>(isEqual, new List<Point>{new Point(2,0), new Point(2,1)}),
                new Constrant<Color>(isEqual, new List<Point>{new Point(0,1), new Point(1,1)}),
                new Constrant<Color>(isEqual, new List<Point>{new Point(0,1), new Point(0,2)}),
                new Constrant<Color>(isEqual, new List<Point>{new Point(0,1), new Point(0,0)}),
                new Constrant<Color>(isEqual, new List<Point>{new Point(1,1), new Point(2,1)}),
                new Constrant<Color>(isEqual, new List<Point>{new Point(1,1), new Point(2,0)}),
                new Constrant<Color>(isEqual, new List<Point>{new Point(1,1), new Point(0,2)}),
                new Constrant<Color>(isEqual, new List<Point>{new Point(1,2), new Point(2,2)}),
                new Constrant<Color>(isEqual, new List<Point>{new Point(2,1), new Point(2,2)}),
            };

            Graph<Color> graph = new Graph<Color>();
            graph.AddNode(variables);

            Variable<Color>[,] solution = graph.GetSolution(new NodeWrapper<Color>(graph.Nodes[0],constrants.ToList(),new Point(0,0)), DFSSelection);
            ;
        }
    }
}
