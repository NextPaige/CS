using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    class QueueUsingCircularArray
    {
        public object[] a;
        private int front;
        private int rear;


        public QueueUsingCircularArray(int capacity = 16)
        {
            a = new object[capacity];
            // 초기 값은 -1, 값이 추가 된 후 배열의 첫 인덱스인 0부터 시작
            front = -1;
            rear = -1;
        }

        public void Enqueue(object data)
        {
            // 큐가 가득 차 있는지 체크
            if ((rear + 1) % a.Length == front) 
            {
                throw new ApplicationException("Full");
            }
            else
            {
                // 큐가 비어있는 경우
                if (front == -1)
                {
                    front++;
                }
            }
            // 인큐 동작시 rear 값이 1씩 상승한다.
            rear = (rear + 1) % a.Length;
            a[rear] = data;
        }

        public object Dequeue()
        {
            // 큐가 비어있는지 체크
            if (front == -1 && rear == -1)
            {
                throw new ApplicationException("Empty");
            }
            else
            {
                // data 변수에 front에 있는 값을 대입
                object data = a[front];

                // 마지막 요소를 읽은 경우
                if (front == rear)
                {
                    front = -1;
                    rear = -1;
                }
                else
                {
                    // 디큐 동작시 front 값이 1씩 상승한다.
                    front = (front + 1) % a.Length;
                }
                return data;
            }
        }
    }

    
    class QueueUsingCircularArray2
    {
        private object[] a;
        private int front = 0;
        private int rear = 0;

        public QueueUsingCircularArray2(int queueSize = 16)
        {
            a = new object[queueSize];
        }

        public void Enqueue(object data)
        {
            if ((rear + 1) % a.Length == front)
            {
                throw new ApplicationException("Full");
            }
            a[rear] = data;
            rear = (rear + 1) % a.Length;
        }

        public object Dequeue()
        {
            if (front == rear)
            {
                throw new ApplicationException("Empty");
            }
            object data = a[front];
            front = (front + 1) % a.Length;
            return data;
        }
    }


    class QueueUsingCircularArray3
    {
        private object[] a;
        private int front = 0;
        private int rear = 0;

        public int Count { get; private set; } = 0;

        public QueueUsingCircularArray3(int queueSize = 16)
        {
            a = new object[queueSize];
        }

        public void Enqueue(object data)
        {
            if (Count == a.Length)
            {
                throw new ApplicationException("Full");
            }
            a[rear] = data;
            rear = (rear + 1) % a.Length;
            Count++;
        }

        public object Dequeue()
        {
            if (Count == 0)
            {
                throw new ApplicationException("Empty");
            }

            object data = a[front];
            front = (front + 1) % a.Length;
            Count--;
            return data;
        }
    }


}
