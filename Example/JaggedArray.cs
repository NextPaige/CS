using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    class JaggedArray
    {
        private object[] arr = new object[0];

        public void Add(object element)
        {
            var temp = new object[arr.Length + 1];
            for (int i = 0; i < arr.Length; i++)
            {
                temp[i] = arr[i];
            }
            arr = temp;

            arr[arr.Length - 1] = element;
        }
    }
}
