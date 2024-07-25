using Library;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpectiMax    
{
    public class Graph
    {
        public List<Node> Nodes;

        public Graph() => Nodes = new List<Node>();

        public void AddNode(Node node) => Nodes.Add(node);

        public void AddEdge(Node startingNode, Node endingNode)
        {
            startingNode.AddNeighbor(endingNode);
        }

        private void CreateNodes(ref Node currentNode, Stack<Node> stack)
        {
            Queue<Node> frontier = new Queue<Node>();

            frontier.Enqueue(Nodes[0]);
            stack.Push(currentNode);

            while (frontier.Count > 0)
            {
                currentNode = frontier.Dequeue();
                List<Node> sucessors = currentNode.GetSuccessors();

                for (int i = 0; i < sucessors.Count; i++)
                {
                    AddNode(sucessors[i]);
                    AddEdge(currentNode, sucessors[i]);
                    stack.Push(sucessors[i]);
                    frontier.Enqueue(sucessors[i]);
                }
            }
        }

        private void SetNodeWinValue(Node currentNode)
        {
            float value = 0;
            for(int i = 0; i < currentNode.Neighbors.Count; i++)
            {
                value += currentNode.Neighbors[i].WinValue * currentNode.Neighbors[i].Chance / 100;
            }
            currentNode.WinValue = value;
        }

        private void SetNodeChance(Node currentNode)
        {
            if(currentNode.Neighbors.Count > 1)
            {
                int index = 0;
                float value = float.NegativeInfinity;

                for (int i = 0; i < currentNode.Neighbors.Count; i++)
                {
                    if (currentNode.Neighbors[i].WinValue > value)
                    {
                        value = currentNode.Neighbors[i].WinValue;
                        index = i;
                    }
                }

                for (int i = 0; i < currentNode.Neighbors.Count; i++)
                {
                    if (i == index)
                    {
                        currentNode.Neighbors[i].Chance = currentNode.IsChance ? 90 : 10 / (currentNode.Neighbors.Count - 1);
                    }
                    else
                    {
                        currentNode.Neighbors[i].Chance = currentNode.IsChance ? 90 : 10 / (currentNode.Neighbors.Count - 1);
                    }
                }
            }
            else
            {
                  currentNode.Neighbors[0].Chance = 100;
            }
        }
            

        private void GenerateWinValues(Node currentNode, Stack<Node> stack)
        {
            while (currentNode.Value != Nodes[0].Value)
            {
                currentNode = stack.Pop();

                if (currentNode.Neighbors.Count != 0)
                {
                    SetNodeChance(currentNode);
                    SetNodeWinValue(currentNode);
                }
            }
        }

        public void GenerateGraph()
        {
            List<Point> list = new List<Point>();
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    list.Add(new Point(x, y));
                }
            }

            AddNode(new Node(new char[3, 3], 0, true, list));
            Node currentNode = Nodes[0];
            Stack<Node> stack = new Stack<Node>();

            CreateNodes(ref currentNode, stack);
            GenerateWinValues(currentNode, stack);
        }

    }
}
