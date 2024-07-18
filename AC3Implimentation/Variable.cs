using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC3Implimentation
{
    public class Variable<T>
    {
        public List<T> Domain { get; set; }
        public T? Guess { get; set; }

        public Variable(List<T> domain)
        {
            Domain = domain;
        }
    }
}
