using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    class CircularLinkedList<T>
    {
        private DoublyLinkedListNode<T> head;
        private DoublyLinkedListNode<T> Next { get; set; }
        private DoublyLinkedListNode<T> Prev { get; set; }

        private T Data { get; set; }

        public CircularLinkedList() { }
        public CircularLinkedList(T data) : this(data,null,null) { }
        public CircularLinkedList(T data, DoublyLinkedListNode<T> next, DoublyLinkedListNode<T> prev) 
        {
            this.Data = data;
            this.Next = next;
            this.Prev = prev;
        }

        public void Add(DoublyLinkedListNode<T> newNode)
        {
            if (head == null)
            {
                head = newNode;
                head.Next = head;
                head.Prev = head;
            }
            else
            {
                // head의 끝은 항상 tail, 새 노드는 항상 맨 끝에 생성되므로 tail
                var tail = head.Prev;

                head.Prev = newNode;
                tail.Next = newNode;
                newNode.Prev = tail;
                newNode.Next = head;
            }
        }


        public void AddAfter(DoublyLinkedListNode<T> current, DoublyLinkedListNode<T> newNode)
        {
            if (head == null || current == null || newNode == null)
            {
                throw new InvalidOperationException();
            }

            newNode.Next = current.Next;
            current.Next = newNode; 
            newNode.Prev = current;
            current.Next.Prev = newNode;
        }

        public void Remove(DoublyLinkedListNode<T> removeNode)
        {
            if (head == null || removeNode == null)
            {
                return;
            }

            // 삭제할 노드가 헤드 노드이고 노드가 1개이면
            if (removeNode == head && head == head.Next)
            {
                head = null;
            }
            else
            {
                removeNode.Prev.Next = removeNode.Next;
                removeNode.Next.Prev = removeNode.Prev;
            }
            removeNode = null;
        }

        public DoublyLinkedListNode<T> GetNode(int index)
        {
            if (head == null)
            {
                return null;
            }

            int count = 0;
            var current = head;

            // 원형 연결 리스트는 끝이 없다.
            while (count < index)
            {
                count++;
                current = current.Next;
                if (current == head)
                {
                    return null;
                }
            }

            return null;
        }

        public int Count()
        {
            if (head == null)
            {
                return 0;
            }

            int count = 0;
            var current = head;

            do
            {
                count++;
                current = current.Next;
            } while (current != head);
            return count;
        }
    }
}
