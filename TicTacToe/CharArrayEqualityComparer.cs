using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace TicTacToe
{
    public class CharArrayEqualityComparer : IEqualityComparer<char[,]>
    {
        public bool Equals(char[,]? item1, char[,]? item2)
        {
            for(int x = 0; x < item1.GetLength(0); x++)
            {
                for(int y = 0; y < item1.GetLength(1); y++)
                {
                    if (item1[x,y] != item2[x,y])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        
        public int GetHashCode(char[,] obj)
        {
            return obj.GetHashCode();
        }
    }
}
