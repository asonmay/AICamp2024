using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Node
    {
        public char[,] Value;
        public List<Node> Neighbors;
        public bool IsMin;
        public int WinValue;
        public List<Point> EmptySquares;

        public Node(char[,] value, int winValue, bool isMin, List<Point> emptySquares) => (Value, Neighbors, WinValue, IsMin, EmptySquares) = (value, new List<Node>(), winValue, isMin, emptySquares);

        public void AddNeighbor(Node node) => Neighbors.Add(node);

        private char[,] Copy(char[,] source)
        {
            char[,] copy = new char[source.GetLength(0), source.GetLength(1)];
            for(int x = 0; x <  source.GetLength(0); x++)
            {
                for(int y = 0; y < source.GetLength(1); y++)
                {
                    copy[x, y] = source[x, y];
                }
            }
            return copy;
        }

        public List<Node> GetSuccessors()
        {
            List<Node> successors = new List<Node>();

            if(!IsGameWon(Value))
            {
                for (int i = 0; i < EmptySquares.Count; i++)
                {
                    char[,] newValue = Copy(Value);
                    char nextTurn;

                    if (IsMin)
                    {
                        newValue[EmptySquares[i].X, EmptySquares[i].Y] = 'O';
                    }
                    else
                    {
                        newValue[EmptySquares[i].X, EmptySquares[i].Y] = 'X';
                    }

                    List<Point> newList = new List<Point>();
                    for (int j = 0; j < EmptySquares.Count; j++)
                    {
                        if (j != i)
                        {
                            newList.Add(EmptySquares[j]);
                        }
                    }
                    successors.Add(new Node(newValue, 0, !IsMin, newList));
                }
            }
            
            if(successors.Count == 0 && !IsGameWon(Value))
            {
                WinValue = 0;
            }

            return successors;
        }

        private bool IsGameWon(char[,] board)
        {
            for(int i = 0; i < 3; i++)
            {
                if (board[i,0] != 0 && board[i,0] == board[i,1] && board[i,1] == board[i,2])
                {
                    if (board[i, 0] == 'O')
                    {
                        WinValue = -1;
                    }
                    else
                    {
                        WinValue = 1;
                    }
                    return true;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] != 0 && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                {
                    if (board[0, i] == 'O')
                    {
                        WinValue = -1;
                    }
                    else
                    {
                        WinValue = 1;
                    }
                    return true;
                }
            }
            if (board[0, 0] != 0 && board[0,0] == board[1,1] && board[1,1] == board[2,2])
            {
                if (board[0, 0] == 'O')
                {
                    WinValue = -1;
                }
                else
                {
                    WinValue = 1;
                }
                return true;
            }
            if (board[2, 0] != 0 && board[2,0] == board[1,1] && board[1,1] == board[0,2])
            {
                if (board[2, 0] == 'O')
                {
                    WinValue = -1;
                }
                else
                {
                    WinValue = 1;
                }
                return true;
            }
            return false;
        }
    }
}
