using System.Drawing;

namespace AC3Implimentation
{
    internal class Program
    {
        static NodeWrapper<int> DFSSelection(List<NodeWrapper<int>> nodes)
        {
            NodeWrapper<int> node = nodes[^1];
            nodes.Remove(node);
            return node;
        }

        static void Main(string[] args)
        {
            Variable<int>[] variables = new Variable<int>[]
            {
                new Variable<int>(new List<int>{1,2,3}),
                new Variable<int>(new List<int>{1,2,3}),
                new Variable<int>(new List<int>{1,2,3}),
            };

            List<Constrant<int>> constrants = new List<Constrant<int>>()
            { 
                new Constrant<int>((List<int> values) => {return values[0] < values[1]; }, new List<int>{0,1}),
                new Constrant<int>((List<int> values) => {return values[0] < values[1]; }, new List<int>{1,2}),
                new Constrant<int>((List<int> values) => {return values[0] != values[1]; }, new List<int>{2,0}),
            };

            Graph<int> graph = new Graph<int>();
            graph.AddNode(variables);
            
            Variable<int>[] solution = graph.GetSolution(new NodeWrapper<int>(new Node<int>(variables),constrants, 0), DFSSelection);
            ;
        } 
    }
}
