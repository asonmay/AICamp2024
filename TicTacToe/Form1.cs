namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Button[,] grid;
        private Graph graph;
        private Node node;
        private bool isUserTurn;
        private char[,] currentBoardState;

        private void button4_Click(object sender, EventArgs e)
        {
            if (isUserTurn)
            {
                currentBoardState[0,2] = 'O';
                DrawBoard();
                isUserTurn = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            isUserTurn = true;
            Graph graph = GenerateGraph();
            currentBoardState = new char[3, 3];

            grid = new Button[3, 3]
            {
                { buttonA, buttonD, buttonG},
                { buttonB, buttonE, buttonH},
                { buttonC, buttonF, buttonI},
            };

            node = graph.Nodes[0];
        }

        private void CreateNodes(ref Node currentNode, Stack<Node> stack)
        {
            Queue<Node> frontier = new Queue<Node>();

            frontier.Enqueue(graph.Nodes[0]);
            stack.Push(currentNode);

            while (frontier.Count > 0)
            {
                currentNode = frontier.Dequeue();
                List<Node> sucessors = currentNode.GetSuccessors();

                for (int i = 0; i < sucessors.Count; i++)
                {
                    graph.AddNode(sucessors[i]);
                    graph.AddEdge(currentNode, sucessors[i]);
                    stack.Push(sucessors[i]);
                    frontier.Enqueue(sucessors[i]);
                }
            }
        }

        private Graph GenerateGraph()
        {
            graph = new Graph();

            List<Point> list = new List<Point>();
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    list.Add(new Point(x, y));
                }
            }

            graph.AddNode(new Node(new char[3, 3], 0, true, list));
            Node currentNode = graph.Nodes[0];
            Stack<Node> stack = new Stack<Node>();

            CreateNodes(ref currentNode, stack);

            while (currentNode.Value != graph.Nodes[0].Value)
            {
                currentNode = stack.Pop();

                if(currentNode.Neighbors.Count != 0)
                {
                    int value = 0;
                    if (currentNode.IsMin)
                    {
                        value = 1;
                    }
                    else
                    {
                        value = -1;
                    }

                    for (int i = 0; i < currentNode.Neighbors.Count; i++)
                    {
                        if (currentNode.IsMin)
                        {
                            if (currentNode.Neighbors[i].WinValue < value)
                            {
                                value = currentNode.Neighbors[i].WinValue;
                            }
                        }
                        else
                        {
                            if (currentNode.Neighbors[i].WinValue > value)
                            {
                                value = currentNode.Neighbors[i].WinValue;
                            }
                        }
                    }
                    currentNode.WinValue = value;
                }
            }

            return graph;
        }

        private void DrawBoard()
        {
            for(int x = 0; x < 3; x++)
            {
                for(int y = 0; y < 3; y++)
                {
                    if (currentBoardState[x, y] != 0)
                    {
                        grid[x, y].Text = currentBoardState[x, y].ToString();
                    }        
                }
            }
        }

        private bool IsEqual(char[,] item1, char[,] item2)
        {
            for(int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (item1[x,y] != item2[x, y])
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if(!isUserTurn)
            {
                for(int i = 0; i < node.Neighbors.Count; i++)
                {
                    if (IsEqual(node.Neighbors[i].Value, currentBoardState))
                    {
                        node = node.Neighbors[i];
                        continue;
                    }
                }

                Node nextNode = node.Neighbors[0];

                for(int i = 0; i < node.Neighbors.Count; i++)
                {
                    if(nextNode.WinValue < node.Neighbors[i].WinValue)
                    {
                        nextNode = node.Neighbors[i];
                    }
                }

                node = nextNode;
                currentBoardState = node.Value;
                isUserTurn = true;
                DrawBoard();
            }
        }

        private void buttonI_Click(object sender, EventArgs e)
        {
            if(isUserTurn)
            {
                currentBoardState[2, 2] = 'O';
                isUserTurn = false;
                DrawBoard();
            }
        }

        private void buttonA_Click(object sender, EventArgs e)
        {
            if (isUserTurn)
            {
                currentBoardState[0,0] = 'O';
                isUserTurn = false;
                DrawBoard();
            }
        }

        private void buttonB_Click(object sender, EventArgs e)
        {
            if (isUserTurn)
            {
                currentBoardState[1,0] = 'O';
                isUserTurn = false;
                DrawBoard();
            }
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            if (isUserTurn)
            {
                currentBoardState[2, 0] = 'O';
                DrawBoard();
                isUserTurn = false;
            }
        }

        private void buttonD_Click(object sender, EventArgs e)
        {
            if (isUserTurn)
            {
                currentBoardState[0,1] = 'O';
                DrawBoard();
                isUserTurn = false;
            }
        }

        private void buttonE_Click(object sender, EventArgs e)
        {
            if (isUserTurn)
            {
                currentBoardState[1,1] = 'O';
                isUserTurn = false;
            }
        }

        private void buttonF_Click(object sender, EventArgs e)
        {
            if (isUserTurn)
            {
                currentBoardState[2, 1] = 'O';
                isUserTurn = false;
                DrawBoard();
            }
        }

        private void buttonH_Click(object sender, EventArgs e)
        {
            if (isUserTurn)
            {
                currentBoardState[1,2] = 'O';
                DrawBoard();
                isUserTurn = false;
            }
        }
    }
}
