using Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AC3Implimentation
{
    public class NodeWrapper<T> : ISearchState<T>
    {
        public Node<T> WrappedNode { get; set; }
        public List<Constrant<T>> Constrants;
        public int currentLevel;

        public NodeWrapper(Node<T> node, List<Constrant<T>> constrants, int currentLevel)
        {
            WrappedNode = node;
            this.Constrants = constrants;
            this.currentLevel = currentLevel;
        }

        private Variable<T>[] Copy()
        {
            Variable<T>[] copy = new Variable<T>[WrappedNode.Value.Length];

            for(int i = 0; i < copy.Length; i++)
            {
                T[] domain = new T[WrappedNode.Value[i].Domain.Count];
                WrappedNode.Value[i].Domain.CopyTo(domain, 0);

                copy[i] = new Variable<T>(domain.ToList());
                copy[i].Guess = WrappedNode.Value[i].Guess;
            }

            return copy;
        }

        public List<ISearchState<T>> GetSuccessors()
        {
            List<ISearchState<T>> successors = new List<ISearchState<T>>();
            Random random = new Random();
            Variable<T>[] value = Copy();
            int count = value[currentLevel].Domain.Count;

            for (int i = 0; i < count; i++)
            {
                value = Copy();
                value[currentLevel].Guess = value[currentLevel].Domain[i];
                if(DoesFollowConstrants(value))
                {
                    successors.Add(new NodeWrapper<T>(new Node<T>(value), Constrants, currentLevel + 1));
                }
                else
                {
                    value[currentLevel].Domain.Remove(value[currentLevel].Guess);
                }
            }

            return successors;
        }

        private bool DoesFollowConstrants(Variable<T>[] values)
        {
            for (int i = 0; i < Constrants.Count; i++)
            {
                List<T> list = new List<T>();
                for(int x = 0; x < Constrants[i].Values.Count; x++)
                {
                    list.Add(values[Constrants[i].Values[x]].Guess);                 
                }

                if (Constrants[i].Values.Contains(currentLevel) && !Constrants[i].Function(list))
                {
                    return false;
                }
            }
            return true;
        }
    }
}