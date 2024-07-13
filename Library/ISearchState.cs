using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public interface ISearchState<T>
    {
        public List<ISearchState<T>> GetSuccessors();

        public bool Equals(T other);
    }
}
