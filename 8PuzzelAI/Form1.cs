using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8PuzzelAI
{
    public partial class Form1 : Form
    {
        Button[,] buttonGrid;
        int[,] numberGrid;
        List<Node> path;
        int index;

        public Form1()
        {
            InitializeComponent();
        }

        private bool IsValidGrid(int[,] grid)
        {
            int inversions = 0;
            for (int x = 0; x < 9; x++)
            {
                for (int y = x + 1; y < 9; y++)
                {
                    if (grid[x / 3, x % 3] > grid[y / 3, y % 3] && grid[x/3, x % 3] != 0 && grid[y / 3, y % 3] != 0)
                    {
                        inversions++;
                    }
                }
            }
            if (inversions % 2 == 1)
            {
                return false;
            }
            return true;
        }

        private int[,] GenerateGrid()
        {
            int[,] grid = new int[3,3];
            Random random = new Random();

            for(int x = 0; x < 9; x++)
            {
                grid[x % 3, x / 3] = random.Next(0, 9);
                for(int y = 0; y < x;y++)
                {
                    if (grid[y % 3, y / 3] == grid[x % 3, x / 3])
                    {
                        x--;
                        break;
                    }
                }
            }

            return grid;
        }

        private int[,] Scramble()
        {
            int[,] grid = new int[3, 3];
            while(true)
            {
                grid = GenerateGrid();
                if(IsValidGrid(grid))
                {
                    break;
                }
            }
            return grid;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttonGrid = new Button[,]
            {
                {Square11, Square12, Square13 },
                {Square21, Square22, Square23 },
                {Square31, Square32, Square33 },
            };
            numberGrid = Scramble();
            for(int x = 0; x < 3; x++)
            {
                for(int y = 0; y < 3; y++)
                {
                    if (numberGrid[x, y] == 0)
                    {
                        buttonGrid[x, y].Text = "";
                    }
                    else
                    {
                        buttonGrid[x, y].Text = numberGrid[x, y].ToString();
                    }
                }
            }
        }

        static NodeWrapper AStarSelection(List<NodeWrapper> nodes)
        {
            NodeWrapper node = nodes[0];

            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].CumulitaveDistance < node.CumulitaveDistance)
                {
                    node = nodes[i];
                }
            }
            nodes.Remove(node);

            return node;
        }

        static float Heuristic(NodeWrapper startingNode, NodeWrapper endingNode)
        { 
            float squaresAwayFromGoal = 0f;
            Dictionary<int, Point> correctPositions = new Dictionary<int, Point>();

            for (int x = 0; x < endingNode.WrappedNode.Value.GetLength(0); x++)
            {
                for (int y = 0; y < endingNode.WrappedNode.Value.GetLength(1); y++)
                {
                    correctPositions.Add(endingNode.WrappedNode.Value[x, y], new Point(x, y));
                }
            }

            for (int x = 0; x < startingNode.WrappedNode.Value.GetLength(0); x++)
            {
                for (int y = 0; y < startingNode.WrappedNode.Value.GetLength(1); y++)
                {
                    if (startingNode.WrappedNode.Value[x,y] != 0)
                    {
                        squaresAwayFromGoal += Math.Abs(x - correctPositions[startingNode.WrappedNode.Value[x, y]].X) + Math.Abs(y - correctPositions[startingNode.WrappedNode.Value[x, y]].Y);
                    }
                }
            }
            return squaresAwayFromGoal;
        }

        private void SolveButton_Click(object sender, EventArgs e)
        {
            int[,] solvedGrid =
            {
                {1,2,3},
                {4,5,6},
                {7,8,0},
            };

            Graph graph = new Graph();
            graph.AddNode(numberGrid);
            path = graph.Search(new NodeWrapper(graph.Nodes[0], float.MaxValue, 0, null), new NodeWrapper(new Node(solvedGrid),0, float.MaxValue, null), AStarSelection, Heuristic);
            index = 0;
            VisualizerTImer.Enabled = true;
        }

        private void SetGrid(int[,] numbers)
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                { 
                    if (numbers[x, y] == 0)
                    {
                        buttonGrid[x, y].Text = "";
                    }
                    else
                    {
                        buttonGrid[x, y].Text = numbers[x, y].ToString();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numberGrid = Scramble();
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if(numberGrid[x, y] == 0)
                    {
                        buttonGrid[x, y].Text = "";
                    }
                    else
                    {
                        buttonGrid[x, y].Text = numberGrid[x, y].ToString();
                    }
                }
            }
        }

        private void Square13_Click(object sender, EventArgs e)
        {

        }

        private void VisualizerTImer_Tick(object sender, EventArgs e)
        {
            if(index == path.Count)
            {
                VisualizerTImer.Enabled = false;
                return;
            }
            SetGrid(path[index].Value);
            index++;
            NumOfMoves.Text = $"Moves: {index + 1}";
        }
    }
}
