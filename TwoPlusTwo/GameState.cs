using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoPlusTwo
{
    internal class GameState
    {
        public List<Variable> Values;
        public Variable var;
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
