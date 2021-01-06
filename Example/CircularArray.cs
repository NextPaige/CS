using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    // FIFO(First in First out)
    // index = (index + i) % Array.Length;
    class CircularArray
    {
        char[] A = "abcdefgh".ToCharArray();
        int startIndex = 2;
        
        public void CheckArray()
        {
            for (int i = 0; i < A.Length; i++)
            {
                int index = (startIndex + i) % A.Length;
                Console.WriteLine(A[index]);
            }
        }
    }
}
