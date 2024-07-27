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
        private bool isGameOver;
        private char[,] currentBoardState;
        private Dictionary<char[,], Node> gameStates;

        private void button4_Click(object sender, EventArgs e)
        {
            ButtonEvent(new Point(0, 2));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gameStates = new Dictionary<char[,], Node>(new CharArrayEquality());
            isUserTurn = true;
            Graph graph = GenerateGraph();
            currentBoardState = new char[3, 3];
            isGameOver = false;

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
                    if (gameStates.ContainsKey(sucessors[i].Value))
                    {
                        graph.AddEdge(currentNode, gameStates[sucessors[i].Value]);
                    }
                    else
                    {
                        graph.AddNode(sucessors[i]);
                        graph.AddEdge(currentNode, sucessors[i]);
                        gameStates.Add(sucessors[i].Value, sucessors[i]);
                        stack.Push(sucessors[i]);
                        frontier.Enqueue(sucessors[i]);
                    }
                    
                }
            }
        }

        private void SetNodeWinValue(Node currentNode)
        {
            int value = currentNode.IsMin ? 1 : -1;

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

        private void GenerateWinValues(Node currentNode, Stack<Node> stack)
        {
            while (currentNode.Value != graph.Nodes[0].Value)
            {
                currentNode = stack.Pop();

                if (currentNode.Neighbors.Count != 0)
                {
                    SetNodeWinValue(currentNode);
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
            GenerateWinValues(currentNode, stack);
            

            return graph;
        }

        private void DrawBoard()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
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
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (item1[x, y] != item2[x, y])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void UpdateNode()
        {
            for (int i = 0; i < node.Neighbors.Count; i++)
            {
                if (IsEqual(node.Neighbors[i].Value, currentBoardState))
                {
                    node = node.Neighbors[i];
                    continue;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (node.WinValue == 1 && node.Neighbors.Count == 0)
            {
                GameOverLabel.Text = "You Lost";
            }
            else if (node.Neighbors.Count == 0 && node.WinValue == -1)
            {
                GameOverLabel.Text = "You Won";
            }

            if (!isUserTurn && !isGameOver)
            {
                UpdateNode();

                if (node.Neighbors.Count == 0)
                {
                    GameOverLabel.Text = "Tie";
                    isUserTurn = true;
                    return;
                }

                Node nextNode = node.Neighbors[0];

                for (int i = 0; i < node.Neighbors.Count; i++)
                {
                    if (nextNode.WinValue < node.Neighbors[i].WinValue)
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
            ButtonEvent(new Point(2, 2));
        }

        private void buttonA_Click(object sender, EventArgs e)
        {
            ButtonEvent(new Point(0, 0));
        }

        private void buttonB_Click(object sender, EventArgs e)
        {
            ButtonEvent(new Point(1, 0));
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            ButtonEvent(new Point(2, 0));
        }

        private void buttonD_Click(object sender, EventArgs e)
        {
            ButtonEvent(new Point(0, 1));
        }

        private void buttonE_Click(object sender, EventArgs e)
        {
            ButtonEvent(new Point(1, 1));
        }

        private void buttonF_Click(object sender, EventArgs e)
        {
            ButtonEvent(new Point(2, 1));
        }

        private void buttonH_Click(object sender, EventArgs e)
        {
            ButtonEvent(new Point(1, 2));
        }

        private void ButtonEvent(Point gridPos)
        {
            if (isUserTurn && currentBoardState[gridPos.X, gridPos.Y] == (char)0 && !isGameOver)
            {
                currentBoardState[gridPos.X, gridPos.Y] = 'O';
                DrawBoard();
                isUserTurn = false;
            }
        }


        private void ResetButton_Click(object sender, EventArgs e)
        {
            GameOverLabel.Text = "";
            isUserTurn = true;
            isGameOver = false;
            gameStates = new Dictionary<char[,], Node>();
            GenerateGraph();
            node = graph.Nodes[0];

            for(int x = 0; x < 3; x++)
            {
                for(int y = 0; y < 3; y++)
                {
                    grid[x, y].Text = "";
                    currentBoardState[x, y] = (char)0;
                }
            }
        }
    }
}
