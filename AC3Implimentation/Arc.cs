using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC3Implimentation
{
    public class Arc<T>
    {
        public Func<List<T>, bool> Constrant;
        private Variable<T> head;
        private Variable<T> tail;
        public bool isChecked;

        public Arc(Func<List<T>, bool> constrant, Variable<T> head, Variable<T> tail)
        {
            Constrant = constrant;
            this.head = head;
            this.tail = tail;
        }

        public void PreformAC3(Arc<T> headArc, Arc<T> tailArc)
        {
            for(int i = 0; i < head.Domain.Count; i++)
            {
                T value = head.Domain[i];
                bool isValid = false;
                for(int j = 0; j < tail.Domain.Count; j++)
                {
                    if (Constrant(new List<T> { value, tail.Domain[j] }))
                    {
                        isValid = true;
                        break;
                    }
                }
                if(!isValid)
                {
                    head.Domain.Remove(value);
                    headArc.isChecked = false;
                }
            }

            for (int i = 0; i < tail.Domain.Count; i++)
            {
                T value = tail.Domain[i];
                bool isValid = false;
                for (int j = 0; j < head.Domain.Count; j++)
                {
                    if (Constrant(new List<T> { head.Domain[j], value }))
                    {
                        isValid = true;
                        break;
                    }
                }
                if(!isValid)
                {
                    tail.Domain.Remove(value);
                    tailArc.isChecked = false;
                }
            }

            isChecked = true;
        }
    }
}
