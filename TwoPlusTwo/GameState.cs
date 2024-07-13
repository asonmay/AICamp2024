using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoPlusTwo
{
    internal class GameState
    {
        public List<int> Values;
        public List<char> Charactors;
        public char CurrentChar;
        public Dictionary<char, List<int>> Domain;

        public GameState(List<int> values, List<char> charactors, Dictionary<char, List<int>> domain, char currentChar)
        {
            Values = values;
            Charactors = charactors;
            Domain = domain;
            CurrentChar = currentChar;
        }
    }
}
