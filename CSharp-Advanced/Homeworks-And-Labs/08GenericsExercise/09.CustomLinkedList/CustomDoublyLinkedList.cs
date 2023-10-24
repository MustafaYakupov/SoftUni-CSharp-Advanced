using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLinkedList
{
    public class CustomDoublyLinkedList<T>
    {
        private bool isReversed = false;
        public ListNode<T> Head { get; set; }
        public ListNode<T> Tail { get; set; }
        public int Count { get; set; }

        public void Reverse()
        {
            isReversed = !isReversed;
        }

        public void AddLast(T nodeValue)
        {
            Count++;
            ListNode<T> newNode = new ListNode<T>(nodeValue);

            if (this.Head == null)
            {
                this.Head = newNode;
                this.Tail = newNode;
                return;
            }

            newNode.Previous = this.Tail;
            this.Tail.Next = newNode;
            this.Tail = newNode;
        }

        public void AddFirst(T nodeValue)
        {
            Count++;
            ListNode<T> newNode = new ListNode<T>(nodeValue);

            if (this.Head == null)
            {
                this.Head = newNode;
                this.Tail = newNode;
                return;
            }

            newNode.Next = this.Head;
            this.Head.Previous = newNode;
            this.Head = newNode;
        }

        public ListNode<T> RemoveLast()
        {
            ListNode<T> nodeToRemove = this.Tail;
            this.Tail = nodeToRemove.Previous;
            this.Tail.Next = null;
            nodeToRemove.Previous = null;
            Count--;
            return nodeToRemove;
        }

        public ListNode<T> RemoveFirst()
        {
            ListNode<T> nodeToRemove = this.Head;
            this.Head = nodeToRemove.Next;
            this.Head.Previous = null;
            nodeToRemove.Next = null;
            Count--;
            return nodeToRemove;
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            int index = 0;
            ListNode<T> currentNode = Head;

            while (currentNode != null)
            {
                array[index++] = currentNode.Value;
                currentNode = currentNode.Next;
            }

            return array;
        }

        public void ForEach(Action<T> callback)
        {
            ListNode<T> currentNode = null;

            if (!isReversed)
            {
                currentNode = this.Head;
            }
            else
            {
                currentNode = this.Tail;
            }

            while (currentNode != null)
            {
                callback(currentNode.Value);
                if (!isReversed)
                {
                    currentNode = currentNode.Next;
                }
                else
                {
                    currentNode = currentNode.Previous;
                }
            }
        }
    }
}
