using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public interface ISearchState<T>
    {
        public List<ISearchState<T>> GetSuccessors(T node, List<T> successors);

        public bool Equals(ISearchState<T> other);
    }
}
