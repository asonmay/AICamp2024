using Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringCSP
{
    public class NodeWrapper<T> : ISearchState<T>
    {
        public Node<T> WrappedNode { get; set; }
        private List<Constrant<T>> constrants;
        public Point currentLevel;

        public NodeWrapper(Node<T> node, List<Constrant<T>> constrants, Point currentLevel)
        {
            WrappedNode = node;
            this.constrants = constrants;
            this.currentLevel = currentLevel;
        }

        private Variable<T>[,] Copy()
        {
            Variable<T>[,] copy = new Variable<T>[3, 3];
            for(int x = 0; x < 3; x++)
            {
                for(int y = 0; y < 3; y++)
                {
                    T[] clone = new T[WrappedNode.Value[x, y].Domain.Count];
                    WrappedNode.Value[x, y].Domain.CopyTo(clone, 0);
                    copy[x, y] = new Variable<T>(clone.ToList());
                    copy[x, y].Guess = WrappedNode.Value[x, y].Guess;
                }
            }
            return copy;
        }

        public List<ISearchState<T>> GetSuccessors()
        {
            List<ISearchState<T>> successors = new List<ISearchState<T>>(); 
            Random random = new Random();
            Variable<T>[,] value = Copy();
            int count = value[currentLevel.X, currentLevel.Y].Domain.Count;

            for (int i = 0; i < count; i++)
            {
                value = Copy();
                value[currentLevel.X, currentLevel.Y].Guess = value[currentLevel.X, currentLevel.Y].Domain[i];
                if(DoesFollowConstrants(value))
                {
                    successors.Add(new NodeWrapper<T>(new Node<T>(value), constrants, GetNextLevel()));
                }
                else
                {
                    value[currentLevel.X, currentLevel.Y].Domain.Remove(value[currentLevel.X, currentLevel.Y].Guess);
                }
            }

            return successors;
        }

        private Point GetNextLevel()
        {
            Point nextLevel = currentLevel;
            if(nextLevel.X < 2)
            {
                nextLevel.X++;
            }
            else
            {
                nextLevel.Y++;
                nextLevel.X = 0;
            }
            return nextLevel;
        }

        private bool DoesFollowConstrants(Variable<T>[,] values)
        {
            for (int i = 0; i < constrants.Count; i++)
            {
                List<T> list = new List<T>();
                list.Add(values[constrants[i].Values[0].X, constrants[i].Values[0].Y].Guess);
                list.Add(values[constrants[i].Values[1].X, constrants[i].Values[1].Y].Guess);
                if (constrants[i].Values.Contains(currentLevel) && constrants[i].Function(list))
                {
                    return false;
                }
            }
            return true;
        }
    }
}