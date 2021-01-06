using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public class SinglyLinkedListNode<T>
    {
        private SinglyLinkedListNode<T> head;
        public T Data { get; set; }
        public SinglyLinkedListNode<T> Next { get; set; }

        public SinglyLinkedListNode(T data) 
        { 
            this.Data = data; 
            this.Next = null; 
        }

        public void Add(SinglyLinkedListNode<T> newNode)
        {
            // 리스트가 비어 있으면
            if (head == null)
            {
                head = newNode;
            }
            else
            { 
                var current = head;
                // 마지막 노드로 이동하여 추가
                while (current != null && current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }


        public void AddAfter(SinglyLinkedListNode<T> current, SinglyLinkedListNode<T> newNode)
        {
            // 노드가 비어있으면 예외처리
            if (head == null || current == null)
            {
                throw new InvalidOperationException();
            }
            // 새 노드의 Next를 현재 노드의 Next로 지정
            newNode.Next = current.Next;
            // 현재 노드의 Next에 새 노드를 대입하면 노드가 이어진다.
            current.Next = newNode;
        }

        public void Remove(SinglyLinkedListNode<T> removeNode)
        {
            // 현재 노드가 비어있거나 제거할 노드가 null이면 그냥 종료
            if (head == null || removeNode == null)
            {
                return;
            }

            // 삭제할 노드가 첫 노드이면
            if (head == removeNode)
            {
                head = head.Next;
                removeNode = null;
            }
            else
            {
                var current = head;
                // 단반향이므로 삭제할 노드의 바로 이전 노드를 검색해야 한다.
                while (current != null && current.Next != removeNode)
                {
                    current = current.Next;
                }

                /*
                 * 삭제할 노드의 이전 노드까지 반복을 완료 후 현재 노드가 null이 아니면
                 * 현재 노드의 Next에 삭제 노드의 Next를 대입
                 */
                if (current != null)
                {
                    current.Next = removeNode.Next;
                    removeNode = null;
                }
            }
        }

        public SinglyLinkedListNode<T> GetNode(int index)
        {
            var current = head;
            // 찾는 노드의 순번이 1이상이고 현재 노드가 null이 아닐 때 까지
            for (int i = 0; i < index && current != null; i++)
            {
                current = current.Next;
            }
            // 만약 index가 리스트 카운트보다 크면 null 리턴
            return current;
        }

        public int Count()
        {
            int cnt = 0;

            var current = head;

            while (current != null)
            {
                cnt++;
                current = current.Next;
            }
            return cnt;
        }
    }
}
