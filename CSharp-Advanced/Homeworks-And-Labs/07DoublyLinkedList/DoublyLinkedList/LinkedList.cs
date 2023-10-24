using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    public class LinkedList
    {
        private bool isReversed = false;
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public int Count { get; set; }

        public void Reverse()
        {
            isReversed = !isReversed;
        }

        public void AddLast(int nodeValue)
        {
            Count++;
            Node newNode = new Node(nodeValue);

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

        public void AddFirst(int nodeValue)
        {
            Count++;
            Node newNode = new Node(nodeValue);

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

        public Node RemoveLast()
        { 
            Node nodeToRemove = this.Tail;
            this.Tail = nodeToRemove.Previous;
            this.Tail.Next = null;
            nodeToRemove.Previous = null;
            Count--;
            return nodeToRemove;
        }

        public Node RemoveFirst()
        {
            Node nodeToRemove = this.Head;
            this.Head = nodeToRemove.Next;
            this.Head.Previous = null;
            nodeToRemove.Next = null;
            Count--;
            return nodeToRemove;
        }

        public int[] ToArray()
        {
            int[] array = new int[Count];
            int index = 0;
            Node currentNode = Head;

            while (currentNode != null)
            {
                array[index++] = currentNode.Value;
                currentNode = currentNode.Next;
            }

            return array;
        }

        public void ForEach(Action<int> callback)
        {
            Node currentNode = null;

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
