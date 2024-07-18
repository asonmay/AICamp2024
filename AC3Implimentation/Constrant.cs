using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AC3Implimentation
{
    public class Constrant<T>
    {
        public List<int> Values;
        public Func<List<T>, bool> Function;

        public Constrant(Func<List<T>, bool> constrant, List<int> values)
        {
            Function = constrant;
            Values = values;
        }
    }
}
