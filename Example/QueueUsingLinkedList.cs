using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public class Node
    {
        public object Data { get; set; }
        public Node Next { get; set; }
        public Node(object data)
        {
            Data = data;
            Next = null;
        }
    }
    class QueueUsingLinkedList
    {
        private Node head = null;
        private Node tail = null;

        public void Enqueue(object data)
        {
            if (head == null)
            {
                head = new Node(data);
                tail = head;
            }
            else
            {
                tail.Next = new Node(data);
                tail = tail.Next;
            }
        }

        public object Dequeue()
        {
            if (head == null)
            {
                throw new ApplicationException("Empty");
            }

            object data = head.Data;

            // Queue에 하나 남은 경우
            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                head = head.Next;
            }
            return data;
        }

    }
}
