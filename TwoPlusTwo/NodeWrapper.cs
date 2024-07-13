using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static TwoPlusTwo.Program;

namespace TwoPlusTwo
{
    public class NodeWrapper : ISearchState<GameState>
    {
        public Node WrappedNode { get; set; }
        public NodeWrapper Founder { get; set; }
        public float CumulitaveDistance { get; set; }
        public float DistanceFromStart { get; set; }
        private List<Constrants> constrants;

        public NodeWrapper(Node node, float cumulitiveDistance, float distanceFromStart, NodeWrapper founder, List<Constrants> constrants)
        {
            WrappedNode = node;
            CumulitaveDistance = cumulitiveDistance;
            DistanceFromStart = distanceFromStart;
            Founder = founder;
            this.constrants = constrants;
        }

        public List<ISearchState<GameState>> GetSuccessors()
        {
            List<ISearchState<GameState>> Successors = new List<ISearchState<GameState>>();

            for(int i = 0; i < domain[currentChar].Count; i++)
            {
                GameState gameState = WrappedNode.Value;

                if (DoesFollowConstrants())
                {
                    gameState.Values.Add(domain[WrappedNode.Value.currentChar][i]);
                    gameState.Charactors.Add(gameState.CurrentChar);
                    gameState.Domain[gameState.CurrentChar].Remove(domain[WrappedNode.Value.currentChar][i])

                    Successors.Add(new NodeWrapper(new Node(gameState)))
                }
            }

            return Successors;
        }

        public bool Equals(GameState other) => other.Equals(WrappedNode.Value);

        private bool DoesFollowConstrants()
        {
            for(int i = 0; i < constrants.Count; i++)
            {
                if (constrants[i].Constrant())
            }
        }
    }
}