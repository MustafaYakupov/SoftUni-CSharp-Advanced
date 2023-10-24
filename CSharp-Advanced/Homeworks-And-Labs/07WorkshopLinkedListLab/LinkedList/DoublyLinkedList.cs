using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class DoublyLinkedList
    {
        private class ListNode
        {
            public ListNode(object value) 
            {
                this.Value = value;
            }

            public object Value { get; private set; }

            public ListNode Next { get; set; }

            public ListNode Previous { get; set; }
        }

        private ListNode head;
        private ListNode tail;

        public int Count { get; private set; }

        public object Head
        {
            get
            {
                this.ValidateIfListIsEmpty();

                return this.head.Value;
            }
        }

        public object Tail
        {
            get
            {
                this.ValidateIfListIsEmpty();

                return this.tail.Value;
            }
        }

        public void AddHead(object value)
        {
            var newNode = new ListNode(value);

            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                var oldHead = this.head;
                oldHead.Previous = newNode;
                newNode.Next = oldHead;
                this.head = newNode;
            }

            this.Count++;
        }

        public void AddTail(object value)
        {
            var newNode = new ListNode(value);

            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                var oldTail = this.tail;
                oldTail.Next = newNode;
                newNode.Previous = oldTail;
                this.tail = newNode;

            }

            this.Count++;
        }

        public object RemoveHead()
        {
            this.ValidateIfListIsEmpty();

            var value = this.head.Value;

            if (this.head == this.tail)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                var newHead = this.head.Next;
                newHead.Previous = null;
                this.head.Next = null;
                this.head = newHead;
            }

            this.Count--;

            return value;
        }

        public bool Contains(object value)
        {
            var currentNode = this.head;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    return true;
                }

                currentNode = currentNode.Next;
            }

            return false;
        }

        public object RemoveTail()
        {
            this.ValidateIfListIsEmpty();

            var value = this.tail.Value;

            if (this.head == this.tail)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                var oldTail = this.Tail;
                var newTail = this.tail.Previous;
                newTail.Next = null;
                this.tail.Previous = null;
                this.tail = newTail;
            }

            this.Count--;

            return value;
        }

        public void Clear()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }

        public void ForEach(Action<object> action)
        {
            var currentNode = this.head;

            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        public object[] ToArray()
        {
            var arr = new object[this.Count];

            var currentNode = this.head;
            var index = 0;

            while (currentNode != null)
            {
                arr[index] = currentNode.Value;
                index++;
                currentNode = currentNode.Next;
            }

            return arr;
        }

        private void ValidateIfListIsEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Linked list is empty");
            }
        }
    }
}
