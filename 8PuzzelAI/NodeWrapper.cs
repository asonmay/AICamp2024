using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8PuzzelAI
{
    public class NodeWrapper : ISearchState<int[,]>
    {
        public Node WrappedNode { get; set; }
        public NodeWrapper Founder { get; set; }
        public float CumulitaveDistance { get; set; }
        public float DistanceFromStart { get; set; }

        public NodeWrapper(Node node, float cumulitiveDistance, float distanceFromStart, NodeWrapper founder) => (WrappedNode, DistanceFromStart, CumulitaveDistance, Founder) = (node, distanceFromStart, cumulitiveDistance, founder);

        public List<ISearchState<int[,]>> GetSuccessors()
        {
            Point sliderIndex = new Point();
            for (int x = 0; x < WrappedNode.Value.GetLength(0); x++)
            {
                for (int y = 0; y < WrappedNode.Value.GetLength(1); y++)
                {
                    if (WrappedNode.Value[x, y] == 0)
                    {
                        sliderIndex = new Point(x, y);
                    }
                }
            }

            List<ISearchState<int[,]>> nodes = new List<ISearchState<int[,]>>();
            if (sliderIndex.X - 1 >= 0)
            {
                nodes.Add(new NodeWrapper(new Node(SwapValues(WrappedNode.Value, sliderIndex, new Point(sliderIndex.X - 1, sliderIndex.Y))), 0, 0, this));
            }
            if (sliderIndex.X + 1 < 3)
            { 
                nodes.Add(new NodeWrapper(new Node(SwapValues(WrappedNode.Value, sliderIndex, new Point(sliderIndex.X + 1, sliderIndex.Y))), 0, 0, this));
            }
            if (sliderIndex.Y - 1 >= 0)
            {
                nodes.Add(new NodeWrapper(new Node(SwapValues(WrappedNode.Value, sliderIndex, new Point(sliderIndex.X, sliderIndex.Y - 1))), 0, 0, this));
            }
            if (sliderIndex.Y + 1 < 3)
            {
                nodes.Add(new NodeWrapper(new Node(SwapValues(WrappedNode.Value, sliderIndex, new Point(sliderIndex.X, sliderIndex.Y + 1))), 0, 0, this));
            }

            return nodes;
        }

        private int[,] SwapValues(int[,] array, Point index1, Point index2)
        {
            int[,] newArray = new int[3, 3];
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    newArray[x, y] = array[x, y];
                }
            }

            int temp = newArray[index1.X, index1.Y];
            newArray[index1.X, index1.Y] = newArray[index2.X, index2.Y];
            newArray[index2.X, index2.Y] = temp;

            return newArray;
        }


        public bool Equals(int[,] other)
        {
            for (int x = 0; x < WrappedNode.Value.GetLength(0); x++)
            {
                for (int y = 0; y < WrappedNode.Value.GetLength(1); y++)
                {
                    if (WrappedNode.Value[x, y] != other[x, y])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}