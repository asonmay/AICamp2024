using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace TwoPlusTwo
{
    internal class Constrants
    {
        public List<char> Charactors;
        public Func<List<int>, bool> Constrant;

        public Constants(List<char> charactors, Func<List<int>, bool> constrant)
        {
            Charactors = charactors;
            Constrant = constrant;
        }
    }
}
