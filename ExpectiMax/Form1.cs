namespace ExpectiMax
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

        private void button4_Click(object sender, EventArgs e)
        {
            ButtonEvent(new Point(0, 2));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            isUserTurn = true;
            Graph graph = new Graph();
            graph.GenerateGraph();
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
            graph = new Graph();
            graph.GenerateGraph();
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
