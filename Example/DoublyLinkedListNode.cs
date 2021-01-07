using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    class DoublyLinkedListNode<T>
    {
        public DoublyLinkedListNode<T> head;
        public DoublyLinkedListNode<T> Prev { get; set; }
        public DoublyLinkedListNode<T> Next { get; set; }

        public T Data { get; set; }

        public DoublyLinkedListNode() { }
        public DoublyLinkedListNode(T data) : this(data, null, null) { }
        public DoublyLinkedListNode(T data, DoublyLinkedListNode<T> prev, DoublyLinkedListNode<T> next)
        {
            this.Data = data;
            this.Prev = prev;
            this.Next = next;
        }

        public void Add(DoublyLinkedListNode<T> newNode)
        {
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                var current = head;

                while (current != null && current.Next != null)
                {
                    current = current.Next;
                }
                // 현재 노드의 Next를 새 노드로 지정
                current.Next = newNode;
                // 새 노드의 Prev를 현재 노드로 지정
                newNode.Prev = current;
                // 새 노드의 다음은 null로 지정해야한다.
                newNode.Next = null;
            }
        }

        // 새 노드를 중간에 삽입
        public void AddAfter(DoublyLinkedListNode<T> current, DoublyLinkedListNode<T> newNode)
        {
            if (head == null || current == null || newNode == null)
            {
                throw new InvalidOperationException();
            }
            // 새 노드의 Next를 현재 노드의 Next로 지정
            newNode.Next = current.Next;
            // 현재 노드 Next의 Prev를 새 노드로 지정
            current.Next.Prev = newNode;
            // 새 노드의 Prev를 현재 노드로 지정
            newNode.Prev = current;
            // 현재 노드의 Next를 새 노드로 지정
            current.Next = newNode;
        }

        public void Remove(DoublyLinkedListNode<T> removeNode)
        {
            if (head == null || removeNode == null )
            {
                return;
            }

            if (removeNode == head)
            {
                head = head.Next;
                // 삭제할 노드가 첫 노드면 옮긴 후 Prev 제거
                if (head != null)
                {
                    head.Prev = null;
                }
            }
            else
            {
                removeNode.Prev.Next = removeNode.Next;
                // 삭제할 노드의 Next가 null이 아니면(삭제할 노드가 마지막이 아니면)
                if (removeNode.Next != null)
                {
                    removeNode.Next.Prev = removeNode.Prev;
                }
            }
            removeNode = null;
        }

        public DoublyLinkedListNode<T> GetNode(int index)
        {
            var current = head;

            for (int i = 0; i < index && current != null; i++)
            {
                current = current.Next;
            }
            return current;
        }

        public int Count()
        {
            int count = 0;

            var current = head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }

    }
}
