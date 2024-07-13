using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoPlusTwo
{
    internal class Variable
    {
        public List<int> Domain { get; set; }
        public int? Guess { get; set; }

        public Variable(List<int> domain)
        {
            Domain = domain;
        }
    }
}
