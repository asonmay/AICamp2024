using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GraphColoringCSP
{
    public class Constrant<T>
    {
        public List<Point> Values;
        public Func<List<T>, bool> Function;

        public Constrant(Func<List<T>, bool> constrant, List<Point> values)
        {
            Function = constrant;
            Values = values;
        }
    }
}
