using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpectiMax
{
    public class CharArrayEquality : IEqualityComparer<char[,]>
    {
        bool IEqualityComparer<char[,]>.Equals(char[,] x, char[,] y)
        {
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    if (x[i, j] != y[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        int IEqualityComparer<char[,]>.GetHashCode(char[,] obj)
        {
            return 0;
        }
    }
}
