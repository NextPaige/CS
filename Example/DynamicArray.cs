using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    class DynamicArray
    {
        private object[] arr;
        private const int GROWTH_FACTOR = 2;

        public int Count { get; private set; }
        public int Capacity { get { return arr.Length; } }

        //배열의 초기값은 capacity로 설정
        public DynamicArray(int capacity = 16)
        {
            arr = new object[capacity];
            Count = 0;
        }


        public void Add(object element)
        {
            //배열이 가득차면 확장
            if (Count >= Capacity)
            {
                int newSize = Capacity * GROWTH_FACTOR;
                var temp = new object[newSize];
                for (int i = 0; i < arr.Length; i++)
                {
                    temp[i] = arr[i];
                }
                arr = temp;
            }
            arr[Count] = element;
            Count++;
        }

        public object Get(int index)
        {
            // 배열에 값이 없으면 예외처리
            if (index > Capacity - 1)
            {
                throw new ApplicationException("Element not found");
            }
            return arr[index];
        }
    }
}
